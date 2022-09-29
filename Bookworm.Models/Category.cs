using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookworm.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }

        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Please enter a value between 1 and 100.")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
