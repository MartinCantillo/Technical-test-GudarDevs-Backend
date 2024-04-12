using System.Data.Entity;
using DataDataContext.DataContext;
using ModelsAdditionalField.AdditionalField;
using RepositoriesIAdditionalField.IAdditionalField;

namespace ServicesSAdditionalField.SAdditionalField
{
    public class SAdditionalField : IAdditionalFieldRepository
    {
        //dependency injection 
        private readonly DataContext DbContext;
        public SAdditionalField(DataContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task Delete(int additionalField)
        {
            if (additionalField == 0)
            {
                throw new ArgumentException("Please check  ");
            }
            else
            {
                var _additionalField = await GetById(additionalField);
                try
                {
                    if (_additionalField != null)
                    {
                        this.DbContext.AdditionalFields.Remove(_additionalField);
                        this.DbContext.SaveChanges();
                    }

                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }

        public ICollection<AdditionalField> GetAll() => this.DbContext.AdditionalFields.ToList();

        public async Task<AdditionalField> GetById(int additionalField)
        {
            return await this.DbContext.AdditionalFields.FirstOrDefaultAsync(p => p.Id_AdditionalField == additionalField);
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

        public async Task<AdditionalField> Update(int id, AdditionalField additionalField)
        {
            if (id == 0)
            {
                throw new Exception("Please check the value of the id");
            }
            else
            {
                var AFound = await GetById(id);
                if (AFound == null)
                {
                    throw new Exception("AdditionalField not found");
                }
                else
                {
                    //Update the values
                    AFound.FieldName = additionalField.FieldName;
                    AFound.FieldType = additionalField.FieldType;
                    //Save the changes 
                    await this.DbContext.SaveChangesAsync();
                    return AFound;
                }
            }
        }
    }

}