using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.DO.Response
{
    public class GetDistrictsByCountryResponse : BaseResponse
    {
       public List<District> DistrictList { get; set; }
    }
}
