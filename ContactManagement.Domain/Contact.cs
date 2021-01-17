using ContactManagement.Common.Enums;
using System;

namespace ContactManagement.Domain
{
    /// <summary>
    /// This class represent the contact model
    /// </summary>
    public class Contact
    {
        public long ContactId { get; set; }

        public ContactTypeEnum? ContactType { get; set; }

        public string Name { get; set; }

        public string CompanyName { get; set; }

        public string TradeName { get; set; }

        public string Cpf { get; set; }

        public string Cnpj { get; set; }

        public DateTime? Birthday { get; set; }

        public GenderEnum? Gender { get; set; }

        public string ZipCode { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }
    }
}
