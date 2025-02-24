using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the UrlValidator class.
/// Tests cover various email validation scenarios including format, length, and empty checks.
/// </summary>
public class UrlValidatorTests
{
    private readonly UrlValidator _validator;

    public UrlValidatorTests()
    {
        _validator = new UrlValidator();
    }

    /// <summary>
    /// Tests that validation passes for various valid ulr formats.
    /// </summary>
    [Theory(DisplayName = "Valid diferent urls should pass validation")]
    [InlineData("https://dominio.com/asset/imagem.png")]
    [InlineData("https://localhost:8080/asset/imagem.jpg")]
    [InlineData("https://www.dominio.com/asset/imagem.jpg")]
    public void Given_ValidUrlFormat_When_Validated_Then_ShouldNotHaveErrors(string value)
    {
        // Arrange
        var url = value;

        // Act
        var result = _validator.TestValidate(url);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation passes for various valid cnpj formats.
    /// </summary>
    [Theory(DisplayName = "Valid diferent urls should not pass validation")]
    [InlineData("http://dominio.com/asset/imagem.png")]
    [InlineData("http://localhost:8080/asset/imagem.jpg")]
    [InlineData("http://www.dominio.com/asset/imagem.jpg")]
    public void Given_ValidUrlFormat_When_Validated_Then_ShouldHaveErrors(string value)
    {
        // Arrange
        var url = value;

        // Act
        var result = _validator.TestValidate(url);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x).WithErrorMessage("The provided url address is not valid.");
    }
}
