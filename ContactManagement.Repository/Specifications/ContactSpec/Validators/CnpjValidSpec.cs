using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the cnpj was filled
    /// This filed only will be validate if the contact type was equal Legal person
    /// </summary>
    class CnpjValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.LegalPerson && !string.IsNullOrEmpty(entity.Cnpj)) ||
                   (entity.ContactType == ContactTypeEnum.NaturalPerson && string.IsNullOrEmpty(entity.Cnpj));
        }
    }
}

