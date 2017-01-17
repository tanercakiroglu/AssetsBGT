using Assets.DO;
using Assets.DO.Response;
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
        GetAllCountriesResponse GetAllCountries();

        [OperationContract]
        [WebInvoke(Method = "POST",
                         RequestFormat =WebMessageFormat.Json,
                         ResponseFormat = WebMessageFormat.Json,
                         UriTemplate = "addCountry")]
        BaseResponse AddCountry(Country country);

        [OperationContract]
        [WebInvoke(Method = "GET",
                         RequestFormat = WebMessageFormat.Json,
                         ResponseFormat = WebMessageFormat.Json,
                         UriTemplate = "deleteCountry/{Id}")]
        BaseResponse DeleteDountry(string Id);

        [OperationContract]
        [WebInvoke(Method = "GET",
                        RequestFormat = WebMessageFormat.Json,
                        ResponseFormat = WebMessageFormat.Json,
                        UriTemplate = "getAllProvinces")]
        GetAllProvincesResponse GetAllProvinces();

        [OperationContract]
        [WebInvoke(Method = "GET",
                         RequestFormat = WebMessageFormat.Json,
                         ResponseFormat = WebMessageFormat.Json,
                         UriTemplate = "getDistrictsByProvinceID/{Id}")]
        GetDistrictsByCountryResponse GetDistrictsByProvinceID(string Id);
        
    }

}
