using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class RentalDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RentalPlanId { get; set; }
    }
}
