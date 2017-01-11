using System.Collections.Generic;
using Assets.DO;
using Assets.BusinessLogic.Interface;

namespace Assets.Service.Interface
{
    public class CommonService : ICommonService
    {
        private ICommonManager _commonManager;

        public CommonService(ICommonManager commonManager)
        {
            _commonManager = commonManager;
        }
        public List<Country> getAllCountries()
        {
            return _commonManager.GetAllCountries();
        }
    }
}
