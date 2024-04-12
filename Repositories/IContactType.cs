
using ModelsContactType.ContactTyp;
namespace RepositoriesIContactType.IContactType
{
    public interface IContactType
    {
        public Task Save(ContactType contactType);
        public void Delete(int contactType);
        public ContactType GetById(int contactType);
        public ContactType Update(int IdcontactType, ContactType ContactType);
        public ICollection<ContactType> GetAll();

    }
}