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
        public User getUser(string email)
        {
            User user = _dataContext.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }
        public void createSession(int userId, string bearerToken)
        {
            if (_dataContext.Sessions.FirstOrDefault(x => x.UserId == userId) == null)
            {
                _dataContext.Sessions.Add(new Session { UserId = userId });
                _dataContext.SaveChanges();
            }
            Session session = _dataContext.Sessions.FirstOrDefault(s => s.UserId == userId);
            session.Bearer = bearerToken;
            session.ExpiresAt = DateTime.UtcNow.AddHours(8);
            _dataContext.SaveChanges();
        }
        public User getUserByBearerSession(string bearerToken)
        {
            Session session = _dataContext.Sessions.FirstOrDefault(x => x.Bearer == bearerToken);
            User userData = _dataContext.Users.Find(session.UserId);

            return userData;
        }
    }
}
