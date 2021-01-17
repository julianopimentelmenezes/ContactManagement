using ContactManagement.Business.Interfaces;
using ContactManagement.Common.ViewModels;
using ContactManagement.Common.ViewModels.Bases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace ContactManagement.API.Controllers
{
    /// <summary>
    /// This class is the controller who has the API services
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactManagementController : Controller
    {
        private readonly ILogger<ContactManagementController> _logger;

        private readonly IContactManagementBusiness _contactManagementBusiness;

        public ContactManagementController(ILogger<ContactManagementController> logger,
                                           IContactManagementBusiness contactManagementBusiness)
        {
            _logger = logger;
            _contactManagementBusiness = contactManagementBusiness;
        }

        [HttpGet]
        [Route("GetContacts")]
        [ProducesResponseType(typeof(ContactsResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult GetContacts()
        {
            var result = new ContactsResponseViewModel()
            {
                Sucess = false
            };

            try
            {
                _logger.LogInformation($"Starting get contacts service.");

                result = _contactManagementBusiness.GetContacts();

                if (result.Sucess)
                {
                    return Ok(result);
                }

                foreach (var message in result.Messages)
                {
                    _logger.LogError(message);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to call get contact list service. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpGet]
        [Route("GetContact")]
        [ProducesResponseType(typeof(ContactResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult GetContact([FromHeader] long id)
        {
            BaseResponseViewModel result = new ContactResponseViewModel()
            {
                Sucess = false
            };

            try
            {
                _logger.LogInformation($"Starting get contact service. Contact id [{id}].");

                result = _contactManagementBusiness.GetContact(id);

                if (result.Sucess)
                {
                    return Ok(result);
                }

                foreach (var message in result.Messages)
                {
                    _logger.LogError(message);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to call get contact service. Contact id [{id}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpPost]
        [Route("CreateContact")]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult CreateContact([FromBody] ContactRequestViewModel model)
        {
            BaseResponseViewModel result = new ContactResponseViewModel()
            {
                Sucess = false
            };

            try
            {
                _logger.LogInformation($"Starting create contact service. Contact [{JsonConvert.SerializeObject(model)}]");

                result = _contactManagementBusiness.CreateContact(model);

                if (result.Sucess)
                {
                    return Ok(result);
                }

                foreach (var message in result.Messages)
                {
                    _logger.LogError(message);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to call create contact service. Contact [{JsonConvert.SerializeObject(model)}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpPut]
        [Route("UpdateContact")]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateContact([FromBody] ContactRequestViewModel model)
        {
            BaseResponseViewModel result = new ContactResponseViewModel()
            {
                Sucess = false
            };

            try
            {
                _logger.LogInformation($"Starting update contact service. Contact [{JsonConvert.SerializeObject(model)}]");

                result = _contactManagementBusiness.UpdateContact(model);

                if (result.Sucess)
                {
                    return Ok(result);
                }

                foreach (var message in result.Messages)
                {
                    _logger.LogError(message);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to call update contact service. Contact [{JsonConvert.SerializeObject(model)}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

        [HttpDelete]
        [Route("DeleteContact")]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponseViewModel), StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteContact([FromHeader] long id)
        {
            BaseResponseViewModel result = new ContactResponseViewModel()
            {
                Sucess = false
            };

            try
            {
                _logger.LogInformation($"Starting delete contact service. Contact id [{id}]");

                result = _contactManagementBusiness.DeleteContact(id);

                if (result.Sucess)
                {
                    return Ok(result);
                }

                foreach (var message in result.Messages)
                {
                    _logger.LogError(message);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                var message = $"An error has occurred when tried to call delete contact service. Contact id [{id}]. Error message: {ex.Message}";

                _logger.LogCritical(message);

                result.AddMessage(message);

                return StatusCode(StatusCodes.Status500InternalServerError, result);
            }
        }

    }
}
