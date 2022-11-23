using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.DAL.Entities;

namespace TestProject.DAL.Configurations
{
    public class AccountConfig : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Name).IsUnique();
            builder.HasMany(a => a.Incidents).WithOne(b => b.Account).IsRequired();
            builder.HasMany(a => a.Contacts).WithOne(b => b.Account).IsRequired();
        }
    }
}
