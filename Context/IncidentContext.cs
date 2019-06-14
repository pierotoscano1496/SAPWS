using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using SAPWS.Models;

namespace SAPWS.Context
{
    public class IncidentContext : BaseConnection
    {
        public IncidentContext(string connectionString) : base(connectionString)
        {
        }

        public List<Incident> GetAllIncidents()
        {
            List<Incident> listIncidents = new List<Incident>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM incident");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Incident incident = new Incident
                        {
                            IdIncident = Convert.ToInt32(reader["id_incident"]),
                            Code = Convert.ToString(reader["code"])
                        };
                    }
                }
            }
            return listIncidents;
        }

    }
}