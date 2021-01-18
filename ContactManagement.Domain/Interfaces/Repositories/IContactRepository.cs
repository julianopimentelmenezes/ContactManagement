using System.Collections.Generic;
using DomainValidationCore.Validation;

namespace ContactManagement.Domain.Interfaces.Repositories
{
    /// <summary>
    /// This interface declare all the contact repository functions
    /// </summary>
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact GetContact(long id);
        void CreateContact(Contact entity);
        void UpdateContact(Contact entity);
        void DeleteContact(long id);
        ValidationResult CanSelect(long id);
        ValidationResult CanCreate(Contact entity);
        ValidationResult CanUpdate(Contact entity);
        ValidationResult CanDelete(long id);
    }
}
