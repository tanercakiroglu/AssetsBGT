using System;
using System.Collections.Generic;
using Assets.BusinessLogic.Interface;
using Assets.DO;
using Assets.DataAccessLayer.Implementation;
using Assets.DataAccessLayer.Interface;

namespace Assets.BusinessLogic.Implementation
{
    public class CommonManager : ICommonManager
    {
        private ICommonDAO _commonDAO;
        public CommonManager(ICommonDAO commonDAO)
        {
            _commonDAO = commonDAO;
        }
        public List<Country> GetAllCountries()
        {
            
            return _commonDAO.getAllCountries();
        }
    }
}
