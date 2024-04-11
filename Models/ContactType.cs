using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsAdditionalField.AdditionalField;

namespace ModelsContactType.ContactTyp
{

    public class ContactType
    {
      
        public ContactType(string TypeName)
        {
            
            this.TypeName = TypeName;
        }


        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_ContactType { get; set; }


        [Required]
        public string TypeName { get; set; } 


    }
}
