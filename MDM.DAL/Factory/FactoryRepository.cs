using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace MDM.DAL.Factory
{
    public class FactoryRepository
    {
        // 数据库连接字符串
        private readonly string _connectionString;

        // 构造函数，注入数据库连接字符串
        public FactoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 获取所有工厂信息
        public List<Model.UserEntities.Factory> GetAllFactories()
        {
            var factories = new List<Model.UserEntities.Factory>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM factories ORDER BY factory_id";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            factories.Add(new Model.UserEntities.Factory
                            {
                                FactoryId = Convert.ToInt32(reader["factory_id"]),
                                FactoryType = reader["factory_type"].ToString(),
                                FactoryDescription = reader["factory_description"]?.ToString(),
                                EventUser = reader["event_user"]?.ToString(),
                                EventRemark = reader["event_remark"]?.ToString(),
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                CreateTime = Convert.ToDateTime(reader["create_time"]),
                                EventType = reader["event_type"]?.ToString()
                            });
                        }
                    }
                }
            }

            return factories;
        }

        // 根据ID获取工厂信息
        public Model.UserEntities.Factory GetFactoryById(int factoryId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM factories WHERE factory_id = @factoryId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@factoryId", factoryId);
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Model.UserEntities.Factory
                            {
                                FactoryId = Convert.ToInt32(reader["factory_id"]),
                                FactoryType = reader["factory_type"].ToString(),
                                FactoryDescription = reader["factory_description"]?.ToString(),
                                EventUser = reader["event_user"]?.ToString(),
                                EventRemark = reader["event_remark"]?.ToString(),
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                CreateTime = Convert.ToDateTime(reader["create_time"]),
                                EventType = reader["event_type"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }

        // 添加新工厂
        public bool AddFactory(Model.UserEntities.Factory factory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"INSERT INTO factories 
                               (factory_type, factory_description, event_user, event_remark, edit_time, create_time, event_type) 
                               VALUES 
                               (@factoryType, @factoryDescription, @eventUser, @eventRemark, @editTime, @createTime, @eventType)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@factoryType", factory.FactoryType);
                    command.Parameters.AddWithValue("@factoryDescription", factory.FactoryDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventUser", factory.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", factory.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", factory.EditTime ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@createTime", factory.CreateTime);
                    command.Parameters.AddWithValue("@eventType", factory.EventType ?? (object)DBNull.Value);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // 更新工厂信息
        public bool UpdateFactory(Model.UserEntities.Factory factory)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"UPDATE factories 
                               SET factory_type = @factoryType, 
                                   factory_description = @factoryDescription, 
                                   event_user = @eventUser, 
                                   event_remark = @eventRemark, 
                                   edit_time = @editTime, 
                                   event_type = @eventType 
                               WHERE factory_id = @factoryId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@factoryId", factory.FactoryId);
                    command.Parameters.AddWithValue("@factoryType", factory.FactoryType);
                    command.Parameters.AddWithValue("@factoryDescription", factory.FactoryDescription ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventUser", factory.EventUser ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@eventRemark", factory.EventRemark ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);
                    command.Parameters.AddWithValue("@eventType", "UPDATE");

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }

        // 删除工厂
        public bool DeleteFactory(int factoryId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "DELETE FROM factories WHERE factory_id = @factoryId";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@factoryId", factoryId);

                    connection.Open();
                    int result = command.ExecuteNonQuery();
                    return result > 0;
                }
            }
        }
    }
}
