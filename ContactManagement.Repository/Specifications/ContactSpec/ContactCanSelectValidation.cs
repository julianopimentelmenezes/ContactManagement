using ContactManagement.Domain;
using ContactManagement.Domain.Interfaces.Repositories;
using ContactManagement.Repository.Specifications.ContactSpec.Validators;
using DomainValidationCore.Validation;

namespace ContactManagement.Repository.Specifications.ContactSpec
{
    /// <summary>
    /// This class call all the contact validations to the Select functionality
    /// </summary>
    public class ContactCanSelectValidation
        : Validator<Contact>
    {
        public ContactCanSelectValidation(IContactRepository contactRepository)
        {
            var contactExistValid = new ContactExistSpec(contactRepository);

            base.Add("IdContactValid", new Rule<Contact>(contactExistValid, "Contact ID invalid."));
        }

    }
}
