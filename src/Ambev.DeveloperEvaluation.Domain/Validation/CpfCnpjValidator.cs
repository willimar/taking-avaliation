using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class CpfCnpjValidator : AbstractValidator<string>
    {
        public CpfCnpjValidator()
        {
            RuleFor(cpfCnpj => cpfCnpj)
                .NotEmpty()
                .WithMessage("CPF/CNPJ is required")
                .Must(IsValidCpfOrCnpj)
                .WithMessage("Invalid CPF/CNPJ");
        }

        private static bool IsValidCpfOrCnpj(string arg)
        {
            return IsValidCpf(arg) || IsValidCnpj(arg);
        }

        private static bool IsValidCnpj(string cnpj)
        {
            // Remove caracteres não numéricos
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            // Verifica se o CNPJ tem 14 dígitos
            if (cnpj.Length != 14)
                return false;

            // Verifica se todos os dígitos são iguais (CNPJ inválido)
            if (cnpj.All(c => c == cnpj[0]))
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplier1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 12; i++)
                sum += (cnpj[i] - '0') * multiplier1[i];

            int remainder = sum % 11;
            int digit1 = (remainder < 2) ? 0 : 11 - remainder;

            // Calcula o segundo dígito verificador
            int[] multiplier2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 13; i++)
                sum += (cnpj[i] - '0') * multiplier2[i];

            remainder = sum % 11;
            int digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Verifica se os dígitos verificadores estão corretos
            return (cnpj[12] - '0' == digit1) && (cnpj[13] - '0' == digit2);
        }

        private static bool IsValidCpf(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais (CPF inválido)
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcula o primeiro dígito verificador
            int[] multiplier1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += (cpf[i] - '0') * multiplier1[i];

            int remainder = sum % 11;
            int digit1 = (remainder < 2) ? 0 : 11 - remainder;

            // Calcula o segundo dígito verificador
            int[] multiplier2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += (cpf[i] - '0') * multiplier2[i];

            remainder = sum % 11;
            int digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Verifica se os dígitos verificadores estão corretos
            return (cpf[9] - '0' == digit1) && (cpf[10] - '0' == digit2);
        }
    }

}
