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
                string query = "SELECT c.*, d.* FROM carriers c LEFT JOIN durables d ON c.durable_id = d.durable_id";

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
                                DurableId = reader["durable_id"] == DBNull.Value ? null : reader["durable_id"].ToString(),
                                EquipmentId = reader["equipment_id"] == DBNull.Value ? null : reader["equipment_id"].ToString(),
                                PortId = reader["port_id"] == DBNull.Value ? null : reader["port_id"].ToString(),
                                HandlingStatus = reader["handling_status"].ToString(),
                                CleaningStatus = reader["cleaning_status"].ToString(),
                                LockStatus = reader["lock_status"].ToString(),
                                BatchCapacity = Convert.ToInt32(reader["batch_capacity"]),
                                CurrentQty = Convert.ToInt32(reader["current_qty"]),
                                Location = reader["location"] == DBNull.Value ? null : reader["location"].ToString(),
                                LastMaintenanceDate = reader["last_maintenance_date"] == DBNull.Value ? null : (DateTime?)reader["last_maintenance_date"],
                                Durable = new Durable
                                {
                                    DurableId = reader["durable_id"] == DBNull.Value ? null : reader["durable_id"].ToString(),
                                    SpecDescription = reader["spec_description"] == DBNull.Value ? null : reader["spec_description"].ToString(),
                                    DurableType = reader["durable_type"] == DBNull.Value ? null : reader["durable_type"].ToString(),
                                    ExpectedLife = reader["expected_life"] == DBNull.Value ? 0 : Convert.ToInt32(reader["expected_life"]),
                                    CurrentUsage = reader["current_usage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["current_usage"]),
                                    PurchaseDate = reader["purchase_date"] == DBNull.Value ? null : (DateTime?)reader["purchase_date"],
                                    Supplier = reader["supplier"] == DBNull.Value ? null : reader["supplier"].ToString()
                                }
                            });
                        }
                    }
                }
            }

            return carriers;
        }

        public List<Durable> GetDurableTypes()
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
                                DurableId = reader["durable_id"] == DBNull.Value ? null : reader["durable_id"].ToString(),
                                SpecDescription = reader["spec_description"] == DBNull.Value ? null : reader["spec_description"].ToString(),
                                DurableType = reader["durable_type"] == DBNull.Value ? null : reader["durable_type"].ToString(),
                                ExpectedLife = reader["expected_life"] == DBNull.Value ? 0 : Convert.ToInt32(reader["expected_life"]),
                                CurrentUsage = reader["current_usage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["current_usage"]),
                                PurchaseDate = reader["purchase_date"] == DBNull.Value ? null : (DateTime?)reader["purchase_date"],
                                Supplier = reader["supplier"] == DBNull.Value ? null : reader["supplier"].ToString()
                            });
                        }
                    }
                }
            }

            return durables;
        }

        public Carrier GetCarrierByNo(string carrierNo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT c.*, d.* FROM carriers c LEFT JOIN durables d ON c.durable_id = d.durable_id WHERE c.carrier_no = @carrierNo";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carrierNo", carrierNo);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Carrier
                            {
                                CarrierNo = reader["carrier_no"].ToString(),
                                CarrierType = reader["carrier_type"].ToString(),
                                CarrierDetailType = reader["carrier_detail_type"].ToString(),
                                DurableId = reader["durable_id"] == DBNull.Value ? null : reader["durable_id"].ToString(),
                                EquipmentId = reader["equipment_id"] == DBNull.Value ? null : reader["equipment_id"].ToString(),
                                PortId = reader["port_id"] == DBNull.Value ? null : reader["port_id"].ToString(),
                                HandlingStatus = reader["handling_status"].ToString(),
                                CleaningStatus = reader["cleaning_status"].ToString(),
                                LockStatus = reader["lock_status"].ToString(),
                                BatchCapacity = Convert.ToInt32(reader["batch_capacity"]),
                                CurrentQty = Convert.ToInt32(reader["current_qty"]),
                                Location = reader["location"] == DBNull.Value ? null : reader["location"].ToString(),
                                LastMaintenanceDate = reader["last_maintenance_date"] == DBNull.Value ? null : (DateTime?)reader["last_maintenance_date"],
                                Durable = new Durable
                                {
                                    DurableId = reader["durable_id"] == DBNull.Value ? null : reader["durable_id"].ToString(),
                                    SpecDescription = reader["spec_description"] == DBNull.Value ? null : reader["spec_description"].ToString(),
                                    DurableType = reader["durable_type"] == DBNull.Value ? null : reader["durable_type"].ToString(),
                                    ExpectedLife = reader["expected_life"] == DBNull.Value ? 0 : Convert.ToInt32(reader["expected_life"]),
                                    CurrentUsage = reader["current_usage"] == DBNull.Value ? 0 : Convert.ToInt32(reader["current_usage"]),
                                    PurchaseDate = reader["purchase_date"] == DBNull.Value ? null : (DateTime?)reader["purchase_date"],
                                    Supplier = reader["supplier"] == DBNull.Value ? null : reader["supplier"].ToString()
                                }
                            };
                        }
                    }
                }
            }

            return null;
        }

        public bool InsertCarrier(Carrier carrier)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO carriers 
                                (carrier_no, carrier_type, carrier_detail_type, durable_id, equipment_id, port_id, 
                                 handling_status, cleaning_status, lock_status, batch_capacity, current_qty, location, last_maintenance_date)
                                VALUES (@carrierNo, @carrierType, @carrierDetailType, @durableId, @equipmentId, @portId,
                                        @handlingStatus, @cleaningStatus, @lockStatus, @batchCapacity, @currentQty, @location, @lastMaintenanceDate)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carrierNo", carrier.CarrierNo);
                    command.Parameters.AddWithValue("@carrierType", carrier.CarrierType);
                    command.Parameters.AddWithValue("@carrierDetailType", carrier.CarrierDetailType);
                    command.Parameters.AddWithValue("@durableId",
                        string.IsNullOrEmpty(carrier.DurableId) ? DBNull.Value : (object)carrier.DurableId);
                    command.Parameters.AddWithValue("@equipmentId",
                        string.IsNullOrEmpty(carrier.EquipmentId) ? DBNull.Value : (object)carrier.EquipmentId);
                    command.Parameters.AddWithValue("@portId",
                        string.IsNullOrEmpty(carrier.PortId) ? DBNull.Value : (object)carrier.PortId);
                    command.Parameters.AddWithValue("@handlingStatus", carrier.HandlingStatus);
                    command.Parameters.AddWithValue("@cleaningStatus", carrier.CleaningStatus);
                    command.Parameters.AddWithValue("@lockStatus", carrier.LockStatus);
                    command.Parameters.AddWithValue("@batchCapacity", carrier.BatchCapacity);
                    command.Parameters.AddWithValue("@currentQty", carrier.CurrentQty);
                    command.Parameters.AddWithValue("@location",
                        string.IsNullOrEmpty(carrier.Location) ? DBNull.Value : (object)carrier.Location);
                    command.Parameters.AddWithValue("@lastMaintenanceDate",
                        carrier.LastMaintenanceDate == null ? DBNull.Value : (object)carrier.LastMaintenanceDate);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }

        public bool UpdateCarrier(Carrier carrier)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE carriers SET 
                                 carrier_type = @carrierType,
                                 carrier_detail_type = @carrierDetailType,
                                 durable_id = @durableId,
                                 equipment_id = @equipmentId,
                                 port_id = @portId,
                                 handling_status = @handlingStatus,
                                 cleaning_status = @cleaningStatus,
                                 lock_status = @lockStatus,
                                 batch_capacity = @batchCapacity,
                                 current_qty = @currentQty,
                                 location = @location,
                                 last_maintenance_date = @lastMaintenanceDate
                                 WHERE carrier_no = @carrierNo";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carrierNo", carrier.CarrierNo);
                    command.Parameters.AddWithValue("@carrierType", carrier.CarrierType);
                    command.Parameters.AddWithValue("@carrierDetailType", carrier.CarrierDetailType);
                    command.Parameters.AddWithValue("@durableId",
                        string.IsNullOrEmpty(carrier.DurableId) ? DBNull.Value : (object)carrier.DurableId);
                    command.Parameters.AddWithValue("@equipmentId",
                        string.IsNullOrEmpty(carrier.EquipmentId) ? DBNull.Value : (object)carrier.EquipmentId);
                    command.Parameters.AddWithValue("@portId",
                        string.IsNullOrEmpty(carrier.PortId) ? DBNull.Value : (object)carrier.PortId);
                    command.Parameters.AddWithValue("@handlingStatus", carrier.HandlingStatus);
                    command.Parameters.AddWithValue("@cleaningStatus", carrier.CleaningStatus);
                    command.Parameters.AddWithValue("@lockStatus", carrier.LockStatus);
                    command.Parameters.AddWithValue("@batchCapacity", carrier.BatchCapacity);
                    command.Parameters.AddWithValue("@currentQty", carrier.CurrentQty);
                    command.Parameters.AddWithValue("@location",
                        string.IsNullOrEmpty(carrier.Location) ? DBNull.Value : (object)carrier.Location);
                    command.Parameters.AddWithValue("@lastMaintenanceDate",
                        carrier.LastMaintenanceDate == null ? DBNull.Value : (object)carrier.LastMaintenanceDate);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }

        public bool DeleteCarrier(string carrierNo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM carriers WHERE carrier_no = @carrierNo";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@carrierNo", carrierNo);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    return result > 0;
                }
            }
        }
    }
}