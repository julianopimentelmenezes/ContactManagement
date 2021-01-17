using ContactManagement.Common.ViewModels.Validator;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Common.ViewModels
{
    /// <summary>
    /// This class is responsible to have the contact fields
    /// </summary>
    public class ContactViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "ID")]
        public long ContactId { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public int ContactType { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string ContactTypeDescription { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Trade name")]
        public string TradeName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CPF")]
        [ValidCpfValidation]
        public long? Cpf { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "CNPJ")]
        [ValidCnpjValidation]
        public long? Cnpj { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public int Gender { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string GenderDescription { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "State")]
        public string State { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "City")]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; }
    }
}
