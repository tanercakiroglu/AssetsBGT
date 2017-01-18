using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.DO.Response
{
    public class GetAllNeighborhoodResponse :BaseResponse
    {
        public List<Neighborhood> Neighborhoods { get; set; }
    }
}
