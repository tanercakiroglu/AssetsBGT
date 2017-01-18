using Assets.BusinessLogic.Interface;
using Assets.DO.DataObject;
using Assets.DO.Response;
using Assets.Service.Interface;
using Assets.Service.Behaviour;
using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssetsBGT.Service.Util;

namespace Assets.Service.Implementation
{
    [NonSecuredServiceBehavior]
    public class UserService : IUserService
    {
        private IUserManager _userManager;
        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public CheckCredentialResponse CheckCredential(User user)
        {
            var response = new CheckCredentialResponse();
            try
            {
                if (!Utility.IsAnyPropNullOrEmpty(user))
                {
                    if (_userManager.CheckCredential(user))
                        response.token = CreateToken();
                }
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
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

                token = JWT.Encode(payload, secretKey, JwsAlgorithm.HS512);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return token;
        }

    }
}
