using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MDM.DAL.Carr
{
    public class CarrierRepository
    {
        private readonly string _connectionString;

        public CarrierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Carrier> GetAllCarriers()
        {
            var carriers = new List<Carrier>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM carriers";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            carriers.Add(new Carrier
                            {
                                CarrierNo = reader["carrier_no"].ToString(),
                                CarrierType = reader["carrier_type"].ToString(),
                                CarrierDetailType = reader["carrier_detail_type"].ToString(),
                                DurableId = reader["durable_id"].ToString(),
                                EquipmentId = reader["equipment_id"].ToString(),
                                PortId = reader["port_id"].ToString(),
                                CarrierStatus = reader["carrier_status"].ToString(),
                                CleaningStatus = reader["cleaning_status"].ToString(),
                                LockStatus = reader["lock_status"].ToString(),
                                BatchCapacity = Convert.ToInt32(reader["batch_capacity"]),
                                CurrentQty = Convert.ToInt32(reader["current_qty"]),
                                CapacityStatus = reader["capacity_status"].ToString(),
                                Location = reader["location"].ToString(),
                                LastMaintenanceDate = reader["last_maintenance_date"] == DBNull.Value ? null : (DateTime?)reader["last_maintenance_date"]
                            });
                        }
                    }
                }
            }
            return carriers;
        }

        public List<Carrier> GetCarriersByDurableId(string durableId)
        {
            var carriers = new List<Carrier>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM carriers WHERE durable_id = @durableId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@durableId", durableId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            carriers.Add(new Carrier
                            {
                                CarrierNo = reader["carrier_no"].ToString(),
                                CarrierType = reader["carrier_type"].ToString(),
                                CarrierDetailType = reader["carrier_detail_type"].ToString(),
                                DurableId = reader["durable_id"].ToString(),
                                EquipmentId = reader["equipment_id"].ToString(),
                                PortId = reader["port_id"].ToString(),
                                CarrierStatus = reader["carrier_status"].ToString(),
                                CleaningStatus = reader["cleaning_status"].ToString(),
                                LockStatus = reader["lock_status"].ToString(),
                                BatchCapacity = Convert.ToInt32(reader["batch_capacity"]),
                                CurrentQty = Convert.ToInt32(reader["current_qty"]),
                                CapacityStatus = reader["capacity_status"].ToString(),
                                Location = reader["location"].ToString(),
                                LastMaintenanceDate = reader["last_maintenance_date"] == DBNull.Value ? null : (DateTime?)reader["last_maintenance_date"]
                            });
                        }
                    }
                }
            }
            return carriers;
        }

        public List<Durable> GetAllDurables()
        {
            var durables = new List<Durable>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM durables";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            durables.Add(new Durable
                            {
                                DurableId = reader["durable_id"].ToString(),
                                SpecDescription = reader["spec_description"].ToString(),
                                DurableType = reader["durable_type"].ToString(),
                                DurableDetailType = reader["durable_detail_type"].ToString(),
                                DurableColor = reader["durable_color"].ToString(),
                                DurableQty = Convert.ToInt32(reader["durable_qty"]),
                                DurableCapacity = Convert.ToInt32(reader["durable_capacity"]),
                                ExpectedLife = Convert.ToInt32(reader["expected_life"]),
                                MaxUsage = Convert.ToInt32(reader["max_usage"]),
                                MaxUsageDays = Convert.ToInt32(reader["max_usage_days"]),
                                PostCleanMaxUsage = Convert.ToInt32(reader["post_clean_max_usage"]),
                                PostCleanMaxDays = Convert.ToInt32(reader["post_clean_max_days"]),
                                FactoryId = reader["factory_id"].ToString()
                            });
                        }
                    }
                }
            }
            return durables;
        }

        public bool InsertCarrier(Carrier carrier)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    string query = @"INSERT INTO carriers 
                                    (carrier_no, carrier_type, carrier_detail_type, durable_id, equipment_id, port_id, 
                                    carrier_status, cleaning_status, lock_status, batch_capacity, current_qty, 
                                    capacity_status, location, last_maintenance_date)
                                    VALUES 
                                    (@carrierNo, @carrierType, @carrierDetailType, @durableId, @equipmentId, @portId, 
                                    @carrierStatus, @cleaningStatus, @lockStatus, @batchCapacity, @currentQty, 
                                    @capacityStatus, @location, @lastMaintenanceDate)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@carrierNo", carrier.CarrierNo);
                        command.Parameters.AddWithValue("@carrierType", carrier.CarrierType);
                        command.Parameters.AddWithValue("@carrierDetailType", carrier.CarrierDetailType);
                        command.Parameters.AddWithValue("@durableId", carrier.DurableId);
                        command.Parameters.AddWithValue("@equipmentId", carrier.EquipmentId);
                        command.Parameters.AddWithValue("@portId", carrier.PortId);
                        command.Parameters.AddWithValue("@carrierStatus", carrier.CarrierStatus);
                        command.Parameters.AddWithValue("@cleaningStatus", carrier.CleaningStatus);
                        command.Parameters.AddWithValue("@lockStatus", carrier.LockStatus);
                        command.Parameters.AddWithValue("@batchCapacity", carrier.BatchCapacity);
                        command.Parameters.AddWithValue("@currentQty", carrier.CurrentQty);
                        command.Parameters.AddWithValue("@capacityStatus", carrier.CapacityStatus);
                        command.Parameters.AddWithValue("@location", carrier.Location);
                        command.Parameters.AddWithValue("@lastMaintenanceDate", carrier.LastMaintenanceDate);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting carrier: {ex.Message}");
                return false;
            }
        }
    }
}