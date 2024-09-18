using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FirstWeb.Models
{
    public class Category
    {
        private int id;
        private string name;
        private int myProperty;
        private int displayOrder;
        private DateTime createDateTime;
        public Category() { createDateTime = DateTime.Now; }
        [Key] public int Id { get { return id; } set { id = value; } }
        /**[StringLength] and [RegularExpression]: To enforce length and format restrictions on strings.**/
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Name can only contain letters, numbers, and spaces.")]
        public string Name { get { return name; } set { name = value; } }
        /**[Range]: To ensure numeric values stay within specified bounds.**/
        [Range(1, 1000, ErrorMessage = "MyProperty must be between 1 and 1000.")]
        [DisplayName("Mah Puraperutii")] // Displays the name, even the label used in cshmtml is blank
        public int MyProperty { get { return myProperty; } set { myProperty = value; } }

        [Range(1, 100, ErrorMessage = "DisplayOrder must be between 1 and 100.")]
        [DisplayName("Disupuleyu Oruderu")] // Displays the name, even the label used in cshmtml is blank
        public int DisplayOrder { get { return displayOrder; } set { displayOrder = value; } }

        /**[ConcurrencyCheck]: To handle concurrency in database operations, 
         * ensuring that the record hasn’t changed between retrieval and update.**/
        [ConcurrencyCheck]
        public DateTime CreatedDateTime { get { return createDateTime; } set { createDateTime = value; } }


    }
}
