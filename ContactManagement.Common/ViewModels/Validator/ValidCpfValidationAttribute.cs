using ContactManagement.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Common.ViewModels.Validator
{
    /// <summary>
    /// This class is used to create a custom a validation to validate if the CPF is valid
    /// </summary>
    public class ValidCpfValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contactViewModel = (ContactViewModel)validationContext.ObjectInstance;

            if (contactViewModel.ContactType == (int)ContactTypeEnum.NaturalPerson && !ValidaCPF(contactViewModel.Cpf.ToString()))
            {
                return new ValidationResult("Invalid CPF");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        private bool ValidaCPF(string cpf)
        {
            int[] multiplier1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplier2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier1[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * multiplier2[i];
            rest = sum % 11;
            if (rest < 2)
                rest = 0;
            else
                rest = 11 - rest;
            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }
    }
}
