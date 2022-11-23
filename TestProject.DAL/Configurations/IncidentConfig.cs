using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.DAL.Entities;

namespace TestProject.DAL.Configurations
{
    public class IncidentConfig: IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.HasKey(p => p.Name);
            builder.Property(p => p.Name).ValueGeneratedOnAdd();
        }
    }
}
