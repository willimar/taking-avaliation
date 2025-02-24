using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using System.Resources;

namespace Ambev.DeveloperEvaluation.WebApi
{
    public class ApiInfo
    {
        public int MajorVersion { get; set; } = 1;
        public int MinorVersion { get; set; } = 1;
        public string GroupNameFormat { get; set; } = "'v'VVV";
        public bool SubstituteApiVersionInUrl { get; set; } = true;
        public bool AssumeDefaultVersionWhenUnspecified { get; set; } = false;
        public bool ReportApiVersions { get; set; } = true;
        public OpenApiInfo Info { get; set; } = new OpenApiInfo();
        public OpenApiSecurityScheme SecurityScheme { get; set; } = SecuritySchemeFactory();
        public string KeyNameToXmlComents { get; set; } = string.Empty;
        public Func<ApiDescription, IList<string>> TagActionBy { get; set; } = GetTagActionBy();

        public static ApiInfo Factory()
        {
            return new ApiInfo();
        }

        public virtual OpenApiSecurityRequirement SecurityRequirementFactory()
        {
            return new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        } };
        }

        private static OpenApiSecurityScheme SecuritySchemeFactory()
        {
            return new OpenApiSecurityScheme
            {
                Description = "Processo de avaliação da Consultoria Taking",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            };
        }

        private static Func<ApiDescription, IList<string>> GetTagActionBy()
        {
            return delegate (ApiDescription api)
            {
                if (api.GroupName != null)
                {
                    return new string[1] { api.GroupName ?? "" };
                }

                if (!(api.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor))
                {
                    throw new InvalidOperationException();
                }

                return new string[1] { controllerActionDescriptor.ControllerName };
            };
        }
    }
}
