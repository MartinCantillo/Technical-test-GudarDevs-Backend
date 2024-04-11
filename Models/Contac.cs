using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelsAdditionalField.AdditionalField;
using ModelsContactType.ContactTyp; // Importing ContactType model from another namespace

namespace ModelsContacts.Constacs // Namespace declaration
{
    // Model Contact
    public class Contact // Definition of the Contact class
    {
        // Primary Key attribute
        [Key]
        // Database-generated attribute with identity specification
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // Required attribute to specify that the Name property is mandatory
        [Required]
        public string Name { get; set; } // Property to store the name of the contact

        // Required attribute to specify that the Type property is mandatory
        [Required]
        public ContactType Type { get; set; } // Property to store the type of the contact

        // Required attribute to specify that the PhoneNumber property is mandatory
        [Required]
        public string PhoneNumber { get; set; } // Property to store the phone number of the contact

        public string Comments { get; set; } // Property to store additional comments about the contact

        // Navigation property for additional fields
        public ICollection<AdditionalField> AdditionalFields { get; set; } // Property to store additional fields related to the contact

        // Constructor for the Contact class
        public Contact(string Name, ContactType Type, string PhoneNumber, string Comments)
        {
            // Assigning values to the properties from the constructor parameters
            this.Name = Name; // Assigning the name of the contact
            this.Type = Type; // Assigning the type of the contact
            this.PhoneNumber = PhoneNumber; // Assigning the phone number of the contact
            this.Comments = Comments; // Assigning the comments about the contact
            // Initializing the AdditionalFields collection to an empty list
            AdditionalFields = new List<AdditionalField>(); 
        }
    }
}
