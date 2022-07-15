using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;

namespace YG.BankApp.WEB.Data.Configurations
{
    public class ApplicationUserConfirugation : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(200);
            builder.Property(x => x.Surname).IsRequired();

            builder.HasMany(x => x.Accounts)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);
        }
    }
}
