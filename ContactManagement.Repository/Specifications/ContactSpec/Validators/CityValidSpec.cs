using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the city was filled
    /// </summary>
    class CityValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return !string.IsNullOrEmpty(entity.City);
        }
    }
}

