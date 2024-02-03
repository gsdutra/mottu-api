using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class DeliveryPersonDto
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public string Cnh { get; set; }
        public string CnhImage { get; set; }
        public CnhType CnhType { get; set; }
    }
}
