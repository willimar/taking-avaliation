using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;
using Bogus.Extensions.Brazil;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleTestData
{
    /// <summary>
    /// Configures the Faker to generate valid Sale entities.
    /// The generated products will have valid:
    /// </summary>
    private static readonly Faker<Sale> SaleFakerCpf = new Faker<Sale>("pt_BR")
        .RuleFor(u => u.TotalValue, f => f.Commerce.Random.Decimal(1, 999))
        .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
        .RuleFor(u => u.UserName, f => f.Person.UserName)
        .RuleFor(u => u.CpfCnpjCustomer, f => f.Person.Cpf())
        .RuleFor(u => u.Date, f => DateTime.UtcNow)
        .RuleFor(u => u.Number, f => f.Random.Word())
        .RuleFor(u => u.CustomerName, f => f.Person.FullName);

    private static readonly Faker<Sale> SaleFakerCnpj = new Faker<Sale>("pt_BR")
        .RuleFor(u => u.TotalValue, f => f.Commerce.Random.Decimal(1, 999))
        .RuleFor(u => u.CompanyName, f => f.Company.CompanyName())
        .RuleFor(u => u.UserName, f => f.Person.UserName)
        .RuleFor(u => u.CpfCnpjCustomer, f => f.Company.Cnpj())
        .RuleFor(u => u.Date, f => DateTime.UtcNow)
        .RuleFor(u => u.Number, f => f.Random.Word())
        .RuleFor(u => u.CustomerName, f => f.Person.FullName);

    /// <summary>
    /// Generates a valid Sale entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid Sale entity with randomly generated data.</returns>
    public static Sale GenerateValidSale(bool cpf)
    {
        if (cpf)
        {
            return SaleFakerCpf.Generate();
        }

        return SaleFakerCnpj.Generate();
    }

    /// <summary>
    /// Generates a productname that exceeds the maximum length limit.
    /// The generated productname will:
    /// - Be longer than 100 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing productname length validation error cases.
    /// </summary>
    /// <returns>A productname that exceeds the maximum length limit.</returns>
    public static string GenerateLongSalename()
    {
        return new Faker().Random.String2(101);
    }
}
