using AutoMapper;
using ContactManagement.Common.Enums;
using ContactManagement.Common.Extensions;
using ContactManagement.Common.ViewModels;
using ContactManagement.Domain;
using System;

namespace ContactManagement.Business.Mappings
{
    /// <summary>
    /// Class responsible to mapping the domain class to view model class
    /// </summary>
    public class DomainToViewModelMappingProfile
        : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Contact, ContactViewModel>()
                .ForMember(m => m.ContactId, o => o.MapFrom(s => s.ContactId))
                .ForMember(m => m.ContactType, o => o.MapFrom(s => (int)s.ContactType))
                .ForMember(m => m.ContactTypeDescription, o => o.MapFrom(s => s.ContactType.GetDescription()))
                .ForMember(m => m.Name, o => o.MapFrom(s => s.Name))
                .ForMember(m => m.CompanyName, o => o.MapFrom(s => s.CompanyName))
                .ForMember(m => m.TradeName, o => o.MapFrom(s => s.TradeName))
                .ForMember(m => m.Cpf, o => o.MapFrom(s => CpfResolver(s.Cpf, s.ContactType)))
                .ForMember(m => m.Cnpj, o => o.MapFrom(s => s.Cnpj))
                .ForMember(m => m.Birthday, o => o.MapFrom(s => s.Birthday))
                .ForMember(m => m.Gender, o => o.MapFrom(s => GenderResolver(s.Gender, s.ContactType)))
                .ForMember(m => m.GenderDescription, o => o.MapFrom(s => GenderDescriptionResolver(s.Gender, s.ContactType)))
                .ForMember(m => m.ZipCode, o => o.MapFrom(s => s.ZipCode))
                .ForMember(m => m.Country, o => o.MapFrom(s => s.Country))
                .ForMember(m => m.State, o => o.MapFrom(s => s.State))
                .ForMember(m => m.City, o => o.MapFrom(s => s.City))
                .ForMember(m => m.AddressLine1, o => o.MapFrom(s => s.AddressLine1))
                .ForMember(m => m.AddressLine2, o => o.MapFrom(s => s.AddressLine2));
        }

        #region [Private methods]
        private long? CpfResolver(string cpf, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.LegalPerson => (long?)null,
                ContactTypeEnum.NaturalPerson => Convert.ToInt64(cpf),
                null => (long?)null,
                _ => (long?)null
            };
        }
        private long? CnpjResolver(string cnpj, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.LegalPerson => Convert.ToInt64(cnpj),
                ContactTypeEnum.NaturalPerson => (long?)null,
                null => (long?)null,
                _ => (long?)null
            };
        }

        private int GenderResolver(GenderEnum? gender, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.LegalPerson => (int)GenderEnum.Undefined,
                ContactTypeEnum.NaturalPerson => (int)gender,
                null => (int)GenderEnum.Undefined,
                _ => (int)GenderEnum.Undefined,
            };
        }

        private string GenderDescriptionResolver(GenderEnum? gender, ContactTypeEnum? contactType)
        {
            return contactType switch
            {
                ContactTypeEnum.LegalPerson => string.Empty,
                ContactTypeEnum.NaturalPerson => gender.GetDescription(),
                null => string.Empty,
                _ => string.Empty,
            };
        }

        #endregion [Private methods]
    }
}
