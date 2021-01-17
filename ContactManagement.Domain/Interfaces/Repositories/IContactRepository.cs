using System.Collections.Generic;
using DomainValidationCore.Validation;

namespace ContactManagement.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface responsible to the contact repository methods
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
