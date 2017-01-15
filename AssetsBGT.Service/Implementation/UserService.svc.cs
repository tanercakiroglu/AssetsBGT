using Assets.DO;
using Assets.DO.Response;
using Assets.Service.Interface;
using Jose;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Service.Implementation
{
    public class UserService : IUserService
    {
        public CheckCredentialResponse CheckCredential(User user)
        {
            var response = new CheckCredentialResponse();
            if (user != null)
            {
                if ("taner" == user.Username && "taner" == user.Password)
                    response.token = CreateToken();
            }
            return response;
        }


        private static string CreateToken()
        {
            string token = null;
            byte[] secretKey = Encoding.ASCII.GetBytes("YOUR_CLIENT_SECRETsssssssssssssssssssssssssssssssssssssss");
            DateTime issued = DateTime.Now;
            DateTime expire = DateTime.Now.AddMinutes(10);

            var payload = new Dictionary<string, object>()
                {
                    {"iss", "www.assets.com.tr"},
                    {"aud", "YOUR_CLIENT_ID"},
                    {"sub", "anonymous"},
                    {"iat", issued.ToString()},
                    {"exp", expire.ToString()}
                };
            try
            {

                token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return token;
        }

    }
}
