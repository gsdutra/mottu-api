using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public enum Situation
    {
        Available = 0, Accepted = 1, Delivered = 2
    }
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime OrderedAt {  get; set; }
        public int Price {  get; set; }
        public Situation Situation { get; set; }
        public string AddresOrigin { get; set; }
        public string AddresDestination { get; set;}
    }
}
