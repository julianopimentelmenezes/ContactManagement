using AutoMapper;
using ContactManagement.Common.Enums;
using ContactManagement.Common.ViewModels;
using ContactManagement.Domain;
using System;

namespace ContactManagement.Business.Mappings
{
    /// <summary>
    /// This is a mapping profile class who map the viewmodel class to domain class
    /// </summary>
    class ViewModelToDomainMappingProfile : Profile
    {
        /// <summary>
        /// Constructor class who create the map
        /// </summary>
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ContactRequestViewModel, Contact>()
                .ForMember(m => m.ContactId, o => o.MapFrom(s => s.ContactId))
                .ForMember(m => m.ContactType, o => o.MapFrom(s => (ContactTypeEnum?)s.ContactType))
                .ForMember(m => m.Name, o => o.MapFrom(s => NameResolver(s.Name, (ContactTypeEnum?)s.ContactType)))
                .ForMember(m => m.CompanyName, o => o.MapFrom(s => CompanyNameResolver(s.CompanyName, (ContactTypeEnum?)s.ContactType)))
                .ForMember(m => m.TradeName, o => o.MapFrom(s => TradeNameResolver(s.TradeName, (ContactTypeEnum?)s.ContactType)))
                .ForMember(m => m.Cpf, o => o.MapFrom(s => s.Cpf))
                .ForMember(m => m.Cnpj, o => o.MapFrom(s => s.Cnpj))
                .ForMember(m => m.Birthday, o => o.MapFrom(s => BirthdayResolver(s.Birthday, (ContactTypeEnum?)s.ContactType)))
                .ForMember(m => m.Gender, o => o.MapFrom(s => GenderResolver((GenderEnum?)s.Gender, (ContactTypeEnum?)s.ContactType)))
                .ForMember(m => m.ZipCode, o => o.MapFrom(s => s.ZipCode))
                .ForMember(m => m.Country, o => o.MapFrom(s => s.Country))
                .ForMember(m => m.State, o => o.MapFrom(s => s.State))
                .ForMember(m => m.City, o => o.MapFrom(s => s.City))
                .ForMember(m => m.AddressLine1, o => o.MapFrom(s => s.AddressLine1))
                .ForMember(m => m.AddressLine2, o => o.MapFrom(s => s.AddressLine2));
        }

        /// <summary>
        /// Here are implemented the field convert functions
        /// </summary>
        #region [Private functions]
        private string NameResolver(string name, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.NaturalPerson => name,
                ContactTypeEnum.LegalPerson => string.Empty,
                null => string.Empty,
                _ => string.Empty,
            };
        }
        private string CompanyNameResolver(string companyName, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.NaturalPerson => string.Empty,
                ContactTypeEnum.LegalPerson => companyName,
                null => string.Empty,
                _ => string.Empty,
            };
        }
        private string TradeNameResolver(string tradeName, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.NaturalPerson => string.Empty,
                ContactTypeEnum.LegalPerson => tradeName,
                null => string.Empty,
                _ => string.Empty,
            };
        }
        private DateTime? BirthdayResolver(DateTime? birthday, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.NaturalPerson => birthday,
                ContactTypeEnum.LegalPerson => (DateTime?)null,
                null => (DateTime?)null,
                _ => (DateTime?)null,
            };
        }
        private GenderEnum? GenderResolver(GenderEnum? gender, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.NaturalPerson => gender,
                ContactTypeEnum.LegalPerson => GenderEnum.Undefined,
                null => GenderEnum.Undefined,
                _ => GenderEnum.Undefined,
            };
        }

        #endregion [Private functions]
    }
}

