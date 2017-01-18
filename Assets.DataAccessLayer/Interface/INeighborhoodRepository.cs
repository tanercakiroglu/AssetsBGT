using Assets.DO.DataObject;
using System.Collections.Generic;

namespace Assets.DataAccessLayer.Interface
{
    public  interface INeighborhoodRepository
    {
        List<Neighborhood> GelAllNeighborhoods();
    }
}
