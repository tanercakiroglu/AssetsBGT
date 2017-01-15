using Assets.DO;
using Assets.BusinessLogic.Interface;
using System.ServiceModel.Activation;
using Assets.DO.Response;
using System;
using System.Linq;
using AssetsBGT.Service.Behaviour;

namespace Assets.Service.Interface
{
    [ServiceBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommonService : ICommonService
    {
        private ICommonManager _commonManager;

        public CommonService(ICommonManager commonManager)
        {
            _commonManager = commonManager;
        }

        public BaseResponse AddCountry(Country country)
        {
            var response = new BaseResponse();
            try
            {
                //will be create static recursive method to null or empty check 
                bool isAnyPropEmpty = country.GetType().GetProperties()
                                    .Where(p => p.GetValue(country) is string) 
                                    .Any(p => string.IsNullOrWhiteSpace((p.GetValue(country) as string)));
                if (isAnyPropEmpty)
                    throw new ArgumentNullException();

                _commonManager.AddCountry(country);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.OperationStatus = false;
                response.Tag = "GeneralExcepiton";
            }
            return response;
        }

        public BaseResponse DeleteDountry(string id)
        {
            var response = new BaseResponse();
            try
            {
                if (id == null || id.Trim().Length <= 0)
                    throw new ArgumentNullException();
                _commonManager.DeleteCountry(id);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.OperationStatus = false;
                response.Tag = "GeneralExcepiton";
            }
            return response;
        }

        public GetAllCountriesResponse getAllCountries()
        {
            var response = new GetAllCountriesResponse();
            try
            {
                response.Countries = _commonManager.GetAllCountries();
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.OperationStatus = false;
                response.Tag = "GeneralExcepiton";
            }
            return response;
        }
    }

}
