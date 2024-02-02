using MottuApi.Business;

namespace MottuApi.Middlewares
{
    public class AuthMiddleware
    {
        private readonly AuthBusiness _authBusiness;

        public AuthMiddleware(AuthBusiness authBusiness)
        {
            _authBusiness = authBusiness;
        }
    }
}
