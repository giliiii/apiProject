using System.ComponentModel.DataAnnotations;
namespace Chocolate.Models
{
    public class Categories
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        
        public ICollection<Products>? ProductList { get; set; }=new List<Products>();

    }
}
