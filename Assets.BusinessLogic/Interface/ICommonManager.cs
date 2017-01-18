using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.BusinessLogic.Interface
{
    public interface ICommonManager
    {
        List<Country> GetAllCountries();
        void AddCountry(Country country);
        void DeleteCountry(string id);
        List<Province> GetAllProvinces();
        List<District> GetDistrictsByProvinceID(string id);
        List<Neighborhood> GetAllNeighborhood();
    }
}
