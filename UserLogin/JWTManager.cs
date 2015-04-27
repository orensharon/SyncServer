using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginService
{
    public class JWTManager
    {

        public static string CreateToken(int user_id, string username)
        {
            var payload = new Dictionary<string, object>() {
                    { "UserID", user_id },
                    { "Username", username }
                };

            var secretKey = "8FJ58GKJ.K45K1HSNVA7Q_DKD?'23SGHJ456";
            string token = JWT.JsonWebToken.Encode(payload, secretKey, JWT.JwtHashAlgorithm.HS256);

            return token;

        }


    }
}
