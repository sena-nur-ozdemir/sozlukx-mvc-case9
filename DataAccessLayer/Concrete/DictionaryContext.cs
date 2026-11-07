
using System.Data.Entity;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class DictionaryContext : DbContext
    {
        public DictionaryContext()
            : base("name=DictionaryContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ImageFile> ImageFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Heading>()
                .HasRequired(h => h.Category)
                .WithMany(c => c.Headings)
                .HasForeignKey(h => h.CategoryID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Heading>()
                .HasRequired(h => h.Writer)
                .WithMany(w => w.Headings)
                .HasForeignKey(h => h.WriterID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Content>()
                .HasRequired(c => c.Heading)
                .WithMany(h => h.Contents)
                .HasForeignKey(c => c.HeadingID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Content>()
                .HasRequired(c => c.Writer)
                .WithMany(w => w.Contents)
                .HasForeignKey(c => c.WriterID)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
