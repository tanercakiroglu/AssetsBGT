using System.Collections.Generic;
using Assets.DataAccessLayer.Interface;
using Assets.DO.DataObject;

namespace Assets.DataAccessLayer.Implementation
{
    public class NeighborhoodRepository : Repository<Neighborhood>, INeighborhoodRepository
    {
        private const string tableNameNeighborhood = "Neighborhood";

        public List<Neighborhood> GelAllNeighborhoods()
        {

            var list = new List<Neighborhood>();
            var items = FindAll(tableNameNeighborhood);
            foreach (var item in items)
            {
                list.Add(item);
            }
            return list;
        }
    }
}
