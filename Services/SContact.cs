using System.Data.Entity;
using DataDataContext.DataContext;
using ModelsContacts.Contacs;
using RepositoriesIContact.IContact;

namespace ServicesSContact.SContact
{
    public class SContact : IContact
    {
        //dependency injection 
        private readonly DataContext DbContext;
        public SContact(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }
        public void Delete(int contact)
        {
            if (contact == 0)
            {
                throw new ArgumentException("Please check  ");
            }
            else
            {
                var _contact = GetById(contact);
                try
                {
                    if (_contact != null)
                    {
                        this.DbContext.Contacts.Remove(_contact);
                        this.DbContext.SaveChanges();
                    }

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public ICollection<Contact> GetAll() => this.DbContext.Contacts.ToList();


        public Contact GetById(int contact)
        {
            if (contact < 0 || contact == 0)
            {
                throw new Exception("PLease check");
            }
            else
            {


                return this.DbContext.Contacts.FirstOrDefault(p => p.Id_Contact == contact);
            }
        }

        public async Task Save(Contact contact)
        {
            if (contact.ContactType == 0 || contact.Comments == "" || contact.AdditionalField1 == ""
            || contact.Name == "" || contact.AdditionalField2 == "" || contact.PhoneNumber == "")
            {
                throw new Exception("Please check the data ");
            }
            else
            {
                try
                {
                    await this.DbContext.Contacts.AddAsync(contact);
                    this.DbContext.SaveChanges();
                }
                catch (System.Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

        }

        public Contact Update(int Idcontact, Contact contact)
        {
            if (Idcontact == 0)
            {
                throw new Exception("Please check the value of the id");
            }
            else
            {
                var CFound = GetById(Idcontact);
                if (CFound == null)
                {
                    throw new Exception("contact not found");
                }
                else
                {
                    CFound.Name = contact.Name;
                    CFound.AdditionalField1 = contact.AdditionalField1;
                    CFound.AdditionalField2 = contact.AdditionalField2;
                    CFound.PhoneNumber = contact.PhoneNumber;
                    CFound.ContactType = contact.ContactType;
                    CFound.Comments = contact.Comments;
                    //Save the changes 
                    this.DbContext.SaveChanges();
                    return CFound;
                }
            }
        }
    }
}