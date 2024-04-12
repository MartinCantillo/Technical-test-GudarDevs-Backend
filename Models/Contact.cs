using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace ModelsContacts.Contacs
{
    // Model Contact
    public class Contact
    {

        [Key]
        public int Id_Contact { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ContactType { get; set; }



        [Required]
        public string PhoneNumber { get; set; }

        public string Comments { get; set; }
        [Required]
        public string AdditionalField1 { get; set; }

        [Required]
        public string AdditionalField2 { get; set; }

        // Constructor for the Contact class
        public Contact()
        {

        }

        public Contact(string Name, int ContactType, string PhoneNumber, string Comments, string AdditionalField1, string AdditionalField2)
        {
            this.Name = Name;
            this.ContactType = ContactType;
            this.PhoneNumber = PhoneNumber;
            this.Comments = Comments;
            this.AdditionalField1 = AdditionalField1;
            this.AdditionalField2 = AdditionalField2;
        }
    }
}
