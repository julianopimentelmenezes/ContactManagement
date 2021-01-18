using ContactManagement.Common.ViewModels;
using ContactManagement.Common.ViewModels.Bases;

namespace ContactManagement.Business.Interfaces
{
    /// <summary>
    /// This interface declare all the contact management business services
    /// </summary>
    public interface IContactManagementBusiness
    {
        /// <summary>
        /// Get the contact list 
        /// </summary>
        /// <returns>Object containing the list of contacts<see cref="ContactsResponseViewModel"/></returns>
        ContactsResponseViewModel GetContacts();

        /// <summary>
        /// Get a single contact by ID
        /// </summary>
        /// <param name="id">Table identifier</param>
        /// <returns>Object containing a single contact<see cref="ContactResponseViewModel"/></returns>
        ContactResponseViewModel GetContact(long id);

        /// <summary>
        /// Create a new contact
        /// </summary>
        /// <param name="model">Object containing the contact fields<see cref="ContactRequestViewModel"/></param>
        /// <returns>Object containing the result informations<see cref="BaseResponseViewModel"/></returns>
        BaseResponseViewModel CreateContact(ContactRequestViewModel model);

        /// <summary>
        /// Update a contact
        /// </summary>
        /// <param name="model">Object containing the contact fields<see cref="ContactRequestViewModel"/></param>
        /// <returns>Object containing the result informations<see cref="BaseResponseViewModel"/></returns>
        BaseResponseViewModel UpdateContact(ContactRequestViewModel model);

        /// <summary>
        /// Delete a contact
        /// </summary>
        /// <param name="id">Table identifier</param>
        /// <returns>Object containing the result informations<see cref="BaseResponseViewModel"/></returns>
        BaseResponseViewModel DeleteContact(long id);
    }
}
