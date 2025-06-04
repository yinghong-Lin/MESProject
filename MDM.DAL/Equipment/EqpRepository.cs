using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MDM.DAL.Equipment
{
    public class EqpRepository
    {
        // 数据库连接字符串
        private readonly string _connectionString;

        // 构造函数，接收连接字符串
        public EqpRepository(string connectionString)
        {
            _connectionString = connectionString;
            Debug.WriteLine("EqpRepository 已初始化，使用数据库连接");
        }

        // 获取所有设备
        public List<Eqp> GetAllEqps()
        {
            var eqps = new List<Eqp>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM eqp ";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                eqps.Add(new Eqp
                                {
                                    EqpId = reader["eqp_id"].ToString(),
                                    EqpType = reader["eqp_type"].ToString(),
                                    EqpDetailType = reader["eqp_detail_type"].ToString(),
                                    EqpDescription = reader["eqp_description"] == DBNull.Value ? null : reader["eqp_description"].ToString(),
                                    EqpGroupId = reader["eqp_group_id"] == DBNull.Value ? null : reader["eqp_group_id"].ToString(),
                                    ParentEqpId = reader["parent_eqp_id"] == DBNull.Value ? null : reader["parent_eqp_id"].ToString(),
                                    EqpLevel = reader["eqp_level"] == DBNull.Value ? null : reader["eqp_level"].ToString(),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllEqps 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllEqps 被调用，返回 {eqps.Count} 条记录");
            return eqps;
        }

        // 根据设备类型和设备组获取设备列表
        public List<Eqp> GetEqpList(string eqpType, string eqpGroupId)
        {
            var eqps = new List<Eqp>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                // 基本查询，只获取主设备
                string query = "SELECT * FROM eqp WHERE 1=1 and eqp_level='MAIN'";

                // 如果设备类型不是"All"，则按设备类型筛选
                if (!string.IsNullOrEmpty(eqpType) && eqpType != "All")
                {
                    query += " AND eqp_type = @eqpType";
                }

                // 如果设备组不是"All"，则按设备组筛选
                if (!string.IsNullOrEmpty(eqpGroupId) && eqpGroupId != "All")
                {
                    query += " AND eqp_group_id = @eqpGroupId";
                }

                // 添加排序
                query += " ORDER BY eqp_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    // 添加参数
                    if (!string.IsNullOrEmpty(eqpType) && eqpType != "All")
                    {
                        command.Parameters.AddWithValue("@eqpType", eqpType);
                    }

                    if (!string.IsNullOrEmpty(eqpGroupId) && eqpGroupId != "All")
                    {
                        command.Parameters.AddWithValue("@eqpGroupId", eqpGroupId);
                    }

                    try
                    {
                        connection.Open();
                        Debug.WriteLine($"执行SQL: {query}");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                eqps.Add(new Eqp
                                {
                                    EqpId = reader["eqp_id"].ToString(),
                                    EqpType = reader["eqp_type"].ToString(),
                                    EqpDetailType = reader["eqp_detail_type"].ToString(),
                                    EqpDescription = reader["eqp_description"] == DBNull.Value ? null : reader["eqp_description"].ToString(),
                                    EqpGroupId = reader["eqp_group_id"] == DBNull.Value ? null : reader["eqp_group_id"].ToString(),
                                    ParentEqpId = reader["parent_eqp_id"] == DBNull.Value ? null : reader["parent_eqp_id"].ToString(),
                                    EqpLevel = reader["eqp_level"] == DBNull.Value ? null : reader["eqp_level"].ToString(),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetEqpList 发生异常: {ex.Message}");
                        throw; // 重新抛出异常，让上层处理
                    }
                }
            }

            Debug.WriteLine($"GetEqpList 被调用，参数：eqpType={eqpType}, eqpGroupId={eqpGroupId}，返回 {eqps.Count} 条记录");
            return eqps;
        }


        // 获取子设备列表
        public List<Eqp> GetSubEqps(string parentEqpId)
        {
            var subEqps = new List<Eqp>();

            if (string.IsNullOrEmpty(parentEqpId))
            {
                Debug.WriteLine("GetSubEqps: parentEqpId 为空");
                return subEqps;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM eqp WHERE parent_eqp_id = @parentEqpId ORDER BY eqp_id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@parentEqpId", parentEqpId);
                    try
                    {
                        connection.Open();
                        Debug.WriteLine($"执行SQL: {query} 参数: parentEqpId={parentEqpId}");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                subEqps.Add(new Eqp
                                {
                                    EqpId = reader["eqp_id"].ToString(),
                                    EqpType = reader["eqp_type"].ToString(),
                                    EqpDetailType = reader["eqp_detail_type"].ToString(),
                                    EqpDescription = reader["eqp_description"] == DBNull.Value ? null : reader["eqp_description"].ToString(),
                                    EqpGroupId = reader["eqp_group_id"] == DBNull.Value ? null : reader["eqp_group_id"].ToString(),
                                    ParentEqpId = reader["parent_eqp_id"] == DBNull.Value ? null : reader["parent_eqp_id"].ToString(),
                                    EqpLevel = reader["eqp_level"] == DBNull.Value ? null : reader["eqp_level"].ToString(),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetSubEqps 发生异常: {ex.Message}");
                        throw; // 重新抛出异常，让上层处理
                    }
                }
            }

            Debug.WriteLine($"GetSubEqps 被调用，parentEqpId: {parentEqpId}, 返回 {subEqps.Count} 条记录");
            return subEqps;
        }

        // 获取设备的端口列表
        public List<Port> GetPorts(string eqpId)
        {
            var ports = new List<Port>();

            if (string.IsNullOrEmpty(eqpId))
            {
                Debug.WriteLine("GetPorts: eqpId 为空");
                return ports;
            }

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM port WHERE eqp_id = @eqpId ORDER BY port_id";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eqpId", eqpId);
                    try
                    {
                        connection.Open();
                        Debug.WriteLine($"执行SQL: {query} 参数: eqpId={eqpId}");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ports.Add(new Port
                                {
                                    PortId = reader["port_id"].ToString(),
                                    PortType = reader["port_type"].ToString(),
                                    PortDetailType = reader["port_detail_type"].ToString(),
                                    PortDescription = reader["port_description"] == DBNull.Value ? null : reader["port_description"].ToString(),
                                    EqpId = reader["eqp_id"].ToString(),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetPorts 发生异常: {ex.Message}");
                        throw; // 重新抛出异常，让上层处理
                    }
                }
            }

            Debug.WriteLine($"GetPorts 被调用，eqpId: {eqpId}, 返回 {ports.Count} 条记录");
            return ports;
        }

        // 获取所有设备组ID
        public List<string> GetAllEqpGroupIds()
        {
            var groups = new List<string>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT DISTINCT eqp_group_id FROM eqp WHERE eqp_group_id IS NOT NULL";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                groups.Add(reader["eqp_group_id"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllEqpGroupIds 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllEqpGroupIds 被调用，返回 {groups.Count} 条记录");
            return groups;
        }

        // 获取所有设备类型
        public List<string> GetAllEqpTypes()
        {
            var types = new List<string>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT DISTINCT eqp_type FROM eqp WHERE eqp_type IS NOT NULL";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                types.Add(reader["eqp_type"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllEqpTypes 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllEqpTypes 被调用，返回 {types.Count} 条记录");
            return types;
        }

        // 获取所有设备组
        public List<EqpGroup> GetAllEqpGroups()
        {
            var groups = new List<EqpGroup>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM eqp_group";
                using (var command = new MySqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                groups.Add(new EqpGroup
                                {
                                    EqpGroupId = reader["eqp_group_id"].ToString(),
                                    EqpGroupType = reader["eqp_group_type"].ToString(),
                                    EqpGroupDescription = reader["eqp_group_description"] == DBNull.Value ? null : reader["eqp_group_description"].ToString(),
                                    FactoryId = reader["factory_id"] == DBNull.Value ? null : reader["factory_id"].ToString(),
                                    EventUser = reader["event_user"] == DBNull.Value ? null : reader["event_user"].ToString(),
                                    EventRemark = reader["event_remark"] == DBNull.Value ? null : reader["event_remark"].ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"] == DBNull.Value ? null : reader["event_type"].ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllEqpGroups 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllEqpGroups 被调用，返回 {groups.Count} 条记录");
            return groups;
        }

        // 添加设备
        public bool AddEqp(Eqp eqp)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO eqp 
                    (eqp_id, eqp_type, eqp_detail_type, eqp_description, eqp_group_id, 
                     parent_eqp_id, eqp_level, event_user, event_remark, edit_time, 
                     create_time, event_type) 
                    VALUES 
                    (@eqpId, @eqpType, @eqpDetailType, @eqpDescription, @eqpGroupId, 
                     @parentEqpId, @eqpLevel, @eventUser, @eventRemark, @editTime, 
                     @createTime, @eventType)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eqpId", eqp.EqpId);
                    command.Parameters.AddWithValue("@eqpType", eqp.EqpType);
                    command.Parameters.AddWithValue("@eqpDetailType", eqp.EqpDetailType);
                    command.Parameters.AddWithValue("@eqpDescription", eqp.EqpDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpGroupId", eqp.EqpGroupId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@parentEqpId", eqp.ParentEqpId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpLevel", eqp.EqpLevel ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventUser", eqp.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", eqp.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", eqp.EditTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@createTime", eqp.CreateTime);
                    command.Parameters.AddWithValue("@eventType", eqp.EventType ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"AddEqp 被调用，eqpId: {eqp.EqpId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"AddEqp 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // 更新设备
        public bool UpdateEqp(Eqp eqp)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE eqp SET 
                    eqp_type = @eqpType, 
                    eqp_detail_type = @eqpDetailType, 
                    eqp_description = @eqpDescription, 
                    eqp_group_id = @eqpGroupId, 
                    parent_eqp_id = @parentEqpId, 
                    eqp_level = @eqpLevel, 
                    event_user = @eventUser, 
                    event_remark = @eventRemark, 
                    edit_time = @editTime, 
                    event_type = @eventType 
                    WHERE eqp_id = @eqpId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@eqpId", eqp.EqpId);
                    command.Parameters.AddWithValue("@eqpType", eqp.EqpType);
                    command.Parameters.AddWithValue("@eqpDetailType", eqp.EqpDetailType);
                    command.Parameters.AddWithValue("@eqpDescription", eqp.EqpDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpGroupId", eqp.EqpGroupId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@parentEqpId", eqp.ParentEqpId ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpLevel", eqp.EqpLevel ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventUser", eqp.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", eqp.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", eqp.EditTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventType", eqp.EventType ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"UpdateEqp 被调用，eqpId: {eqp.EqpId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"UpdateEqp 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // 删除设备
        public bool DeleteEqp(string eqpId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                // 首先删除与该设备关联的所有端口
                string deletePortsQuery = "DELETE FROM port WHERE eqp_id = @eqpId";
                using (var command = new MySqlCommand(deletePortsQuery, connection))
                {
                    command.Parameters.AddWithValue("@eqpId", eqpId);
                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"DeleteEqp 删除关联端口时发生异常: {ex.Message}");
                        return false;
                    }
                }

                // 然后删除设备
                string deleteEqpQuery = "DELETE FROM eqp WHERE eqp_id = @eqpId";
                using (var command = new MySqlCommand(deleteEqpQuery, connection))
                {
                    command.Parameters.AddWithValue("@eqpId", eqpId);
                    try
                    {
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"DeleteEqp 被调用，eqpId: {eqpId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"DeleteEqp 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // 添加端口
        public bool AddPort(Port port)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO port 
                    (port_id, port_type, port_detail_type, port_description, eqp_id, 
                     event_user, event_remark, edit_time, create_time, event_type) 
                    VALUES 
                    (@portId, @portType, @portDetailType, @portDescription, @eqpId, 
                     @eventUser, @eventRemark, @editTime, @createTime, @eventType)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@portId", port.PortId);
                    command.Parameters.AddWithValue("@portType", port.PortType);
                    command.Parameters.AddWithValue("@portDetailType", port.PortDetailType);
                    command.Parameters.AddWithValue("@portDescription", port.PortDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpId", port.EqpId);
                    command.Parameters.AddWithValue("@eventUser", port.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", port.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", port.EditTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@createTime", port.CreateTime);
                    command.Parameters.AddWithValue("@eventType", port.EventType ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"AddPort 被调用，portId: {port.PortId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"AddPort 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // 更新端口
        public bool UpdatePort(Port port)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE port SET 
                    port_type = @portType, 
                    port_detail_type = @portDetailType, 
                    port_description = @portDescription, 
                    eqp_id = @eqpId, 
                    event_user = @eventUser, 
                    event_remark = @eventRemark, 
                    edit_time = @editTime, 
                    event_type = @eventType 
                    WHERE port_id = @portId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@portId", port.PortId);
                    command.Parameters.AddWithValue("@portType", port.PortType);
                    command.Parameters.AddWithValue("@portDetailType", port.PortDetailType);
                    command.Parameters.AddWithValue("@portDescription", port.PortDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eqpId", port.EqpId);
                    command.Parameters.AddWithValue("@eventUser", port.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", port.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", port.EditTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventType", port.EventType ?? (object)DBNull.Value);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"UpdatePort 被调用，portId: {port.PortId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"UpdatePort 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        // 删除端口
        public bool DeletePort(string portId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM port WHERE port_id = @portId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@portId", portId);
                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        Debug.WriteLine($"DeletePort 被调用，portId: {portId}, 结果: {result > 0}");
                        return result > 0;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"DeletePort 发生异常: {ex.Message}");
                        throw;
                    }
                }
            }
        }
    }
}
