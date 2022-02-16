#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage3._0.Web.Models.Entities;

namespace Garage3._0.Web.Data
{
    public class Garage3_0WebContext : DbContext
    {
        public Garage3_0WebContext (DbContextOptions<Garage3_0WebContext> options)
            : base(options)
        {
        }

        public DbSet<Garage3._0.Web.Models.Entities.MemberEntity> MemberEntity { get; set; }
    }
}
