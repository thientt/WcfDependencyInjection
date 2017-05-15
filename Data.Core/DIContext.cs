using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using Business.Entities;
using Data.Core.Configurations;

namespace Data.Core
{
    public class DIContext : DbContext
    {
        public DIContext() : base("DIContext")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public virtual DbSet<Article> ArticleSet { get; set; }
        public virtual DbSet<Blog> BlogSet { get; set; }

        public virtual void Commit()
        {
            SaveChanges();
        }

        public virtual Task CommitAsync()
        {
            return SaveChangesAsync();
        }

        public virtual int Push()
        {
            return SaveChanges();
        }

        public virtual Task<int> PushAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new BlogConfiguration());
            modelBuilder.Configurations.Add(new ArticleConfiguration());
        }
    }
}