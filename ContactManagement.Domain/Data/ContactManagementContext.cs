using ContactManagement.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactManagement.Domain.Data
{
    /// <summary>
    /// Class responsible to the datacontext and initialize some data to use in development
    /// </summary>
    public class ContactManagementContext: DbContext
    {
        public ContactManagementContext(DbContextOptions<ContactManagementContext> options)
        : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
               new Contact
               {
                   ContactId = 1,
                   ContactType = ContactTypeEnum.NaturalPerson,
                   Name = "Juliano",
                   Cpf = "10695158767",
                   Birthday = Convert.ToDateTime("1988-05-05"),
                   Gender = GenderEnum.Male,
                   ZipCode = "24220091",
                   Country = "Brazil",
                   State = "RJ",
                   City = "Niteroi",
                   AddressLine1 = "Domingues de sá, 370 apt 802"
               },
                new Contact
                {
                    ContactId = 2,
                    ContactType = ContactTypeEnum.LegalPerson,
                    CompanyName = "XPTO IT",
                    TradeName = "XPTO",
                    Cnpj = "999999999999998",
                    ZipCode = "9999999",
                    Country = "Brazil",
                    State = "MG",
                    City = "Juiz de fora",
                    AddressLine1 = "Some bussiness place"
                },
                new Contact
                {
                    ContactId = 3,
                    ContactType = ContactTypeEnum.NaturalPerson,
                    Name = "Zé",
                    Cpf = "99999999998",
                    Birthday = Convert.ToDateTime("2000-01-01"),
                    Gender = GenderEnum.Male,
                    ZipCode = "99999999",
                    Country = "Brazil",
                    State = "MG",
                    City = "Juiz de fora",
                    AddressLine1 = "Some place",
                    AddressLine2 = "Some bussiness place"
                });
        }
    }
}
