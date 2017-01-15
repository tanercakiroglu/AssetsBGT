using Assets.DO;
using Assets.DO.Response;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Assets.Service.Interface
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
                       RequestFormat = WebMessageFormat.Json,
                       ResponseFormat = WebMessageFormat.Json,
                       UriTemplate = "checkCredential")]
        CheckCredentialResponse CheckCredential(User user);
    }
}
