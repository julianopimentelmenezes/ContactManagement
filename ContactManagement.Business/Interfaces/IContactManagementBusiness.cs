using ContactManagement.Common.ViewModels;
using ContactManagement.Common.ViewModels.Bases;

namespace ContactManagement.Business.Interfaces
{
    /// <summary>
    /// Interface responsible for business services
    /// This interface has all the services of contact management
    /// </summary>
    public interface IContactManagementBusiness
    {
        /// <summary>
        /// This method returns the list of contacts
        /// </summary>
        ContactsResponseViewModel GetContacts();

        /// <summary>
        /// This method returns a single contact 
        /// </summary>
        ContactResponseViewModel GetContact(long id);

        /// <summary>
        /// This method create a new contact
        /// </summary>
        BaseResponseViewModel CreateContact(ContactRequestViewModel model);

        /// <summary>
        /// This method update a single contact
        /// </summary>
        BaseResponseViewModel UpdateContact(ContactRequestViewModel model);

        /// <summary>
        /// This method delete a single contact
        /// </summary>
        BaseResponseViewModel DeleteContact(long id);
    }
}
