using System.Collections.Generic;
using Assets.BusinessLogic.Interface;
using Assets.DO;
using Assets.DataAccessLayer.Interface;

namespace Assets.BusinessLogic.Implementation
{
    public class CommonManager : ICommonManager
    {
        private ICountryRepository _countryRepo;
        public CommonManager(ICountryRepository countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public void AddCountry(Country country)
        {
            _countryRepo.AddCountry(country);
        }

        public void DeleteCountry(string id)
        {
            _countryRepo.RemoveCountry(id);
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepo.getAllCountries();
        }
    }
}
