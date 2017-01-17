using System.Collections.Generic;
using Assets.DataAccessLayer.Interface;
using Assets.DO;

namespace Assets.DataAccessLayer.Implementation
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        private const string selectByCountryQuery = "select * from district where district.ProvinceId=@ProvinceId ";

        public List<District> GetDistrictsByProvinceID(int id)
        {
            var district = new District();
            district.ProvinceId = id;

            var list = new List<District>();
            var items = FindBy(district, selectByCountryQuery);
            foreach (var item in items)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
