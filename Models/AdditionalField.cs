using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsAdditionalField.AdditionalField
{
    public class AdditionalField
    {
        public AdditionalField()
        {
        }
        public AdditionalField(string FieldName, string FieldType, int ContactId,int Id_ContactType )
        {
            this.FieldName = FieldName;
            this.ContactId= ContactId;
            this.Id_ContactType= Id_ContactType;

        }

        public int Id { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string FieldType { get; set; }

        // Foreign key properties
        [ForeignKey("Id_Contact ")]
        public int ContactId { get; set; }

        [ForeignKey("Id_ContactType ")]
        public int Id_ContactType { get; set; }


    }
}

