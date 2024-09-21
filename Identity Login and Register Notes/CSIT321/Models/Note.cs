using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSIT321.Models
{
    public class Note
    {
        [Key]
        public int noteID { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string noteTitle { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string noteContent { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime createdDate { get; set; } = DateTime.Now;
        [DataType(DataType.DateTime)]
        public DateTime updatedDate { get; set; }
    }
}
