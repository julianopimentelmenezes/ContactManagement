using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the name was filled
    /// This filed only will be validate if the contact type was equal Natural person
    /// </summary>
    class NameValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.NaturalPerson && !string.IsNullOrEmpty(entity.Name)) ||
                   (entity.ContactType == ContactTypeEnum.LegalPerson && string.IsNullOrEmpty(entity.Name));
        }
    }
}

