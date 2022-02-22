using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Validations;
using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.ViewModels
{
    public class MemberEditViewModel : IMemberViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [CheckName]
        public string FirstName { get; set; }

        [Required]
        [CheckName]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^(?<date>\d{6}|\d{8})[-\s]?\d{4}$",
                           ErrorMessage = "PersonNr is indicated by 10 eller 12 digits (yymmddnnnn eller yyyymmddnnnn)")]
        [CheckAge]
        public string PersonNr { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

    }
}
