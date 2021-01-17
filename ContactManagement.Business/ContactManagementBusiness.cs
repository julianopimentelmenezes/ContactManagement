using AutoMapper;
using ContactManagement.Business.Interfaces;
using Microsoft.Extensions.Logging;
using ContactManagement.Domain.Interfaces.Repositories;
using ContactManagement.Common.ViewModels.Bases;
using System.Collections.Generic;
using ContactManagement.Common.ViewModels;
using System;
using System.Linq;
using Newtonsoft.Json;
using ContactManagement.Domain;

namespace ContactManagement.Business
{
    /// <summary>
    /// Class responsible for business services
    /// This class has all the services of contact management
    /// </summary>
    public class ContactManagementBusiness : IContactManagementBusiness
    {
        readonly ILogger<ContactManagementBusiness> _logger;
        readonly IMapper _mapper;
        readonly IContactRepository _contactRepository;
        public ContactManagementBusiness(ILoggerFactory loggerFactory,
                                         IMapper mapper,
                                         IContactRepository contactRepository)
        {
            _logger = loggerFactory.CreateLogger<ContactManagementBusiness>();

            _mapper = mapper;
            _contactRepository = contactRepository;
        }

        public ContactsResponseViewModel GetContacts()
        {
            var result = new ContactsResponseViewModel()
            {
                Sucess = false
            };

            _logger.LogInformation($"Getting contact list.");

            try
            {
                var contacts = _contactRepository.GetContacts();

                if (contacts.Count() > 0)
                {
                    result.Contacts = _mapper.Map<IList<ContactViewModel>>(contacts);
                }

                _logger.LogInformation($"Contact list returned with {result.Contacts.Count()} rows.");

                result.Sucess = true;

                return result;
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to get the contact list. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return result;
            }
        }

        public ContactResponseViewModel GetContact(long id)
        {
            var result = new ContactResponseViewModel()
            {
                Sucess = false
            };

            _logger.LogInformation($"Getting contact id {id}.");

            try
            {
                var validationResult = _contactRepository.CanSelect(id);

                if (validationResult.IsValid)
                {
                    var contact = _contactRepository.GetContact(id);

                    result.Contact = _mapper.Map<ContactViewModel>(contact);

                    _logger.LogInformation($"Contact id {result.Contact.ContactId} returned successfully.");

                    result.Sucess = true;
                }
                else
                {
                    _logger.LogError(string.Join(", ", validationResult.Errors.Select(e => e.Message))); 
                    
                    result.AddMessages(validationResult.Errors.Select(e => e.Message));
                }

                return result;
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to get contact id {id}. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return result;
            }
        }

        public BaseResponseViewModel CreateContact(ContactRequestViewModel model)
        {
            var result = new BaseResponseViewModel()
            {
                Sucess = false
            };

            _logger.LogInformation($"Create contact [{JsonConvert.SerializeObject(model)}]");

            try
            {
                var contact = _mapper.Map<Contact>(model);

                var validationResult = _contactRepository.CanCreate(contact);

                if (validationResult.IsValid)
                {
                    _contactRepository.CreateContact(contact);

                    _logger.LogInformation($"Contact [{JsonConvert.SerializeObject(model)}] added successfully.");

                    result.Sucess = true;
                }
                else
                {
                    _logger.LogError(string.Join(", ", validationResult.Errors.Select(e => e.Message)));

                    result.AddMessages(validationResult.Errors.Select(e => e.Message));
                }

                return result;
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to add contact [{JsonConvert.SerializeObject(model)}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return result;
            }
        }

        public BaseResponseViewModel UpdateContact(ContactRequestViewModel model)
        {
            var result = new BaseResponseViewModel()
            {
                Sucess = false
            };

            _logger.LogInformation($"Update contact [{JsonConvert.SerializeObject(model)}]");

            try
            {
                var contact = _mapper.Map<Contact>(model);

                var validationResult = _contactRepository.CanUpdate(contact);

                if (validationResult.IsValid)
                {
                    _contactRepository.UpdateContact(contact);

                    _logger.LogInformation($"Contact [{JsonConvert.SerializeObject(model)}] updated successfully.");

                    result.Sucess = true;
                }
                else
                {
                    _logger.LogError(string.Join(", ", validationResult.Errors.Select(e => e.Message)));

                    result.AddMessages(validationResult.Errors.Select(e => e.Message));
                }

                return result;
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to update [{JsonConvert.SerializeObject(model)}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return result;
            }
        }

        public BaseResponseViewModel DeleteContact(long id)
        {
            var result = new BaseResponseViewModel()
            {
                Sucess = false
            };

            _logger.LogInformation($"Delete contact id {id}");

            try
            {
                var validationResult = _contactRepository.CanDelete(id);

                if (validationResult.IsValid)
                {
                    _contactRepository.DeleteContact(id);

                    _logger.LogInformation($"Contact id {id} deleted successfully.");

                    result.Sucess = true;
                }
                else
                {
                    _logger.LogError(string.Join(", ", validationResult.Errors.Select(e => e.Message)));

                    result.AddMessages(validationResult.Errors.Select(e => e.Message));
                }

                return result;
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to delete contact id {id}. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return result;
            }
        }
    }
}
