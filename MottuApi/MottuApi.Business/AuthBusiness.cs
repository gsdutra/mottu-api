using MottuApi.Model;
using MottuApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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
                if (_authRepository.verifyIfEmailExists(user.Email))
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
                return "";
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
