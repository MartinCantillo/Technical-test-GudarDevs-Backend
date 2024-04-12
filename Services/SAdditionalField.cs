using System.Data.Entity;
using DataDataContext.DataContext;
using ModelsAdditionalField.AdditionalField;
using RepositoriesIAdditionalField.IAdditionalField;

namespace ServicesSAdditionalField.SAdditionalField
{
    public class SAdditionalField : IAdditionalField
    {
        //dependency injection 
        private readonly DataContext DbContext;
        public SAdditionalField(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public void Delete(int additionalField)
        {
            if (additionalField == 0)
            {
                throw new ArgumentException("Please check  ");
            }
            else
            {
                var _additionalField = GetById(additionalField);
                try
                {
                    if (_additionalField != null)
                    {
                        this.DbContext.AdditionalFields.Remove(_additionalField);
                        this.DbContext.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Not Found");
                    }

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public ICollection<AdditionalField> GetAll() => this.DbContext.AdditionalFields.ToList();

        public AdditionalField GetById(int additionalField)
        {
            if (additionalField == 0 || additionalField < 0)
            {
                throw new Exception("Please check ");
            }
            else
            {
                Console.WriteLine("paso");

                return this.DbContext.AdditionalFields.FirstOrDefault(p => p.Id_AdditionalField == additionalField);
            }
        }

        public async Task Save(AdditionalField additionalField)
        {
            if (additionalField.FieldName == "" || additionalField.FieldType == "")
            {
                throw new Exception("Please check ");
            }
            else
            {
                try
                {
                    await this.DbContext.AdditionalFields.AddAsync(additionalField);
                    this.DbContext.SaveChanges();
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public AdditionalField Update(int id, AdditionalField additionalField)
        {
            if (id == 0)
            {
                throw new Exception("Please check the value of the id");
            }
            else
            {
                var AFound = GetById(id);
                if (AFound == null)
                {
                    throw new Exception("AdditionalField not found");
                }
                else
                {
                    //Update the values
                    AFound.FieldName = additionalField.FieldName;
                    AFound.FieldType = additionalField.FieldType;
                    try
                    {
                        //Save the changes 
                        this.DbContext.SaveChanges();
                    }
                    catch (System.Exception e)
                    {

                        throw new Exception(e.Message);
                    }

                    return AFound;
                }
            }
        }
    }

}