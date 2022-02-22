using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Validations;

namespace Garage3._0.Web.Models.ViewModels
{
    public class MemberEditViewModel : IMemberViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        [CheckName]
        public string LastName { get; set; }
        //[CheckAge]
        public string PersonNr { get; set; }
        public string Email { get; set; }

    }
}
