using Ambev.DeveloperEvaluation.Domain.Validation;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using FluentValidation.TestHelper;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Contains unit tests for the CpfCnpjValidator class.
/// Tests cover various email validation scenarios including format, length, and empty checks.
/// </summary>
public class CpfCnpjValidatorTests
{
    private readonly CpfCnpjValidator _validator;

    public CpfCnpjValidatorTests()
    {
        _validator = new CpfCnpjValidator();
    }

    /// <summary>
    /// Tests that validation passes for various valid cpf formats.
    /// </summary>
    [Theory(DisplayName = "Valid diferent CPF formats should pass validation")]
    [InlineData("607.892.000-66")]
    [InlineData("607.892.00066")]
    [InlineData("607-892-000-66")]
    [InlineData("60789200066")]
    public void Given_ValidCpfFormat_When_Validated_Then_ShouldNotHaveErrors(string value)
    {
        // Arrange
        var cpf = value;

        // Act
        var result = _validator.TestValidate(cpf);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }

    /// <summary>
    /// Tests that validation passes for various valid cnpj formats.
    /// </summary>
    [Theory(DisplayName = "Valid diferent CPF formats should pass validation")]
    [InlineData("24.061.016/0001-72")]
    [InlineData("24.061.016/000172")]
    [InlineData("24.061.016.0001/72")]
    [InlineData("24061016000172")]
    public void Given_ValidCnpjFormat_When_Validated_Then_ShouldNotHaveErrors(string value)
    {
        // Arrange
        var cnpj = value;

        // Act
        var result = _validator.TestValidate(cnpj);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}
