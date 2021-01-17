﻿using Xunit;
using Microsoft.Extensions.DependencyInjection;
using ContactManagement.Business.Interfaces;
using ContactManagement.Common.ViewModels;
using System;
using ContactManagement.Domain.Data;

namespace ContactManagement.IntegrationTest.API
{

    /// <summary>
    /// This class is responsible for test all business methods in the API application
    /// </summary>
    public class APITest : IClassFixture<TestFixture<Startup>>
    {
        readonly TestFixture<Startup> _fixture;
        readonly IContactManagementBusiness _contactManagementBusiness;
        readonly ContactManagementContext _contactManagementContext;

        public APITest(TestFixture<Startup> fixture)
        {
            _fixture = fixture;

            _contactManagementBusiness = _fixture?
                .ServiceProvider?
                .GetService<IContactManagementBusiness>();

            _contactManagementContext = _fixture?
                .ServiceProvider?
                .GetService<ContactManagementContext>();

            _contactManagementContext.Database.EnsureDeleted();
            _contactManagementContext.Database.EnsureCreated();
        }

        [Fact]
        public void TestGetContacts()
        {
            var result = _contactManagementBusiness.GetContacts();

            Assert.True(result.Sucess);
        }

        [Theory]
        [InlineData(1)]
        public void TestGetContact(long id)
        {
            var result = _contactManagementBusiness.GetContact(id);

            Assert.True(result.Sucess);
        }

        [Fact]
        public void TestCreateContact()
        {
            var contactViewModel = GenerateContactRequestViewModel(false);

            var result = _contactManagementBusiness.CreateContact(contactViewModel);

            Assert.True(result.Sucess);
        }

        [Fact]
        public void TestUpdateContact()
        {
            var contactRequestViewModel = GenerateContactRequestViewModel(true);

            var result = _contactManagementBusiness.UpdateContact(contactRequestViewModel);

            Assert.True(result.Sucess);
        }

        [Theory]
        [InlineData(3)]
        public void TestDeleteContact(long id)
        {
            var result = _contactManagementBusiness.DeleteContact(id);

            Assert.True(result.Sucess);
        }

        private ContactRequestViewModel GenerateContactRequestViewModel(bool update)
        {
            return new ContactRequestViewModel
            {
                ContactId = update ? 1 : null,
                ContactType = 1,
                Name = "Juliano",
                Cpf = 10695158767,
                Birthday = Convert.ToDateTime("1988-05-05"),
                Gender = 1,
                ZipCode = "24220091",
                Country = "Brazil",
                State = "RJ",
                City = "Niteroi",
                AddressLine1 = "Domingues de sá, 370 apt 802"
            };
        }
    }
}

