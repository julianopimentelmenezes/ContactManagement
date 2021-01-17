using ContactManagement.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Common.ViewModels.Validator
{
	/// <summary>
	/// This class is used to create a custom a validation to validate if the CNPJ is valid
	/// </summary>
	public class ValidCnpjValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var contactViewModel = (ContactViewModel)validationContext.ObjectInstance;

			if (contactViewModel.ContactType == (int)ContactTypeEnum.LegalPerson && !ValidaCNPJ(contactViewModel.Cnpj.ToString()))
            {
                return new ValidationResult("Invalid CNPJ.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        private bool ValidaCNPJ(string cnpj)
        {
			int[] multiplier1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplier2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int sum;
			int rest;
			string digit;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			sum = 0;
			for (int i = 0; i < 12; i++)
				sum += int.Parse(tempCnpj[i].ToString()) * multiplier1[i];
			rest = (sum % 11);
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;
			digit = rest.ToString();
			tempCnpj = tempCnpj + digit;
			sum = 0;
			for (int i = 0; i < 13; i++)
				sum += int.Parse(tempCnpj[i].ToString()) * multiplier2[i];
			rest = (sum % 11);
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;
			digit = digit + rest.ToString();
			return cnpj.EndsWith(digit);
		}
    }
}
