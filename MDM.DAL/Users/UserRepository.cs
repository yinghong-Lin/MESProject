using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace MDM.DAL.Users
{
    // 用户仓储类，用于处理用户相关的数据库操作
    public class UserRepository
    {
        // 数据库连接字符串
        private readonly string _connectionString;

        // 构造函数，注入数据库连接字符串
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 根据用户名获取用户信息��方法
        public User GetUserByUserName(string userName)
        {
            // 使用using确保数据库连接和命令对象在使用后被正确释放
            using (var connection = new MySqlConnection(_connectionString))
            {
                // SQL查询语句，使用参数化查询防止SQL注入
                string query = "SELECT * FROM users WHERE user_name = @userName";
                using (var command = new MySqlCommand(query, connection))
                {
                    // 添加参数到命令对象
                    command.Parameters.AddWithValue("@userName", userName);
                    // 打开数据库连接
                    connection.Open();
                    // 执行查询并获取结果
                    using (var reader = command.ExecuteReader())
                    {
                        // 如果读取到数据行
                        if (reader.Read())
                        {
                            // 创建并返回用户对象，使用DBNull.Value检查数据库中的NULL值
                            return new User
                            {
                                UserId = reader["user_id"].ToString(),
                                UserType = reader["user_type"].ToString(),
                                UserName = reader["user_name"].ToString(),
                                UserPassword = reader["user_password"].ToString(),
                                UserEnglishName = reader["user_english_name"].ToString(),
                                DisplayLanguage = reader["display_language"].ToString(),
                                LastLoginTime = reader["last_login_time"] == DBNull.Value ? null : (DateTime?)reader["last_login_time"],
                                EventUser = reader["event_user"].ToString(),
                                EventRemark = reader["event_remark"].ToString(),
                                EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                CreateTime = reader["create_time"] == DBNull.Value ? null : (DateTime?)reader["create_time"],
                                EventType = reader["event_type"].ToString()
                            };
                        }
                    }
                }
            }
            // 如果没有找到用户，返回null
            return null;
        }

        // 更新用户最后登录时间的方法
        public bool UpdateLastLoginTime(string userId, DateTime lastLoginTime)
        {
            // 使用using确保数据库连接和命令对象在使用后被正确释放
            using (var connection = new MySqlConnection(_connectionString))
            {
                // SQL更新语句，使用参数化查询防止SQL注入
                string query = "UPDATE users SET last_login_time = @lastLoginTime WHERE user_id = @userId";
                using (var command = new MySqlCommand(query, connection))
                {
                    // 添加参数到命令对象
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@lastLoginTime", lastLoginTime);

                    // 打开数据库连接
                    connection.Open();
                    // 执行更新操作并返回是否成功（影响行数大于0表示成功）
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // 检查是否存在用户
        public bool CheckAnyUserExists()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT COUNT(*) FROM users";
                using (var command = new MySqlCommand(query, connection))
                {
                    connection.Open();
                    // 执行查询并获取结果，如果结果大于0表示存在用户
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }

        // 创建新用户的方法
        public bool CreateUser(User user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                const string query = @"INSERT INTO users 
                    (user_id, user_type, user_name, user_password, 
                     user_english_name, display_language, event_user, 
                     event_type, edit_time, create_time)
                    VALUES (@userId, @userType, @userName, @userPassword, 
                            @userEnglishName, @displayLanguage, @eventUser, 
                            @eventType, @editTime, @createTime)";

                using (var command = new MySqlCommand(query, connection))
                {
                    // 添加参数到命令对象
                    command.Parameters.AddWithValue("@userId", user.UserId);
                    command.Parameters.AddWithValue("@userType", user.UserType);
                    command.Parameters.AddWithValue("@userName", user.UserName);
                    command.Parameters.AddWithValue("@userPassword", user.UserPassword);
                    // 检查字符串属性是否为空，如果是空则使用DBNull.Value
                    command.Parameters.AddWithValue("@userEnglishName",
                        string.IsNullOrEmpty(user.UserEnglishName) ? DBNull.Value : (object)user.UserEnglishName);
                    command.Parameters.AddWithValue("@displayLanguage",
                        string.IsNullOrEmpty(user.DisplayLanguage) ? DBNull.Value : (object)user.DisplayLanguage);
                    command.Parameters.AddWithValue("@eventUser", user.EventUser);
                    command.Parameters.AddWithValue("@eventType", user.EventType);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);
                    command.Parameters.AddWithValue("@createTime", DateTime.Now);

                    // 打开数据库连接
                    connection.Open();
                    // 执行插入操作并返回是否成功（影响行数大于0表示成功）
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        // 获取所有用户不包含密码的方法
        public List<User> GetAllUsersWithoutPassword()
        {
            var users = new List<User>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT user_id, user_type, user_name, user_english_name, display_language, last_login_time, event_user, event_remark, edit_time, create_time, event_type FROM users";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader["user_id"].ToString(),
                                UserType = reader["user_type"].ToString(),
                                UserName = reader["user_name"].ToString(),
                                UserEnglishName = reader["user_english_name"]?.ToString(),
                                DisplayLanguage = reader["display_language"]?.ToString(),
                                LastLoginTime = reader["last_login_time"] != DBNull.Value ? (DateTime?)reader["last_login_time"] : null,
                                EventUser = reader["event_user"]?.ToString(),
                                EventRemark = reader["event_remark"]?.ToString(),
                                EditTime = reader["edit_time"] != DBNull.Value ? (DateTime?)reader["edit_time"] : null,
                                CreateTime = reader["create_time"] != DBNull.Value ? (DateTime?)reader["create_time"] : null,
                                EventType = reader["event_type"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return users;
        }

        // 获取所有用户包含密码的方法
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM users";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                UserId = reader["user_id"].ToString(),
                                UserType = reader["user_type"].ToString(),
                                UserName = reader["user_name"].ToString(),
                                UserPassword = reader["user_password"].ToString(),
                                UserEnglishName = reader["user_english_name"]?.ToString(),
                                DisplayLanguage = reader["display_language"]?.ToString(),
                                LastLoginTime = reader["last_login_time"] != DBNull.Value ? (DateTime?)reader["last_login_time"] : null,
                                EventUser = reader["event_user"]?.ToString(),
                                EventRemark = reader["event_remark"]?.ToString(),
                                EditTime = reader["edit_time"] != DBNull.Value ? (DateTime?)reader["edit_time"] : null,
                                CreateTime = reader["create_time"] != DBNull.Value ? (DateTime?)reader["create_time"] : null,
                                EventType = reader["event_type"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return users;
        }

        // Update an existing user
        public bool UpdateUser(User user)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                const string query = @"UPDATE users 
                              SET user_type = @userType, 
                                  user_name = @userName, 
                                  user_english_name = @userEnglishName, 
                                  display_language = @displayLanguage, 
                                  event_user = @eventUser, 
                                  event_remark = @eventRemark, 
                                  edit_time = @editTime, 
                                  event_type = @eventType 
                              WHERE user_id = @userId";

                using (var command = new MySqlCommand(query, connection))
                {
                    // Add parameters to the command
                    command.Parameters.AddWithValue("@userId", user.UserId);
                    command.Parameters.AddWithValue("@userType", user.UserType);
                    command.Parameters.AddWithValue("@userName", user.UserName);
                    command.Parameters.AddWithValue("@userEnglishName",
                        string.IsNullOrEmpty(user.UserEnglishName) ? DBNull.Value : (object)user.UserEnglishName);
                    command.Parameters.AddWithValue("@displayLanguage",
                        string.IsNullOrEmpty(user.DisplayLanguage) ? DBNull.Value : (object)user.DisplayLanguage);
                    command.Parameters.AddWithValue("@eventUser", user.EventUser);
                    command.Parameters.AddWithValue("@eventRemark",
                        string.IsNullOrEmpty(user.EventRemark) ? DBNull.Value : (object)user.EventRemark);
                    command.Parameters.AddWithValue("@editTime", DateTime.Now);
                    command.Parameters.AddWithValue("@eventType", "UPDATE");

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"更新用户时发生错误: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        // Delete a user by ID
        public bool DeleteUser(string userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                const string query = "DELETE FROM users WHERE user_id = @userId";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    try
                    {
                        connection.Open();
                        return command.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"删除用户时发生错误: {ex.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
