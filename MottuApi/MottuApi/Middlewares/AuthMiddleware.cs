using MottuApi.Business;
using MottuApi.Model;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace MottuApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AuthBusiness _authBusiness;

        public AuthMiddleware(RequestDelegate next, AuthBusiness authBusiness)
        {
            _next = next;
            _authBusiness = authBusiness;
        }
        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
                throw new Exception("Missing bearer token.");
            string header = context.Request.Headers["Authorization"];
            string bearer = header.Split(" ")[0];
            User user = _authBusiness.Authenticate(bearer);
            if (user == null) throw new Exception("Unauthorized.");

            context.Items["UserData"] = user;

            await _next(context);
        }
    }
}
