using Assets.DO;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Assets.Service.Interface
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICommonService" in both code and config file together.
    [ServiceContract]
    public interface ICommonService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                              ResponseFormat = WebMessageFormat.Json,
                              BodyStyle = WebMessageBodyStyle.Wrapped,
                              UriTemplate = "getAllCountries")]
        List<Country> getAllCountries();


    }

   
}
