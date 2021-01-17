using ContactManagement.Domain;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the adress line 1 was filled
    /// </summary>
    class AddressLine1ValidSpec : ISpecification<Contact>
    {
        public bool IsSatisfiedBy(Contact entity)
        {
            return !string.IsNullOrEmpty(entity.AddressLine1);
        }
    }
}

