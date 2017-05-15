using System.Data.Entity.ModelConfiguration;
using Business.Entities;

namespace Data.Core.Configurations
{
    public class BlogConfiguration : EntityTypeConfiguration<Blog>
    {
        public BlogConfiguration()
        {
            HasKey(a => a.Id);
            Property(a => a.Name).IsRequired().HasMaxLength(100).HasColumnName("Name");
            Property(a => a.Owner).IsRequired().HasMaxLength(50).HasColumnName("Owner");
            Property(a => a.Url).IsRequired().HasMaxLength(200).HasColumnName("Url");

            Ignore(a => a.ExtensionData);
        }
    }
}