using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class SaleProductTestData
{
    /// <summary>
    /// Configures the Faker to generate valid SaleProduct entities.
    /// The generated products will have valid:
    /// </summary>
    private static readonly Faker<SaleProduct> SaleProductFaker = new Faker<SaleProduct>()
        .RuleFor(u => u.ProductId, f => Guid.NewGuid())
        .RuleFor(u => u.SaleId, f => Guid.NewGuid())
        .RuleFor(u => u.ProductName, f => f.Commerce.ProductName())
        .RuleFor(u => u.UnitValue, f => f.Commerce.Random.Decimal(1, 9999))
        .RuleFor(u => u.Canceled, f => f.Commerce.Random.Bool())
        .RuleFor(u => u.Count, f => f.Commerce.Random.Int(1, 20));

    /// <summary>
    /// Generates a valid SaleProduct entity with randomized data.
    /// The generated product will have all properties populated with valid values
    /// that meet the system's validation requirements.
    /// </summary>
    /// <returns>A valid SaleProduct entity with randomly generated data.</returns>
    public static SaleProduct GenerateValidSaleProduct()
    {
        return SaleProductFaker.Generate();
    }

    /// <summary>
    /// Generates a valid email address using Faker.
    /// The generated email will:
    /// - Follow the standard url format (http://domain.com/route)
    /// - Have valid characters in both local and domain parts
    /// - Have a valid TLD
    /// </summary>
    /// <returns>A valid url address.</returns>
    public static string GenerateValidUrl()
    {
        return new Faker().Internet.Url();
    }

    /// <summary>
    /// Generates an invalid email address for testing negative scenarios.
    /// The generated url will:
    /// - Not follow the standard email format
    /// - Not contain the http or https symbol
    /// - Be a simple word or string
    /// This is useful for testing url validation error cases.
    /// </summary>
    /// <returns>An invalid email address.</returns>
    public static string GenerateInvalidUrl()
    {
        var faker = new Faker();
        return faker.Lorem.Word();
    }

    /// <summary>
    /// Generates a productname that exceeds the maximum length limit.
    /// The generated productname will:
    /// - Be longer than 100 characters
    /// - Contain random alphanumeric characters
    /// This is useful for testing productname length validation error cases.
    /// </summary>
    /// <returns>A productname that exceeds the maximum length limit.</returns>
    public static string GenerateLongSaleProductname()
    {
        return new Faker().Random.String2(101);
    }
}
