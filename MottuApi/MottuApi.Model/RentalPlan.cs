using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class RentalPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int Days {  get; set; }
        public int DailyPrice {  get; set; }
        public int DailyFinePercentage {  get; set; }
        public int ExtraDayPrice { get; set; }
        public Rental? Rental { get; set; }
    }
}
