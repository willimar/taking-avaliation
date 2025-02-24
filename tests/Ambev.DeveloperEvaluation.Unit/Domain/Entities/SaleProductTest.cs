using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Product entity class.
/// Tests cover status changes and validation scenarios.
/// </summary>
public class SaleProductTests
{
    /// <summary>
    /// Tests that validation passes when all product properties are valid.
    /// </summary>
    [Fact(DisplayName = "Validation should pass for valid product data")]
    public void Given_ValidProductData_When_Validated_Then_ShouldReturnValid()
    {
        // Arrange
        var product = SaleProductTestData.GenerateValidSaleProduct();
        product.TotalUnityValue = product.UnitValue - product.Discount;

        // Act
        var result = product.Validate();

        // Assert
        Assert.True(result.IsValid);
        Assert.Empty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid()
    {
        // Arrange
        var product = SaleProductTestData.GenerateValidSaleProduct();
        product.ProductName = string.Empty;

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data [Field Price]")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid_Price()
    {
        // Arrange
        var product = SaleProductTestData.GenerateValidSaleProduct();
        product.UnitValue = 0;

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Fact(DisplayName = "Validation should fail for invalid product data [Field Total Price]")]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid_Total_Price()
    {
        // Arrange
        var product = SaleProductTestData.GenerateValidSaleProduct();
        product.TotalUnityValue = product.UnitValue - product.Discount + 1;

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }

    /// <summary>
    /// Tests that validation fails when product properties are invalid.
    /// </summary>
    [Theory(DisplayName = "Validation should fail for invalid product data [Field Count]")]
    [InlineData(0)]
    [InlineData(21)]
    public void Given_InvalidProductData_When_Validated_Then_ShouldReturnInvalid_Count(int count)
    {
        // Arrange
        var product = SaleProductTestData.GenerateValidSaleProduct();
        product.Count = count;

        // Act
        var result = product.Validate();

        // Assert
        Assert.False(result.IsValid);
        Assert.NotEmpty(result.Errors);
    }
}
