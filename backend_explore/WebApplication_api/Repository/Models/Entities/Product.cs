using System.ComponentModel.DataAnnotations;

namespace WebApplication_api.Repository.Models.Entities
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

  
        public string Description { get; set; }

        public decimal Price { get; set; }


        public string Category { get; set; }
    }
}
