


using ModelsContacts.Contacs;

namespace RepositoriesIContact.IContact
{
    public interface IContact
    {
        public Task Save(Contact contact);
        public Task Delete(int contact);
        public Task<Contact> GetById(int contact);
        public Task<Contact> Update(int Idcontact, Contact contact);
        public ICollection<Contact> GetAll();

    }
}