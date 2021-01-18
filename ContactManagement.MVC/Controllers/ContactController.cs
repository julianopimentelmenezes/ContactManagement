using ContactManagement.Common.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement.MVC.Controllers
{
    /// <summary>
    /// This is the web application controller
    /// </summary>
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _basePathUrlAPI;

        /// <summary>
        /// The constructor initialize the base path url API
        /// This property is used to use de API services
        /// </summary>
        public ContactController(ILogger<ContactController> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _basePathUrlAPI = _configuration.GetValue<string>("BasePathUrlAPI");
        }

        /// <summary>
        /// This is the home page
        /// When the application initialize, is showed the contact list
        /// This function call the API get contact list function
        /// </summary>
        public async Task<IActionResult> Index()
        {
            try
            {
                if (!string.IsNullOrEmpty(_basePathUrlAPI))
                {
                    HttpClient httpClient = _httpClientFactory.CreateClient();
                    httpClient.BaseAddress = new Uri(_basePathUrlAPI);
                    HttpResponseMessage response = await httpClient.GetAsync("api/v1/ContactManagement/GetContacts");

                    if (response.IsSuccessStatusCode)
                    {
                        var contactList = JsonConvert.DeserializeObject<ContactsResponseViewModel>(response.Content.ReadAsStringAsync().Result);

                        return View(contactList.Contacts);
                    }
                    else
                    {
                        var message = $"An error has occurred when tried to get the contact list. Response status code [{response.StatusCode}]";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                else
                {
                    var message = "Tag BasePathUrlAPI not found.";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message
                            }));
                }
            }
            catch (Exception ex)
            {
                var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                _logger.LogError(message);

                return RedirectToAction("Error", "Contact",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Contact",
                            action = "Error",
                            message = message.Substring(1, 1000)
                        }));
            }

        }

        /// <summary>
        /// This is the detail page
        /// It will show the contact detail
        /// This function call the API get contact function
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!string.IsNullOrEmpty(_basePathUrlAPI))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{_basePathUrlAPI}/api/v1/ContactManagement/GetContact");
                    request.Headers.Add("id", id != null ? id.ToString() : string.Empty);

                    HttpClient httpClient = _httpClientFactory.CreateClient();

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var contact = JsonConvert.DeserializeObject<ContactResponseViewModel>(response.Content.ReadAsStringAsync().Result);

                        return View(contact.Contact);
                    }
                    else
                    {
                        var message = $"An error has occurred when tried to get the contact id [{id}]. Response status code [{response.StatusCode}]";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                else
                {
                    var message = "Tag BasePathUrlAPI not found.";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message
                            }));
                }
            }
            catch (Exception ex)
            {
                var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                _logger.LogError(message);

                return RedirectToAction("Error", "Contact",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Contact",
                            action = "Error",
                            message = message.Substring(1, 1000)
                        }));
            }

        }

        /// <summary>
        /// This is the create page
        /// It will open a page with contact fields. All the fields are empty.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// This function will call the API create function to create a new contact
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactType,Name,CompanyName,TradeName,Cpf,Cnpj,Birthday,Gender,ZipCode,Country,State,City,AddressLine1,AddressLine2")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(_basePathUrlAPI))
                    {
                        HttpClient httpClient = _httpClientFactory.CreateClient();
                        httpClient.BaseAddress = new Uri(_basePathUrlAPI);

                        var contactViewModelJson = new StringContent(JsonConvert.SerializeObject(contactViewModel), Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await httpClient.PostAsync("api/v1/ContactManagement/CreateContact", contactViewModelJson);

                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Contact");
                        }
                        else
                        {
                            var message = $"An error has occurred when tried to create the contact list. Response status code [{response.StatusCode}]";

                            _logger.LogError(message);

                            return RedirectToAction("Error", "Contact",
                                new RouteValueDictionary(
                                    new
                                    {
                                        controller = "Contact",
                                        action = "Error",
                                        message
                                    }));
                        }
                    }
                    else
                    {
                        var message = "Tag BasePathUrlAPI not found.";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                catch (Exception ex)
                {
                    var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message = message.Substring(1, 1000)
                            }));
                }
            }

            return View(contactViewModel);
        }

        /// <summary>
        /// This is the edit page
        /// It will open a page with contact fields. All the fields are filled when have data.
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!string.IsNullOrEmpty(_basePathUrlAPI))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{_basePathUrlAPI}/api/v1/ContactManagement/GetContact");
                    request.Headers.Add("id", id != null ? id.ToString() : string.Empty);

                    HttpClient httpClient = _httpClientFactory.CreateClient();

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var contact = JsonConvert.DeserializeObject<ContactResponseViewModel>(response.Content.ReadAsStringAsync().Result);

                        return View(contact.Contact);
                    }
                    else
                    {
                        var message = $"An error has occurred when tried to get the contact id [{id}]. Response status code [{response.StatusCode}]";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                else
                {
                    var message = "Tag BasePathUrlAPI not found.";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message
                            }));
                }
            }
            catch (Exception ex)
            {
                var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                _logger.LogError(message);

                return RedirectToAction("Error", "Contact",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Contact",
                            action = "Error",
                            message = message.Substring(1, 1000)
                        }));
            }
        }

        /// <summary>
        /// This function will call the API update function to update a contact
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("ContactId,ContactType,Name,CompanyName,TradeName,Cpf,Cnpj,Birthday,Gender,ZipCode,Country,State,City,AddressLine1,AddressLine2")] ContactViewModel contactViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(_basePathUrlAPI))
                    {
                        HttpClient httpClient = _httpClientFactory.CreateClient();
                        httpClient.BaseAddress = new Uri(_basePathUrlAPI);

                        var contactViewModelJson = new StringContent(JsonConvert.SerializeObject(contactViewModel), Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await httpClient.PutAsync("api/v1/ContactManagement/UpdateContact", contactViewModelJson);

                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Contact");
                        }
                        else
                        {
                            var message = $"An error has occurred when tried to get the contact list. Response status code [{response.StatusCode}]";

                            _logger.LogError(message);

                            return RedirectToAction("Error", "Contact",
                                new RouteValueDictionary(
                                    new
                                    {
                                        controller = "Contact",
                                        action = "Error",
                                        message
                                    }));
                        }
                    }
                    else
                    {
                        var message = "Tag BasePathUrlAPI not found.";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                catch (Exception ex)
                {
                    var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message = message.Substring(1, 1000)
                            }));
                }
            }

            return View(contactViewModel);
        }

        /// <summary>
        /// This is the delete page
        /// It will open a page with the contact details to confirm if the contact will be deleted
        /// </summary>
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!string.IsNullOrEmpty(_basePathUrlAPI))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, $"{_basePathUrlAPI}/api/v1/ContactManagement/GetContact");
                    request.Headers.Add("id", id != null ? id.ToString() : string.Empty);

                    HttpClient httpClient = _httpClientFactory.CreateClient();

                    HttpResponseMessage response = await httpClient.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var contact = JsonConvert.DeserializeObject<ContactResponseViewModel>(response.Content.ReadAsStringAsync().Result);

                        return View(contact.Contact);
                    }
                    else
                    {
                        var message = $"An error has occurred when tried to get the contact id [{id}]. Response status code [{response.StatusCode}]";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                else
                {
                    var message = "Tag BasePathUrlAPI not found.";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message
                            }));
                }
            }
            catch (Exception ex)
            {
                var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                _logger.LogError(message);

                return RedirectToAction("Error", "Contact",
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Contact",
                            action = "Error",
                            message = message.Substring(1, 1000)
                        }));
            }
        }

        /// <summary>
        /// This function will call the API delete function to delete a contact
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(_basePathUrlAPI))
                    {
                        var request = new HttpRequestMessage(HttpMethod.Delete, $"{_basePathUrlAPI}/api/v1/ContactManagement/DeleteContact");
                        request.Headers.Add("id", id.ToString());

                        HttpClient httpClient = _httpClientFactory.CreateClient();

                        HttpResponseMessage response = await httpClient.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Index", "Contact");
                        }
                        else
                        {
                            var message = $"An error has occurred when tried to get the contact list. Response status code [{response.StatusCode}]";

                            _logger.LogError(message);

                            return RedirectToAction("Error", "Contact",
                                new RouteValueDictionary(
                                    new
                                    {
                                        controller = "Contact",
                                        action = "Error",
                                        message
                                    }));
                        }
                    }
                    else
                    {
                        var message = "Tag BasePathUrlAPI not found.";

                        _logger.LogError(message);

                        return RedirectToAction("Error", "Contact",
                            new RouteValueDictionary(
                                new
                                {
                                    controller = "Contact",
                                    action = "Error",
                                    message
                                }));
                    }
                }
                catch (Exception ex)
                {
                    var message = $"Error: {ex.Message}.{(ex.InnerException == null ? string.Empty : ex.InnerException.Message)}";

                    _logger.LogError(message);

                    return RedirectToAction("Error", "Contact",
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Contact",
                                action = "Error",
                                message = message.Substring(1, 1000)
                            }));
                }
            }

            return View();
        }

        /// <summary>
        /// This is the error page
        /// It will open a page with the error details.
        /// </summary>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }
    }
}
