﻿using System.ComponentModel.DataAnnotations;

namespace Garage3._0.Web.Models.Entities
{
    public class MemberEntity
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Name => $"{FirstName} {LastName}";
        [Required]
        public string PersonNr { get; set; }
        [Required]
        public string Email { get; set; }

        //Nav prop
        public ICollection<VehicleEntity> Vehicles { get; set; } = new List<VehicleEntity>();

        private MemberEntity()
        {
            FirstName = null!;
            LastName = null!;
            PersonNr = null!;
        }
        public MemberEntity(string firstName, string lastName, string persnr, string email)
        {
            FirstName =firstName;
            LastName =lastName;
            PersonNr = persnr;
            Email =email;
        }

    }
}
