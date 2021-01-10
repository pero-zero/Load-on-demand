using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Load_on_demand.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Load_on_demand.Models.ŠifrarnikDržava> ŠifrarnikDržava { get; set; }
        public DbSet<Load_on_demand.Models.Naselje> Naselja { get; set; }
    }
}
