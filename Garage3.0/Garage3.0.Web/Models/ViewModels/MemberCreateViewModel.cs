﻿using Garage3._0.Web.Models.Entities;
using Garage3._0.Web.Validations;

namespace Garage3._0.Web.Models.ViewModels
{
    public class MemberCreateViewModel : IMemberViewModel
    {
        public string FirstName { get; set; }

        [CheckName]
        public string LastName { get; set; }
        public string PersonNr { get; set; }
        public string Email { get; set; }

    }
}
