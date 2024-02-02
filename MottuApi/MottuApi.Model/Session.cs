using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class Session
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Bearer {  get; set; }
        public DateTime? ExpiresAt { get; set; }
    }
}
