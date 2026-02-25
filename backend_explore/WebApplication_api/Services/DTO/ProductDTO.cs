using System.ComponentModel.DataAnnotations;

namespace WebApplication_api.Services.DTO
{
    public class ProductDTO
    {

        [Required]
        [MaxLength(100, ErrorMessage = "The {0} can not have more than {1} characters.")]
        public string Name { get; set; }

        [Required]
        [MaxLength(500, ErrorMessage = "The {0} can not have more than {1} characters.")]

        public string Description { get; set; }

        [Range(1, 20000.00, ErrorMessage = "The {0} must be between {1} and {2}.")]
        public decimal Price { get; set; }

        [Required]
        // the category should be one of the following: Electronics, Clothing, Home, Books, Toys
        [RegularExpression("^(Electronics|Clothing|Home|Books|Toys|Furniture)$", ErrorMessage = "The {0} must be one of the following: Electronics, Clothing, Home, Books, Toys, Furniture.")]

        public string Category { get; set; }
    }
}
