using Assets.BusinessLogic.Interface;
using Assets.DO.DataObject;

namespace Assets.BusinessLogic.Implementation
{
    public class UserManager : IUserManager
    {
        public bool CheckCredential(User user)
        {
            if ("taner" == user.Username && "taner" == user.Password)
                return true;

            return false;
        }
    }
}
