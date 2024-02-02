using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MottuApi.Model
{
    public class Motorcycle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Year { get; set; }
        public string Plate { get; set; }
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public MotorcycleModel Model { get; set; }
        public Rental Rental { get; set; }
    }
}
