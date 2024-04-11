using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsAdditionalField.AdditionalField;
using ModelsContactType.ContactTyp;

namespace ModelsContacts.Constacs
{
    // Model Contact
    public class Contact
    {

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Contact { get; set; }

        [Required]
        public string Name { get; set; }


        // Foreign key properties
        [ForeignKey("Id_ContactType ")]
        public int ContactType { get; set; }


        [Required]
        public string PhoneNumber { get; set; }

        public string Comments { get; set; }


        // Constructor for the Contact class
        public Contact()
        {

        }
        public Contact(string Name, int ContactType, string PhoneNumber, string Comments)
        {

            this.Name = Name;
            this.ContactType = ContactType;
            this.PhoneNumber = PhoneNumber;
            this.Comments = Comments;

        }
    }
}
