using ModelsAdditionalField.AdditionalField;

namespace RepositoriesIAdditionalField.IAdditionalField
{
    public interface IAdditionalFieldRepository
    {
        public Task Save(AdditionalField additionalField);
        public Task Delete(int additionalField);
        public Task<AdditionalField> GetById(int additionalField);
        public Task<AdditionalField> Update(int id, AdditionalField additionalField);
        public ICollection<AdditionalField> GetAll();

    }
}