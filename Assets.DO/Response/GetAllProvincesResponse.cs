using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.DO.Response
{
    public class GetAllProvincesResponse : BaseResponse
    {
      public  List<Province> Provinces { get; set; }
    }
}
