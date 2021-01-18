using System;

namespace ContactManagement.Common.ViewModels
{
    /// <summary>
    /// This class is responsible to have the request contact fields 
    /// </summary>
    public class ContactRequestViewModel
    {
        public long? ContactId { get; set; }
        public int ContactType { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public long Cpf { get; set; }
        public string Cnpj { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
}
