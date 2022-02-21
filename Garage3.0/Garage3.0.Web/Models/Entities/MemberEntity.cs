﻿namespace Garage3._0.Web.Models.Entities
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PersonNr { get; set; }
        public string Email { get; set; }

        //Nav prop
        public ICollection<VehicleEntity> Vehicles { get; set; }
    }
}
