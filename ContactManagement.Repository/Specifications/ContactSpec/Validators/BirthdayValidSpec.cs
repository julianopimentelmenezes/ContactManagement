using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the birthday was filled
    /// This filed only will be validate if the contact type was equal Natural person
    /// </summary>
    class BirthdayValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.NaturalPerson && entity.Birthday != null) ||
                   (entity.ContactType == ContactTypeEnum.LegalPerson && (entity.Birthday == null));
        }
    }
}

