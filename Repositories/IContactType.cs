
using ModelsContactType.ContactTyp;
namespace RepositoriesIContactType.IContactType
{
    public interface IContactType
    {
        public Task Save(ContactType contactType);
        public Task Delete(int contactType);
        public Task<ContactType> GetById(int contactType);
        public Task<ContactType> Update(int IdcontactType, ContactType ContactType);
        public ICollection<ContactType> GetAll();

    }
}