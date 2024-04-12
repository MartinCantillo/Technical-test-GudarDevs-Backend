


using ModelsContacts.Contacs;

namespace RepositoriesIContact.IContact
{
    public interface IContact
    {
        public Task Save(Contact contact);
        public void Delete(int contact);
        public Contact GetById(int contact);
        public Contact Update(int Idcontact, Contact contact);
        public ICollection<Contact> GetAll();

    }
}