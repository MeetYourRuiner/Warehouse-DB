using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DBServer.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "DBServer";
        public const string AUDIENCE = "DBClient";
        const string KEY = "verybigsecuritykeywhichwillwork";
        public const int LIFETIME = 55;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
