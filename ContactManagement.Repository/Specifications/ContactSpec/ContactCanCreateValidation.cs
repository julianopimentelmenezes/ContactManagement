using ContactManagement.Domain;
using ContactManagement.Domain.Interfaces.Repositories;
using ContactManagement.Repository.Specifications.ContactSpec.Validators;
using DomainValidationCore.Validation;

namespace ContactManagement.Repository.Specifications.ContactSpec
{
    /// <summary>
    /// This class call all the contact validations to the Create functionality
    /// </summary>
    public class ContactCanCreateValidation
        : Validator<Contact>
    {
        public ContactCanCreateValidation(IContactRepository contactRepository)
        {
            var contactTypeValid = new ContactTypeValidSpec();
            var nameValid = new NameValidSpec();
            var companyNameValid = new CompanyNameValidSpec();
            var tradeNameValid = new TradeNameValidSpec();
            var cpfValid = new CpfValidSpec();
            var cnpjValid = new CnpjValidSpec();
            var birthdayValid = new BirthdayValidSpec();
            var genderValid = new GenderValidSpec();
            var zipCodeValid = new ZipCodeValidSpec();
            var countryValid = new CountryValidSpec();
            var stateValid = new StateValidSpec();
            var cityValid = new CityValidSpec();
            var addressLine1Valid = new AddressLine1ValidSpec();

            base.Add("ContactTypeValid", new Rule<Contact>(contactTypeValid, "Contact type invalid. Must by Natural or Legal."));
            base.Add("NameValid", new Rule<Contact>(nameValid, "Name invalid."));
            base.Add("CompanyNameValid", new Rule<Contact>(companyNameValid, "Company Name invalid."));
            base.Add("TradeNameValid", new Rule<Contact>(tradeNameValid, "Trade Name invalid."));
            base.Add("CPFValid", new Rule<Contact>(cpfValid, "CPF Name invalid."));
            base.Add("CNPJValid", new Rule<Contact>(cnpjValid, "CNPJ Name invalid."));
            base.Add("BirthdayValid", new Rule<Contact>(birthdayValid, "birthday invalid."));
            base.Add("GenderValid", new Rule<Contact>(genderValid, "Gender invalid."));
            base.Add("ZipCodeValid", new Rule<Contact>(zipCodeValid, "ZipCode invalid."));
            base.Add("CountryValid", new Rule<Contact>(countryValid, "Country invalid."));
            base.Add("StateValid", new Rule<Contact>(stateValid, "State invalid."));
            base.Add("CityValid", new Rule<Contact>(cityValid, "City invalid."));
            base.Add("AddressLine1Valid", new Rule<Contact>(addressLine1Valid, "Address Line 1 invalid."));
        }

    }
}
