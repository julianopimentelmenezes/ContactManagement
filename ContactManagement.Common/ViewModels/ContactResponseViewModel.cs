using ContactManagement.Common.ViewModels.Bases;

namespace ContactManagement.Common.ViewModels
{
    /// <summary>
    /// This class is responsible to have the contact response fields
    /// </summary>
    public class ContactResponseViewModel
        : BaseResponseViewModel
    {
        public ContactViewModel Contact { get; set; }

    }
}
