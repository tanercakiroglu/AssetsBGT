using System.Collections.Generic;
using Assets.DO;
using Assets.BusinessLogic.Interface;
using System.ServiceModel.Activation;

namespace Assets.Service.Interface
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommonService : ICommonService
    {
        private ICommonManager _commonManager;

        public CommonService(ICommonManager commonManager)
        {
            _commonManager = commonManager;
        }

        public void AddCountry(Country country)
        {
            _commonManager.AddCountry(country);
        }

        public void DeleteDountry(string id)
        {
            _commonManager.DeleteCountry(id);
        }

        public List<Country> getAllCountries()
        {
            return _commonManager.GetAllCountries();
        }
    }
}
