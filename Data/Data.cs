
using Microsoft.EntityFrameworkCore;

using ModelsContacts.Contacs;

using ModelsUsers.Users;

namespace DataDataContext.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       
        public DbSet<Contact> Contacts { set; get; }

        public DbSet<User> Users { set; get; }



    }
}