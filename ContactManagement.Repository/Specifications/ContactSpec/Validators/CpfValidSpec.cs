using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the CPF was filled
    /// This filed just will be validate if the contact type was equal Natural person
    /// </summary>
    class CpfValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.NaturalPerson && !string.IsNullOrEmpty(entity.Cpf)) ||
                   (entity.ContactType == ContactTypeEnum.LegalPerson && string.IsNullOrEmpty(entity.Cpf));
        }
    }
}

