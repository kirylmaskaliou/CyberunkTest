using Microsoft.EntityFrameworkCore;

namespace CyberpunkBackend.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
