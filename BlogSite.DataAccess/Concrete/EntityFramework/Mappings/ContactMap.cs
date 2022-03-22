using BlogSite.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.Subject).IsRequired().HasColumnType("nvarchar(200)");
            builder.Property(x => x.Message).HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");
        }
    }
}
