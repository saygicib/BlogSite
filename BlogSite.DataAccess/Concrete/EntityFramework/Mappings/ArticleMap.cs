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
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.CategoryId).IsRequired();
            builder.Property(x => x.ContentSummary).IsRequired().HasColumnType("nvarchar(500)");
            builder.Property(x => x.CreatedDate).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.UpdatedDate).IsRequired().HasColumnType("datetime");
            builder.Property(x => x.ImageUrl).HasColumnType("nvarchar(100)");
            builder.Property(x => x.MainContent).IsRequired().HasColumnType("nvarchar(MAX)");
            builder.Property(x => x.Title).IsRequired().HasColumnType("nvarchar(100)");
            builder.Property(x => x.ViewCount).IsRequired();

            builder.HasIndex(x => x.CategoryId);

            builder.HasOne(x => x.Category).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
