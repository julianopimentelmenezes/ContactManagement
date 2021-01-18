using ContactManagement.Common.ViewModels.Bases;
using System.Collections.Generic;

namespace ContactManagement.Common.ViewModels
{
    /// <summary>
    /// This class is responsible to have the response list of contact
    /// </summary>
    public class ContactsResponseViewModel
        : BaseResponseViewModel
    {

        public ContactsResponseViewModel()
        {
            Contacts = new HashSet<ContactViewModel>();
        }

        public ICollection<ContactViewModel> Contacts { get; set; }

    }
}
