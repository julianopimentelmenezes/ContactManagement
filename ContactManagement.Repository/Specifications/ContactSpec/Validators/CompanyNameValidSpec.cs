using ContactManagement.Common.Enums;
using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;
namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the company name was filled
    /// This filed just will be validate if the contact type was equal Legal person
    /// </summary>
    class CompanyNameValidSpec : ISpecification<Contact>
    {

        public bool IsSatisfiedBy(Contact entity)
        {
            return (entity.ContactType == ContactTypeEnum.LegalPerson && !string.IsNullOrEmpty(entity.CompanyName)) ||
                   (entity.ContactType == ContactTypeEnum.NaturalPerson && string.IsNullOrEmpty(entity.CompanyName));
        }
    }
}

