using System.Data.Entity.ModelConfiguration;
using Business.Entities;

namespace Data.Core.Configurations
{
    public class ArticleConfiguration : EntityTypeConfiguration<Article>
    {
        public ArticleConfiguration()
        {
            HasKey(a => a.Id).Property(a => a.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(a => a.Title).HasMaxLength(100);
            Property(a => a.Contents).IsRequired();
            Property(a => a.Author).IsRequired().HasMaxLength(50);
            Property(a => a.Url).IsRequired().HasMaxLength(200);

            Ignore(a => a.ContentLength);
            Ignore(a => a.ExtensionData);
        }
    }
}