using System.ComponentModel.DataAnnotations;
using ModelsContacts.Constacs;
using ModelsContactType.ContactTyp;

namespace ModelsAdditionalField.AdditionalField
{
    public class AdditionalField
    {
        public int Id { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string FieldType { get; set; }

        // Foreign key properties
        public int ContactId { get; set; }
        public int ContactTypeId { get; set; }

        // Navigation properties
        public Contact Contact { get; set; }
        public ContactType ContactType { get; set; }
    }
}

