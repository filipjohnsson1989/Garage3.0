using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Validations;

namespace Garage3._0.Web.Models.ViewModels
{
    public class MemberCreateViewModel
    {
        public string FirstName { get; set; }

        [CheckName]
        public string LastName { get; set; }   
        public int PersonNr { get; set; }
        public string Email { get; set; }
        
    }
}
