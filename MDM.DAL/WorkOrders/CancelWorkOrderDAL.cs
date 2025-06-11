using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MDM.DAL
{
    public class CancelWorkOrderDAL
    {
        private string connectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=Lmi503606707;Port=3305;"; // 替换为你的MySQL连接字符串

        public DataTable GetWorkOrderList()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM work_order_list";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 新增方法：验证用户是否存在
        public bool CheckUserExists(string userId)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE user_id = @userId";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        // 新增方法：删除工单
        public void DeleteWorkOrders(List<string> workOrderIds)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                // 使用事务确保操作原子性
                using (MySqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string query = "DELETE FROM work_order_list WHERE work_order_id = @workOrderId";

                        foreach (string workOrderId in workOrderIds)
                        {
                            using (MySqlCommand cmd = new MySqlCommand(query, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}