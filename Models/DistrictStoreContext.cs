using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace project3data.Models
{
    public class DistrictStoreContext
    {
        public string connectionString { get; set; }

        public DistrictStoreContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private MySqlConnection getConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public List<District> getAllDistricts()
        {
            List<District> list = new List<District>();

            using(MySqlConnection database = getConnection())
            {
                database.Open();
                MySqlCommand query = new MySqlCommand("SELECT * FROM district", database);

                using(var reader = query.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        list.Add(new District()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            name = reader["name"].ToString(),
                            areas = reader["areas"].ToString(),
                            latitude = reader["latitude"] as decimal?,
                            longitude = reader["longitude"] as decimal?

                        });
                    }
                }
                database.Close();
                return list;
            }
        }
    }
}
