using System.ComponentModel.DataAnnotations;
using ModelsAdditionalField.AdditionalField; // Importing the DataAnnotations namespace

namespace ModelsContactType.ContactTyp // Namespace declaration
{
    // Class representing the type of contact
    public class ContactType // Definition of the ContactType class
    {
        // Constructor for the ContactType class
        public ContactType(string TypeName)
        {
            // Assigning the TypeName property from the constructor parameter
            this.TypeName = TypeName;
            // Initializing the AdditionalFields collection to an empty list
            AdditionalFields = new List<AdditionalField>();
        }

        public int Id { get; set; } // Property to store the unique identifier of the contact type

        // Required attribute to specify that the TypeName property is mandatory
        [Required]
        public string TypeName { get; set; } // Property to store the name of the contact type

        // Navigation property for additional fields related to this contact type
        public ICollection<AdditionalField> AdditionalFields { get; set; } // Property to store additional fields related to the contact type
    }
}
