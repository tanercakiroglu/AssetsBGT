using Assets.DO;

namespace Assets.BusinessLogic.Interface
{
    public interface IUserManager
    {
        bool CheckCredential(User user);
    }
}
