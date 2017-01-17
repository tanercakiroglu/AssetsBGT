using System.Collections.Generic;
using Assets.BusinessLogic.Interface;
using Assets.DO;
using Assets.DataAccessLayer.Interface;
using System;

namespace Assets.BusinessLogic.Implementation
{
    public class CommonManager : ICommonManager
    {
        private ICountryRepository _countryRepo;
        private IProvinceRepository _provinceRepo;
        private IDistrictRepository _districtRepo;

        public CommonManager(ICountryRepository countryRepo,IProvinceRepository provinceRepo , IDistrictRepository districtRepo)
        {
            _countryRepo = countryRepo;
            _provinceRepo = provinceRepo;
            _districtRepo = districtRepo;
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

        public List<Province> GetAllProvinces()
        {
            return _provinceRepo.GetAllProvince();
        }

        public List<District> GetDistrictsByProvinceID(string id)
        {
            int provinceID;
            if(Int32.TryParse(id,out provinceID))
            return _districtRepo.GetDistrictsByProvinceID(provinceID);

            throw new ArgumentException("id");
        }
    }
}
