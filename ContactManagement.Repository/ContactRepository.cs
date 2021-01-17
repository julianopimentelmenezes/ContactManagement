using ContactManagement.Domain;
using ContactManagement.Domain.Data;
using ContactManagement.Domain.Interfaces.Repositories;
using ContactManagement.Repository.Specifications.ContactSpec;
using DomainValidationCore.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.Repository
{

    /// <summary>
    /// This class implements contact repository methods
    /// </summary>
    public class ContactRepository: IContactRepository
    {
        private ContactManagementContext _context;
        readonly ILogger _logger;

        public ContactRepository(ContactManagementContext context, ILoggerFactory loggerFactory)
        {
            _context = context;

            _logger = loggerFactory.CreateLogger<ContactRepository>();
        }
        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts.ToList();
        }
        public Contact GetContact(long id)
        {
            var contact = _context.Contacts.AsNoTracking().SingleOrDefault(m => m.ContactId == id);

            foreach (var entity in _context.ChangeTracker.Entries())
            {
                entity.State = EntityState.Detached;
            }

            return contact;

            
        }
        public void CreateContact(Contact entity)
        {
            _context.Add(entity);

            _context.SaveChanges();
        }
        public void UpdateContact(Contact entity)
        {
            _context.Update(entity);

            _context.SaveChanges();

        }
        public void DeleteContact(long id)
        {
            _context.Remove(new Contact { ContactId = id });

            _context.SaveChanges();
        }
        public ValidationResult CanSelect(long id)
        {
            try
            {
                return new ContactCanSelectValidation(this).Validate(new Contact { ContactId = id });
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An unexpected error occurred when tried to validate a contact. Contact id {id}. Error message: {ex.Message}");

                throw;
            }
        }
        public ValidationResult CanCreate(Contact entity)
        {
            try
            {
                return new ContactCanCreateValidation(this).Validate(entity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An unexpected error occurred when tried to validate a contact in the create method. Contact [{JsonConvert.SerializeObject(entity)}]. Error message: {ex.Message}");

                throw;
            }
        }
        public ValidationResult CanUpdate(Contact entity)
        {
            try
            {
                return new ContactCanUpdateValidation(this).Validate(entity);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An unexpected error occurred when tried to select a contact in the update method. Contact [{JsonConvert.SerializeObject(entity)}]. Error message: {ex.Message}");

                throw;
            }
        }
        public ValidationResult CanDelete(long id)
        {
            try
            {
                return new ContactCanDeleteValidation(this).Validate(new Contact { ContactId = id });
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"An unexpected error occurred when tried to select a contact in the delete method. Contact id {id}. Error message: {ex.Message}");

                throw;
            }
        }
    }
}
