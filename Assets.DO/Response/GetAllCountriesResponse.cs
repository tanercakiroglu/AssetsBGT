using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.DO.Response
{
    public  class GetAllCountriesResponse :BaseResponse
    {
        public List<Country> Countries { get; set; }
    }
}
