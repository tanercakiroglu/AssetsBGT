using Assets.DO;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Assets.Service.Interface
{
    [ServiceContract]
    public interface ICommonService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
                              ResponseFormat = WebMessageFormat.Json,
                              BodyStyle = WebMessageBodyStyle.Wrapped,
                              UriTemplate = "getAllCountries")]
        List<Country> getAllCountries();

        [OperationContract]
        [WebInvoke(Method = "POST",
                         RequestFormat =WebMessageFormat.Json,
                         ResponseFormat = WebMessageFormat.Json,
                         UriTemplate = "addCountry")]
        void AddCountry(Country country);

        [OperationContract]
        [WebInvoke(Method = "GET",
                         RequestFormat = WebMessageFormat.Json,
                         ResponseFormat = WebMessageFormat.Json,
                         UriTemplate = "deleteCountry/{Id}")]
        void DeleteDountry(string Id);

    }
   
}
