using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Model
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
