using System;
using System.Collections.Generic;
using Assets.DataAccessLayer.Interface;
using Assets.DO.DataObject;

namespace Assets.DataAccessLayer.Implementation
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        private const string insertCountryQuery = "insert into country(Name, Code, TripleCode, [Order], CreateDate, IsActive, PhoneCode) values(@Name, @Code, @TripleCode, @Order, @CreateDate, @IsActive, @PhoneCode)";
        private const string deleteCountryQuery = "delete from country where ID =@Id";
        private const string tableNameCountry   = "Country";

        public void AddCountry(Country country)
        {
            Add(country, insertCountryQuery);
        }

        public List<Country> getAllCountries()
        {
           
            var list = new List<Country>();
            var items = FindAll(tableNameCountry);
            foreach (var item in items)
            {
                list.Add(item);
            }
            return list;
        }
        
        public void RemoveCountry(string id)
        {
            var country = new Country();
            country.Id = Convert.ToInt64(id);
            Remove(country, deleteCountryQuery);
        }
    }
}
