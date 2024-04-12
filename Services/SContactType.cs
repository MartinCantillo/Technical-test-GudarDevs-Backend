using System.Data.Entity;
using DataDataContext.DataContext;
using ModelsContactType.ContactTyp;
using RepositoriesIContactType.IContactType;

namespace ServicesSContactType.SContactType
{
    public class SContactType : IContactType
    {
        //dependency injection 
        private readonly DataContext DbContext;
        public SContactType(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public void Delete(int contactType)
        {
            if (contactType == 0)
            {
                throw new ArgumentException("Please check  ");
            }
            else
            {
                var _contactType = GetById(contactType);
                try
                {
                    if (_contactType != null)
                    {
                        this.DbContext.ContactTypes.Remove(_contactType);
                        this.DbContext.SaveChanges();
                    }

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public ICollection<ContactType> GetAll() => this.DbContext.ContactTypes.ToList();

        public ContactType GetById(int contactType)
        {
            if (contactType == 0 || contactType < 0)
            {
                throw new Exception("Please check the value");

            }
            else
            {
                return this.DbContext.ContactTypes.FirstOrDefault(p => p.Id_ContactType == contactType);
            }
        }
        public async Task Save(ContactType contactType)
        {
            if (contactType.TypeName == "")
            {
                throw new Exception("Please check ");
            }
            else
            {
                try
                {
                    await this.DbContext.ContactTypes.AddAsync(contactType);
                    this.DbContext.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }

            }
        }

        public ContactType Update(int IdcontactType, ContactType ContactType)
        {
            if (IdcontactType == 0)
            {
                throw new Exception("Please check the value of the id");
            }
            else
            {
                var CFound = GetById(IdcontactType);
                if (CFound == null)
                {
                    throw new Exception("ContactType not found");
                }
                else
                {
                    CFound.TypeName = ContactType.TypeName;
                    //Save the changes 
                    this.DbContext.SaveChanges();
                    return CFound;
                }
            }
        }
    }
}