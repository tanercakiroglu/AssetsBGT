using Assets.DO;
using System.Collections.Generic;

namespace Assets.DataAccessLayer.Interface
{
    public interface ICountryRepository
    {
        List<Country> getAllCountries();
        void AddCountry(Country country);
        void RemoveCountry(string id);
    }
}
