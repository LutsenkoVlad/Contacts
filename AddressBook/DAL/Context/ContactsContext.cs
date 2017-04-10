using AddressBook.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

namespace DAL.Context
{
    public class ContactsContext : DbContext
    {
        public ContactsContext()
            : base("name=ContactsContext")
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
        public virtual DbSet<QuickList> QuickLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<QuickList>().Property(l => l.Name).IsRequired();

            #region Contact configuration
            modelBuilder.Entity<Contact>().Property(c => c.FirstName).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.LastName).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.City).IsRequired();
            modelBuilder.Entity<Contact>().Property(c => c.Email)
                                         .IsRequired()
                                         .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                                          new IndexAnnotation(new IndexAttribute("IX_Email", 1) { IsUnique = true }))
                                          .HasMaxLength(350);
            modelBuilder.Entity<Contact>().Property(c => c.Address).IsRequired();
            #endregion

            modelBuilder.Entity<PhoneType>().Property(t => t.Name).IsRequired();

            modelBuilder.Entity<Phone>().Property(p => p.Number).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}