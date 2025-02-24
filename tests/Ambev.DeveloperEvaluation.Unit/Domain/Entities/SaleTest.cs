using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that validation passes when all sale properties are valid.
    /// </summary>
    [Theory(DisplayName = "Validation should pass for valid sale data with CPF")]
    [InlineData(true)]
    [InlineData(false)]
    public void Given_ValidSaleData_CPF_When_Validated_Then_ShouldReturnValid(bool cpf)
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(cpf);

        // Act
        var result = sale.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid sale data [Field Number]")]
    public void Given_InvalidSaleData_To_Number_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(true);
        sale.Number = string.Empty;

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when sale properties are invalid.
    /// </summary>
    [Theory(DisplayName = "Validation should fail for invalid sale data [Field Count]")]
    [InlineData("107.326.730-01")]
    [InlineData("11.670.723/0001-15")]
    public void Given_InvalidSaleData_To_Count_When_Validated_Then_ShouldReturnInvalid(string invalidData)
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale(true);
        sale.CpfCnpjCustomer = invalidData;

        // Act
        var result = sale.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
