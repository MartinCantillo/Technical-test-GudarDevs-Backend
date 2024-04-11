using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ModelsAdditionalField.AdditionalField
{
    public class AdditionalField
    {
        public AdditionalField()
        {
        }
        public AdditionalField(string FieldName, string FieldType)
        {
            this.FieldName = FieldName;
            this.FieldType = FieldType;


        }

        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_AdditionalField { get; set; }

        [Required]
        public string FieldName { get; set; }

        [Required]
        public string FieldType { get; set; }



    }
}

