using System.ComponentModel.DataAnnotations;

namespace webstore.api.ModelDTO
{
    public class ProductUpdateDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public string Category { get; set; }
        [Range(1, 10000000)]
        public double Price { get; set; }
        public string Image { get; set; }
    }
}
