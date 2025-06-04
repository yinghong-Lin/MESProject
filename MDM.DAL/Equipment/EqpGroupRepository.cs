using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace MDM.DAL.Equipment
{
    public class EqpGroupRepository
    {
        private readonly string _connectionString;

        public EqpGroupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }


        public List<EqpGroup> GetAllEqpGroups(string factoryId = null)
        {
            var groups = new List<EqpGroup>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                // 修改SQL查询，增加工厂ID筛选条件
                string query = "SELECT * FROM eqp_group";
                if (!string.IsNullOrEmpty(factoryId))
                {
                    query += " WHERE factory_id = @factoryId";
                }

                using (var command = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(factoryId))
                    {
                        command.Parameters.AddWithValue("@factoryId", factoryId);
                    }

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groups.Add(new EqpGroup
                            {
                                EqpGroupId = reader["eqp_group_id"].ToString(),
                                EqpGroupType = reader["eqp_group_type"].ToString(),
                                EqpGroupDescription = reader["eqp_group_description"].ToString(),
                                FactoryId = reader["factory_id"] == DBNull.Value ? null : reader["factory_id"].ToString(),
                                CreateTime = reader["create_time"] == DBNull.Value ? null : (DateTime?)reader["create_time"],
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"]
                            });
                        }
                    }
                }
            }

            Debug.WriteLine($"从数据库获取设备组数据，共 {groups.Count} 条记录");
            return groups;
        }


        public EqpGroup GetEqpGroupById(string id)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM eqp_group WHERE eqp_group_id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EqpGroup
                            {
                                EqpGroupId = reader["eqp_group_id"].ToString(),
                                EqpGroupType = reader["eqp_group_type"].ToString(),
                                EqpGroupDescription = reader["eqp_group_description"].ToString(),
                                FactoryId = reader["factory_id"] == DBNull.Value ? null : reader["factory_id"].ToString(),
                                CreateTime = reader["create_time"] == DBNull.Value ? null : (DateTime?)reader["create_time"],
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public bool CreateEqpGroup(EqpGroup group)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO eqp_group 
            (eqp_group_id, eqp_group_type, eqp_group_description, 
             factory_id, event_type, event_user, create_time, edit_time)
            VALUES (@id, @type, @desc, @factoryId, @eventType, @eventUser, @createTime, @editTime)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", group.EqpGroupId);
                    command.Parameters.AddWithValue("@type", group.EqpGroupType);
                    command.Parameters.AddWithValue("@desc", group.EqpGroupDescription);
                    command.Parameters.AddWithValue("@factoryId",
                        string.IsNullOrEmpty(group.FactoryId) ? DBNull.Value : (object)group.FactoryId);
                    command.Parameters.AddWithValue("@eventType",
                        string.IsNullOrEmpty(group.EventType) ? "CREATE" : group.EventType);
                    command.Parameters.AddWithValue("@eventUser",
                        string.IsNullOrEmpty(group.EventUser) ? "系统" : group.EventUser);
                    command.Parameters.AddWithValue("@createTime", DateTime.Now);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // 如果创建成功，添加历史记录
                    if (result > 0)
                    {
                        AddEqpGroupHistory(group, string.IsNullOrEmpty(group.EventType) ? "CREATE" : group.EventType);
                    }

                    return result > 0;
                }
            }
        }

        public bool UpdateEqpGroup(EqpGroup group)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE eqp_group SET 
            eqp_group_type = @type,
            eqp_group_description = @desc,
            factory_id = @factoryId,
            event_type = @eventType,
            event_user = @eventUser,
            edit_time = @editTime
            WHERE eqp_group_id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", group.EqpGroupId);
                    command.Parameters.AddWithValue("@type", group.EqpGroupType);
                    command.Parameters.AddWithValue("@desc", group.EqpGroupDescription);
                    command.Parameters.AddWithValue("@factoryId",
                        string.IsNullOrEmpty(group.FactoryId) ? DBNull.Value : (object)group.FactoryId);
                    command.Parameters.AddWithValue("@eventType",
                        string.IsNullOrEmpty(group.EventType) ? "UPDATE" : group.EventType);
                    command.Parameters.AddWithValue("@eventUser",
                        string.IsNullOrEmpty(group.EventUser) ? "系统" : group.EventUser);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // 如果更新成功，添加历史记录
                    if (result > 0)
                    {
                        AddEqpGroupHistory(group, string.IsNullOrEmpty(group.EventType) ? "UPDATE" : group.EventType);
                    }

                    return result > 0;
                }
            }
        }

        public bool DeleteEqpGroup(string id)
        {
            // 先获取要删除的设备组信息，用于记录历史
            var group = GetEqpGroupById(id);
            if (group == null)
            {
                return false;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM eqp_group WHERE eqp_group_id = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // 如果删除成功，添加历史记录
                    if (result > 0)
                    {
                        AddEqpGroupHistory(group, "DELETE");
                    }

                    return result > 0;
                }
            }
        }

        // 添加设备组历史记录
        private bool AddEqpGroupHistory(EqpGroup group, string eventType)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO eqp_group_his 
                    (eqp_group_id, eqp_group_type, eqp_group_description, 
                     factory_id, event_user, event_remark, edit_time, event_type)
                    VALUES (@id, @type, @desc, @factoryId, @eventUser, @eventRemark, @editTime, @eventType)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", group.EqpGroupId);
                    command.Parameters.AddWithValue("@type", group.EqpGroupType);
                    command.Parameters.AddWithValue("@desc", group.EqpGroupDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@factoryId",
                        string.IsNullOrEmpty(group.FactoryId) ? DBNull.Value : (object)group.FactoryId);
                    command.Parameters.AddWithValue("@eventUser", group.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", group.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);
                    command.Parameters.AddWithValue("@eventType", eventType);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // 获取设备组历史记录
        public List<EqpGroupHis> GetEqpGroupHistory(string eqpGroupId)
        {
            var history = new List<EqpGroupHis>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM eqp_group_his WHERE eqp_group_id = @id ORDER BY create_time";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", eqpGroupId);
                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            history.Add(new EqpGroupHis
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                EqpGroupId = reader["eqp_group_id"].ToString(),
                                EqpGroupType = reader["eqp_group_type"].ToString(),
                                EqpGroupDescription = reader["eqp_group_description"] == DBNull.Value ? null : reader["eqp_group_description"].ToString(),
                                FactoryId = reader["factory_id"] == DBNull.Value ? null : reader["factory_id"].ToString(),
                                EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                CreateTime = Convert.ToDateTime(reader["create_time"]),
                                EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                            });
                        }
                    }
                }
            }

            Debug.WriteLine($"获取设备组 {eqpGroupId} 的历史记录，共 {history.Count} 条");
            return history;
        }
    }
}
