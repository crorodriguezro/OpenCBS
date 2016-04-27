// Octopus MFS is an integrated suite for managing a Micro Finance Institution: 
// clients, contracts, accounting, reporting and risk
// Copyright © 2006,2007 OCTO Technology & OXUS Development Network
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License along
// with this program; if not, write to the Free Software Foundation, Inc.,
// 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
//
// Website: http://www.opencbs.com
// Contact: contact@opencbs.com

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using OpenCBS.CoreDomain;
using OpenCBS.Shared;

namespace OpenCBS.Manager
{
    /// <summary>
    /// Database manager for locations : Provinces, Districts and Cities.
    /// </summary>
    public class LocationsManager : Manager
    {

        private static List<Province> _cacheProvinces;
        private static List<City> _cacheCities;
        private static List<District> _cacheDistricts;

        public LocationsManager(User pUser) : base(pUser)
        {
            InitCache();
        }

        public LocationsManager(string testDB) : base(testDB)
        {
            InitCache();
        }

        private void InitCache()
        {
            if(_cacheProvinces==null) _cacheProvinces= GetProvinceCache();
            if(_cacheCities==null)_cacheCities= GetCityCache();
            if (_cacheDistricts == null) _cacheDistricts = GetDistrictsCache();

        }

        private void RefreshCache()
        {
            _cacheProvinces = GetProvinceCache();
            _cacheCities = GetCityCache();
            _cacheDistricts = GetDistrictsCache();

        }


        public List<Province> GetProvinces()
        {
            return _cacheProvinces;
        }

        private List<Province> GetProvinceCache()
        {
            List<Province> provinces = new List<Province>();
            const string q = "SELECT [id],[name] FROM [Provinces]  WHERE [deleted] = 0 ORDER BY name";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                using (OpenCbsReader r = c.ExecuteReader())
                {
                    if (r != null)
                    {
                        while (r.Read())
                        {
                            Province province = new Province();
                            province.Id = r.GetInt("id");
                            province.Name = r.GetString("name");
                            provinces.Add(province);
                        }
                    }
                }
            }
            return provinces;
        }

        public List<City> GetCities()
        {
            return _cacheCities;
        }

        private List<City> GetCityCache()
        {
            List<City> cities = new List<City>();
            const string q = "SELECT [id], [name] ,[district_id]FROM [City] WHERE [deleted]=0 ORDER BY name ";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            using (OpenCbsReader r = c.ExecuteReader())
            {
                if (r != null)
                {
                    while (r.Read())
                    {
                        City city = new City();
                        city.Id = r.GetInt("id");
                        city.Name = r.GetString("name");
                        city.DistrictId = r.GetInt("district_id");
                        cities.Add(city);
                    }
                }
            }
            
            return cities;
        }


        public List<District> GetDistricts()
        {
            return _cacheDistricts;
        }
        private List<District> GetDistrictsCache()
        {
            List<Province> provinces = GetProvinces();

            List<District> districts = new List<District>();

            const string q = "SELECT [id], [name], [province_id] FROM [Districts]  WHERE [deleted]=0 ORDER BY name";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            using (OpenCbsReader reader = c.ExecuteReader())
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        District district = new District();
                        district.Id = reader.GetInt("id");
                        district.Name = reader.GetString("name");
                        int province_id = reader.GetInt("province_id");
                        foreach (Province p in provinces)
                        {
                            if (p.Id == province_id)
                            {
                                district.Province = p;
                            }
                        }
                        districts.Add(district);
                    }
                }
            }
            
            return districts;
        }

        public int AddDistrict(string pName, int pProvinceId)
        {
            const string q = "INSERT INTO [Districts] ([name],[province_id],[deleted]) VALUES( @name, @province,0) SELECT SCOPE_IDENTITY()";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@name", pName);
                c.AddParam("@province", pProvinceId);
                c.AddParam("@deleted", false);
                var id = c.ExecuteScalar().ToString();
                RefreshCache();
                return int.Parse(id);
            }
        }

        public District SelectDistrictById(int pId)
        {
            return _cacheDistricts.FirstOrDefault(val => val.Id == pId);
        }

        public District SelectDistrictByName(string name)
        {
            return _cacheDistricts.Join(_cacheProvinces, val => (val.Province != null ? val.Province.Id : 0),
                val => val.Id, (district, province) => new District()
                {
                    Id = district.Id,
                    Name = district.Name,
                    Province = new Province()
                    {
                        Id = province.Id,
                        Name = province.Name
                    }
                }).FirstOrDefault(val => val.Name.Equals(name));
        }

        public int AddProvince(string pName)
        {
            const string q = "INSERT INTO [Provinces] ([name], [deleted]) VALUES (@name,0) SELECT SCOPE_IDENTITY()";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@name", pName);
                c.AddParam("@deleted", false);
                var id = c.ExecuteScalar().ToString();
                RefreshCache();
                return int.Parse(id);
            }
        }

        public bool UpdateProvince(Province pProvince)
        {
            bool updateOk = false;
            try
            {
                const string q = "UPDATE [Provinces] SET [name]=@name WHERE id=@id";
                using (SqlConnection conn = GetConnection())
                using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
                {
                    c.AddParam("@id", pProvince.Id);
                    c.AddParam("@name", pProvince.Name);
                    RefreshCache();
                    c.ExecuteNonQuery();
                    updateOk = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return updateOk;
        }

        public void DeleteProvinceById(int pProvinceId)
        {
            const string q = "UPDATE [Provinces]  SET [deleted]=1 WHERE id=@id";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@id", pProvinceId);
                RefreshCache();
                c.ExecuteNonQuery();
            }
        }

        public int AddDistrict(District pDistrict)
        {
            const string q = "INSERT INTO [Districts]([name], [province_id],[deleted]) VALUES(@name,@provinceId,0) SELECT SCOPE_IDENTITY()";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@name", pDistrict.Name);
                c.AddParam("@provinceId", pDistrict.Province.Id);
                c.AddParam("@deleted", false);
                var id = c.ExecuteScalar().ToString();
                RefreshCache();
                return int.Parse(id);
            }
        }

        public bool UpdateDistrict(District pDistrict)
        {
            bool UpdateOk = false;
            try
            {
                const string q = "UPDATE [Districts] SET [name]=@name WHERE id=@id";
                using (SqlConnection conn = GetConnection())
                using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
                {
                    c.AddParam("@id", pDistrict.Id);
                    c.AddParam("@name", pDistrict.Name);
                    c.ExecuteNonQuery();
                    RefreshCache();
                    UpdateOk = true;
                }
            }
            catch (System.Exception ex)
            {
                throw ex; 
            }
            return UpdateOk;
        }

        public void DeleteDistrictById(int districtID)
        {
            const string q = "UPDATE [Districts]  SET [deleted]=1 WHERE id=@id";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@id", districtID);
                c.ExecuteNonQuery();
                RefreshCache();
            }
        }

        public int AddCity(City pCity)
        {
            const string q = "INSERT INTO [City] ([name], [district_id],[deleted]) VALUES (@name,@district_id,0) SELECT SCOPE_IDENTITY()";
            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@name", pCity.Name);
                c.AddParam("@district_id", pCity.DistrictId);
                c.AddParam("@deleted", pCity.Deleted);
                var id = c.ExecuteScalar().ToString();
                RefreshCache();
                return int.Parse(id);
            }

        }

        public bool UpdateCity(City pCity)
        {
                bool updateOk = false;
                try
                {
                    const string q = "UPDATE [City] SET [name]=@name WHERE id=@id";
                    using (SqlConnection conn = GetConnection())
                    using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
                    {
                        c.AddParam("@id", pCity.Id);
                        c.AddParam("@name", pCity.Name);
                        c.ExecuteNonQuery();
                        RefreshCache();
                        updateOk = true;
                    }
                }
                catch (System.Exception ex)
                {
                    throw ex;
                } 
               return updateOk;
            
        }

        public void DeleteCityById(int pCityId)
        {
            const string q = "UPDATE [City]  SET [deleted]=1 WHERE id=@id";

            using (SqlConnection conn = GetConnection())
            using (OpenCbsCommand c = new OpenCbsCommand(q, conn))
            {
                c.AddParam("@id", pCityId);
                c.ExecuteNonQuery();
                RefreshCache();
            }
        }

       

        public List<District> SelectDistrictsByProvinceId(int pProvinceId)
        {
            var result = (from district in _cacheDistricts
                          join province in _cacheProvinces on (district.Province != null ? district.Province.Id : 0) equals
                              province.Id
                          where province.Id == pProvinceId 
                          select new District()
                          {
                              Id = district.Id,
                              Name = district.Name,
                              Province = new Province()
                              {
                                  Id = province.Id,
                                  Name = province.Name,
                              }
                          }).ToList();
            return result;

        }

        public List<Province> SelectAllProvinces()
        {
            return _cacheProvinces;
        }

        public Province SelectProvinceByName(string name)
        {
            return _cacheProvinces.FirstOrDefault(val => val.Name == name);
        }

        public List<City> SelectCityByDistrictId(int pDistrictId)
        {
            return _cacheCities.Where(val => val.DistrictId == pDistrictId).ToList();
        }

        public bool Exists(Province province)
        {
            return _cacheProvinces.Any(val => val.Name == province.Name);
        }

        public bool Exists(District district)
        {
            var d = district;
            return _cacheDistricts.Any(val => val.Name == district.Name && val.Province.Id == district.Province.Id);
        }

        public bool Exists(City city)
        {
            return _cacheCities.Any(val => val.Name == city.Name && val.DistrictId == city.DistrictId);
        }

        public District SelectDistrictByCityName(string name)
        {
            return (from d in _cacheDistricts
                join p in _cacheProvinces on (d.Province != null ? d.Province.Id : 0) equals p.Id
                join c in _cacheCities on d.Id equals c.DistrictId
                where c.Name.Contains(name)
                select new District()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Province = new Province()
                    {
                        Id = p.Id,
                        Name = p.Name
                    }
                }).FirstOrDefault();
        }

        public bool IsDistrictUsed(int districtId)
        {
            const string query = "SELECT TOP 1 district_id FROM Tiers WHERE district_id = @districtId OR secondary_district_id = @districtId";
            using (var connection = GetConnection())
            using (var cmd = new OpenCbsCommand(query, connection))
            {
                cmd.AddParam("districtId", districtId);
                return cmd.ExecuteScalar() != null;
            }
        }

        public bool IsCityUsed(int cityId)
        {
            const string query = "SELECT c.id FROM City c " +
                                 "INNER JOIN Tiers t " +
                                 "    ON c.[name] = t.city OR c.[name] = t.secondary_city " +
                                 "WHERE c.id = @cityId";
            using (var connection = GetConnection())
            using (var cmd = new OpenCbsCommand(query, connection))
            {
                cmd.AddParam("cityId", cityId);
                return cmd.ExecuteScalar() != null;
            }            
        }
    }
}
