using System.Text;
using GolovinskyAPI.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace GolovinskyAPI.Infrastructure
{
    public class AuthOptions
    {
        public string ISSUER { get; set; }
        public string AUDIENCE { get; set; }
        public int LIFETIME { get; set; }
        public string KEY {get;set;}
        public SymmetricSecurityKey key { get; set; }

        public AuthOptions(IOptions<AuthServiceModel> options)
        {
            ISSUER = options.Value.Issuer;
            AUDIENCE = options.Value.Audience;
            LIFETIME = options.Value.LifeTime;
            KEY = options.Value.Key;
        }


    public static SymmetricSecurityKey GetSymmetricSecurityKey(IOptions<AuthServiceModel> options)
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(options.Value.Key));
    }
}
}/*http://golowinskiy.bostil.ru*/