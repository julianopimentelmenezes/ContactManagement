using ContactManagement.Domain;
using ContactManagement.Domain.Interfaces.Repositories;
using DomainValidationCore.Interfaces.Specification;

namespace ContactManagement.Repository.Specifications.ContactSpec.Validators
{
    /// <summary>
    /// This class validate if the contact exists in the database
    /// </summary>
    public class ContactExistSpec
        : ISpecification<Contact>
    {

        readonly IContactRepository _contactRepository;

        public ContactExistSpec(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public bool IsSatisfiedBy(Contact entity)
        {
            var contact = _contactRepository.GetContact(entity.ContactId);

            return contact != null;
        }
    }
}

