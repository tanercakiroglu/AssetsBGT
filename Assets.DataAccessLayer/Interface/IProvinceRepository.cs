using Assets.DO;
using System.Collections.Generic;

namespace Assets.DataAccessLayer.Interface
{
    public interface IProvinceRepository
    {
        List<Province> GetAllProvince();
    }
}
