using MottuApi.Model;
using MottuApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace MottuApi.Business
{
    public class AuthBusiness
    {
        private readonly AuthRepository _authRepository;
        public AuthBusiness(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }
        public bool Register(UserDto user)
        {
            try
            {
                if (!IsValidEmail(user.Email))
                    throw new Exception("Invalid e-mail.");

                if (user.Password.Length < 5)
                    throw new Exception("Password must be at least 5 characters long.");

                User newUser = new User
                {
                    Email = user.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                };
                if (_authRepository.getUser(user.Email) != null)
                    throw new Exception("Email already registered.");
                _authRepository.insertUser(newUser);
                return true;
            } catch (Exception ex) { 
                throw new Exception(ex.Message);
            }
        }
        public string Login(UserDto user)
        {
            try
            {
                User userData = _authRepository.getUser(user.Email);
                if (userData == null)
                    throw new Exception("User does not exist");
                if (!BCrypt.Net.BCrypt.Verify(user.Password, userData.Password))
                    throw new Exception("Incorrect password");
                string bearerToken = Guid.NewGuid().ToString();
                _authRepository.createSession(userData.Id, bearerToken);
                return bearerToken;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public User Authenticate(string header)
        {
            try
            {
                if (header == null)
                    throw new Exception("Missing bearer token.");
                string bearer = header.Split(" ")[1];
                User user = _authRepository.getUserByBearerSession(bearer);
                return user == null ? throw new Exception("Could not authenticate.") : user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static bool IsValidEmail(string email)
        {
            // Regular expression for a simple email validation
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }
    }
}
