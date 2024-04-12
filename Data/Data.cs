
using Microsoft.EntityFrameworkCore;
using ModelsAdditionalField.AdditionalField;
using ModelsContacts.Contacs;
using ModelsContactType.ContactTyp;
using ModelsUsers.Users;

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
          public DbSet<User> Users { set; get; }



    }
}