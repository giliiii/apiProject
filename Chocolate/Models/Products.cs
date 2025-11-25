using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Chocolate.Models
{
    public class Products
    {
        public int Id { get; set; }
       
        [MaxLength(30)]
        [Required]
        public String Name { get; set; }=string.Empty;
       
        public String Description { get; set; } = string.Empty;

       
        public int CategoryId { get; set; }
         [ForeignKey("Categories")]
        public Categories? Category { get; set; }
       
        public int Cost { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<Orders>? ordersList { get; set; } = new List<Orders>();
    }
}
