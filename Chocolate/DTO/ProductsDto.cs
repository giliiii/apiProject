namespace Chocolate.DTO
{
    public class ProductsDto
    {
        public string  Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int cost { get; set; }
        public bool IsDelited { get; set; }
    }

    public class ProductWithCategoryDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsDeleted { get; set; }
    }

    
}
