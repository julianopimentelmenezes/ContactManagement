using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the zip code was filled
    /// </summary>
    public class ZipCodeValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return !string.IsNullOrEmpty(entity.ZipCode);
        }
    }
}

