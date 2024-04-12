using ModelsAdditionalField.AdditionalField;

namespace RepositoriesIAdditionalField.IAdditionalField
{
    public interface IAdditionalField
    {
        public Task Save(AdditionalField additionalField);
        public void Delete(int additionalField);
        public AdditionalField GetById(int additionalField);
        public AdditionalField Update(int id, AdditionalField additionalField);
        public ICollection<AdditionalField> GetAll();

    }
}