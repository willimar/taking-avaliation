using Ambev.DeveloperEvaluation.Application;
using Ambev.DeveloperEvaluation.Common.HealthChecks;
using Ambev.DeveloperEvaluation.Common.Logging;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.IoC;
using Ambev.DeveloperEvaluation.ORM;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Ambev.DeveloperEvaluation.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Log.Information("Starting web application");
            var apiInfo = ApiInfo.Factory();

            SetApiInfo(apiInfo.Info);

            apiInfo.MajorVersion = 1;
            apiInfo.GroupNameFormat = "'v'V";

            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.AddDefaultLogging();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.AddBasicHealthChecks();
            builder.Services.AddSwaggerGen(
                delegate (SwaggerGenOptions c)
                {
                    c.SwaggerDoc($"v{apiInfo.MajorVersion}", apiInfo.Info);
                    c.AddSecurityDefinition(apiInfo.SecurityScheme.Scheme, apiInfo.SecurityScheme);
                    c.AddSecurityRequirement(apiInfo.SecurityRequirementFactory());
                    c.IncludeAllXmlComents(apiInfo.KeyNameToXmlComents);
                    c.TagActionsBy(apiInfo.TagActionBy);
                    c.DocInclusionPredicate((string name, ApiDescription api) => true);
                    c.EnableAnnotations();
                });

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseNpgsql(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Ambev.DeveloperEvaluation.ORM")
                )
            );

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Information); 
            });

            var app = builder.Build();
            app.UseMiddleware<ValidationExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseBasicHealthChecks();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void SetApiInfo(OpenApiInfo info)
    {
        var (descriptionAttribute, productAttribute, copyrightAttribute, assemblyName) = GetAssemblyInfo();

        info.Title = productAttribute?.Product;
        info.Version = assemblyName.Version?.ToString();
        info.Description = descriptionAttribute?.Description;
        info.Contact = new OpenApiContact
        {
            Name = copyrightAttribute?.Copyright,
            Url = new Uri(@"https://github.com/willimar"),
            Email = "willimar@gmail.com",
        };
        info.TermsOfService = null;
        info.License = new OpenApiLicense()
        {
            Name = "RESTRICT USE LICENSE",
            Url = new Uri(@"https://github.com/willimar")
        };
    }

    private static (AssemblyDescriptionAttribute? descriptionAttribute, AssemblyProductAttribute? productAttribute, AssemblyCopyrightAttribute? copyrightAttribute, AssemblyName assemblyName) GetAssemblyInfo()
    {
        var assembly = typeof(Program).Assembly;
        var assemblyInfo = assembly.GetName();

        var descriptionAttribute = assembly
             .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
             .OfType<AssemblyDescriptionAttribute>()
             .FirstOrDefault();
        var productAttribute = assembly
             .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
             .OfType<AssemblyProductAttribute>()
             .FirstOrDefault();
        var copyrightAttribute = assembly
             .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
             .OfType<AssemblyCopyrightAttribute>()
             .FirstOrDefault();

        return (descriptionAttribute, productAttribute, copyrightAttribute, assemblyInfo);
    }

    
}

internal static class SwaggerGenOptionsExtension 
{
    public static void IncludeAllXmlComents(this SwaggerGenOptions swaggerGenOptions, string keyName)
    {
        var pathToXmlDocumentsToLoad = AppDomain.CurrentDomain.GetAssemblies()
                .Where(x => x.FullName != null && x.FullName.ToLower().Contains(keyName.ToLower()))
                .Select(x => Path.Combine(AppContext.BaseDirectory, $"{x.GetName().Name}.xml"))
                .Where(x => File.Exists(x))
                .ToList();

        pathToXmlDocumentsToLoad.ForEach(doc => swaggerGenOptions.IncludeXmlComments(doc));
    }
}
