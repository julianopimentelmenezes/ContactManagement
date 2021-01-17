using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Common.Enums
{
    /// <summary>
    /// This enumeration class store the contact type options
    /// </summary>
    public enum ContactTypeEnum
    {
        [Display(Description = "UNDEFINED")]
        Undefined = 0,
        [Display(Description = "NATURAL PERSON")]
        NaturalPerson = 1,
        [Display(Description = "LEGAL PERSON")]
        LegalPerson = 2
    }
}
