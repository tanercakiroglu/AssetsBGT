using Assets.DataAccessLayer.Interface;
using System;
using System.Collections.Generic;
using Assets.DO;
using System.Data;

namespace Assets.DataAccessLayer.Implementation
{
    public class CommonDAO : BaseDAO,ICommonDAO
    {
        public const string SelectCountryQuery = "SELECT  * FROM dbo.Country";
        public List<Country> getAllCountries()
        {
            List<Country> list = null;
            Country country = null;
            try
            {
                var dataTable = ExecuteQuery(SelectCountryQuery);
                if (dataTable != null && dataTable.Rows != null && dataTable.Rows.Count > 0)
                {
                    list = new List<Country>();
                    foreach (DataRow row in dataTable.Rows)
                    {
                        country = new Country();
                        country.ID = Convert.ToInt32(row["ID"]);
                        country.name = row["NAME"].ToString();
                        country.code = row["CODE"].ToString();
                        country.phoneCode = row["PHONECODE"].ToString();
                        country.createDate = Convert.ToDateTime(row["CREATEDATE"]);
                        country.active = Convert.ToBoolean(row["IsActive"]);
                        country.tripleCode = row["TripleCode"].ToString();

                        list.Add(country);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
}
