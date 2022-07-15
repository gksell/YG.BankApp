﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YG.BankApp.WEB.Data.Entities;

namespace YG.BankApp.WEB.Data.Configurations
{
    public class AccountConfirugation : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(x => x.AccountNumber).IsRequired();
            builder.Property(x => x.Balance).HasColumnType("decimal(18,4)");
            builder.Property(x => x.Balance).IsRequired();

            
        }
    }
}
