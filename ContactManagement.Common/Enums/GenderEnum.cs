using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Common.Enums
{
    /// <summary>
    /// This enumeration class store the gender options
    /// </summary>
    public enum GenderEnum
    {
        [Display(Description = "UNDEFINED")]
        Undefined = 0,
        [Display(Description = "MALE")]
        Male = 1,
        [Display(Description = "FEMALE")]
        Female = 2,
        [Display(Description = "NON-BINARY")]
        NonBinary = 3
    }
}
