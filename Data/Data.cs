
using Microsoft.EntityFrameworkCore;
using ModelsAdditionalField.AdditionalField;
using ModelsContacts.Constacs;
using ModelsContactType.ContactTyp;

namespace DataDataContext.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { set; get; }
        public DbSet<AdditionalField> AdditionalFields { set; get; }



    }
}