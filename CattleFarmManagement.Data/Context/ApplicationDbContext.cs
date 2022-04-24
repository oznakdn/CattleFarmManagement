using CattleFarmManagement.Shared.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Context
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Cow> Cows { get; set; }
        public DbSet<CowPicture> CowPictures { get; set; }

        public DbSet<Bull> Bulls { get; set; }
        public DbSet<BullPicture> BullPictures { get; set; }


        public DbSet<Calving> Calvings { get; set; }
        public DbSet<CalvPicture> CalvPictures { get; set; }

        public DbSet<Borning> Bornings { get; set; }
        public DbSet<MilkRecord> MilkRecords { get; set; }
        public DbSet<Lactation> Lactations { get; set; }
        public DbSet<Yield> Yields { get; set; }
        public DbSet<Semination> Seminations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeContact> EmployeeContacts { get; set; }


    }
}
