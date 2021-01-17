using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the gender was filled
    /// This filed just will be validate if the contact type was equal Natural person
    /// </summary>
    class GenderValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.NaturalPerson && entity.Gender != null && entity.Gender != GenderEnum.Undefined) ||
                   (entity.ContactType == ContactTypeEnum.LegalPerson && (entity.Gender == null || entity.Gender == GenderEnum.Undefined));
        }
    }
}

