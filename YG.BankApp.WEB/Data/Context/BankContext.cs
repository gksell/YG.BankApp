using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Configurations;
using YG.BankApp.WEB.Data.Entities;

namespace YG.BankApp.WEB.Data.Context
{

    public class BankContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public BankContext(DbContextOptions<BankContext> options):base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationUserConfirugation());
            modelBuilder.ApplyConfiguration(new AccountConfirugation());
            base.OnModelCreating(modelBuilder);
        }
    }
}
