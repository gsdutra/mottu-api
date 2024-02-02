using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class Rental
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int MotorcycleId { get; set; }
        [ForeignKey("MotorcycleId")]
        public Motorcycle Motorcycle { get; set; }
        public int RentalPlanId { get; set; }
        [ForeignKey("RentalPlanId")]
        public RentalPlan RentalPlan { get; set; }
        public DateTime StartDate {  get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate {  get; set; }
    }
}
