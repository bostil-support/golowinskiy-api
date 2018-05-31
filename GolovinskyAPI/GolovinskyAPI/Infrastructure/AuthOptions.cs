using System.Text;
using Microsoft.IdentityModel.Tokens;


namespace GolovinskyAPI.Infrastructure
{
    public class AuthOptions
    {
        public const string ISSUER = "http://91.92.136.144/";
        public const string AUDIENCE = "http://golowinskiy.bostil.ru";
        public const int LIFETIME = 1;
        const string KEY = "mysupersecret_secretkey!123";
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}