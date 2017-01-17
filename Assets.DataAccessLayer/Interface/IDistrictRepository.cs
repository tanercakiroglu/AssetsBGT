using Assets.DO;
using System.Collections.Generic;

namespace Assets.DataAccessLayer.Interface
{
    public interface IDistrictRepository
    {
        List<District> GetDistrictsByProvinceID(int id);
    }
}
