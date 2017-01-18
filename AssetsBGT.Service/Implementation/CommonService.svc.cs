using Assets.DO.DataObject;
using Assets.BusinessLogic.Interface;
using System.ServiceModel.Activation;
using Assets.DO.Response;
using System;
using Assets.Service.Behaviour;
using Assets.Service.Interface;
using AssetsBGT.Service.Util;

namespace Assets.Service.Implementation
{
    [SecuredServiceBehavior]
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
                if (!Utility.IsAnyPropNullOrEmpty(country))
                    _commonManager.AddCountry(country);
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }

        public BaseResponse DeleteDountry(string id)
        {
            var response = new BaseResponse();
            try
            {
                if (!Utility.IsNullOrEmpty(id))
                    _commonManager.DeleteCountry(id);
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }

        public GetAllCountriesResponse GetAllCountries()
        {
            var response = new GetAllCountriesResponse();
            try
            {
                response.Countries = _commonManager.GetAllCountries();
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }

        public GetAllNeighborhoodResponse GetAllNeighborhoods()
        {
            var response = new GetAllNeighborhoodResponse();
            try
            {
                response.Neighborhoods = _commonManager.GetAllNeighborhood();
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }

        public GetAllProvincesResponse GetAllProvinces()
        {
            var response = new GetAllProvincesResponse();
            try
            {
                response.Provinces = _commonManager.GetAllProvinces();
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }

        public GetDistrictsByCountryResponse GetDistrictsByProvinceID(string Id)
        {
            var response = new GetDistrictsByCountryResponse();
            try
            {
                if (!Utility.IsNullOrEmpty(Id))
                    response.DistrictList = _commonManager.GetDistrictsByProvinceID(Id);
            }
            catch (Exception ex)
            {
                response.PrepareException(ex);
            }
            return response;
        }
    }

}
