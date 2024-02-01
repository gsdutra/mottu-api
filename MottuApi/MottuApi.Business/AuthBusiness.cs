using MottuApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Business
{
    public class AuthBusiness
    {
        public bool Register(UserDto user)
        {
            return true;
        }
        public string Login(UserDto user)
        {
            return "";
        }
        private string CreateToken(UserDto user)
        {
            return "";
        }
    }
}
