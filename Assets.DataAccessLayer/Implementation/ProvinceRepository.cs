using System.Collections.Generic;
using Assets.DataAccessLayer.Interface;
using Assets.DO.DataObject;

namespace Assets.DataAccessLayer.Implementation
{
    public class ProvinceRepository : Repository<Province>,IProvinceRepository
    {
        private const string tableNameprovince = "Province";

        public List<Province> GetAllProvince()
        {
            var list = new List<Province>();
            var items = FindAll(tableNameprovince);
            foreach (var item in items)
            {
                list.Add(item);
            }
            return list;
        }

        
    }
}
