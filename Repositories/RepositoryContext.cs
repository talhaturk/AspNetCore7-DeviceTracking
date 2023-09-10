using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<UserDevices> UserDevices { get; set; }
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
