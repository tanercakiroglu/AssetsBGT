using Assets.DO.DataObject;

namespace Assets.BusinessLogic.Interface
{
    public interface IUserManager
    {
        bool CheckCredential(User user);
    }
}
