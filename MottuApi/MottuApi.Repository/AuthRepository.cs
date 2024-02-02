using Microsoft.EntityFrameworkCore;
using MottuApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MottuApi.Repository
{
    public class AuthRepository
    {
        private readonly DataContext _dataContext;
        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void insertUser(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }
        public bool verifyIfEmailExists(string email)
        {
            User user = _dataContext.Users.FirstOrDefault(x => x.Email == email);
            return user != null;
        }
    }
}
