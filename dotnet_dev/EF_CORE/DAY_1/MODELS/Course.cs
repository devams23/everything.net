using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_CORE.DAY_1.MODELS
{
    public class Course
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
         
        [Precision(10,2)]  // here we can also use [Column]
        public decimal Fees { get; set; }

        [Range(0,48 ,ErrorMessage="A course Can't be too long.")] 
        public int DurationInMonths { get; set; } = 0;

        public ICollection<Batch> Batches { get; set; }  

        public ICollection<Student> Students { get; set; }






    }

}
