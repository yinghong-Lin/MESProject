using System.Collections.Generic;
using MySql.Data.MySqlClient;
using MDM.Model;
using System;

namespace MDM.DAL.WorkOrders
{
    public class DispatchWorkOrderDAL
    {
        private string connectionString = "Server=localhost;Database=mdm_db;Uid=root;Pwd=Lmi503606707;Port=3305;";

        public List<WorkOrder> GetWorkOrderHeaders()
        {
            return new List<WorkOrder>();
        }

        public List<WorkOrder> GetWorkOrdersByStartDate(DateTime? startDate)
        {
            List<WorkOrder> workOrders = new List<WorkOrder>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = @"SELECT * FROM work_order_list 
                                    WHERE (@startDate IS NULL OR planned_start_date = @startDate)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("@startDate", MySqlDbType.Date);
                        command.Parameters["@startDate"].Value = startDate.HasValue
                            ? startDate.Value
                            : (object)DBNull.Value;

                        Console.WriteLine($"执行查询: {command.CommandText}");
                        Console.WriteLine($"参数: startDate={startDate?.ToString("yyyy-MM-dd") ?? "NULL"}");

                        connection.Open();

                        int rowCount = 0;
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                rowCount++;
                                workOrders.Add(MapReaderToWorkOrder(reader));
                            }
                            Console.WriteLine($"读取到 {rowCount} 行数据");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"数据库错误: {ex.Message}\n{ex.StackTrace}");
                throw;
            }

            return workOrders;
        }

        public List<WorkOrder> GetProcessFlows()
        {
            List<WorkOrder> processFlows = new List<WorkOrder>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = "SELECT process_flow AS ProcessFlow, process_version AS ProcessVersion FROM work_order_list";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        connection.Open();

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                processFlows.Add(new WorkOrder
                                {
                                    ProcessFlow = reader["ProcessFlow"].ToString(),
                                    ProcessVersion = reader["ProcessVersion"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"数据库错误: {ex.Message}\n{ex.StackTrace}");
                throw;
            }

            return processFlows;
        }

        public void UpdateProcessFlow(string workOrderId, string newProcessFlow, string newProcessVersion)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string query = @"UPDATE work_order_list 
                                    SET process_flow = @newProcessFlow, process_version = @newProcessVersion 
                                    WHERE work_order_id = @workOrderId";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.Add("@newProcessFlow", MySqlDbType.VarChar).Value = newProcessFlow;
                        command.Parameters.Add("@newProcessVersion", MySqlDbType.VarChar).Value = newProcessVersion;
                        command.Parameters.Add("@workOrderId", MySqlDbType.VarChar).Value = workOrderId;

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"数据库错误: {ex.Message}\n{ex.StackTrace}");
                throw;
            }
        }

        private WorkOrder MapReaderToWorkOrder(MySqlDataReader reader)
        {
            return new WorkOrder
            {
                WorkOrderId = reader["work_order_id"].ToString(),
                WorkOrderType = reader["work_order_type"].ToString(),
                WorkOrderDescription = reader["work_order_description"].ToString(),
                FinishedWorkOrderNo = reader["finished_work_order_no"].ToString(),
                Bom = reader["bom"].ToString(),
                BomVersion = reader["bom_version"].ToString(),
                ProductType = reader["product_type"].ToString(),
                DetailType = reader["detail_type"] == DBNull.Value ? null : reader["detail_type"].ToString(),
                ProductId = reader["product_id"].ToString(),
                ProcessFlow = reader["process_flow"].ToString(),
                PlannedQuantity = Convert.ToInt32(reader["planned_quantity"]),
                TestProgram = reader["test_program"] == DBNull.Value ? null : reader["test_program"].ToString(),
                CompanyCode = reader["company_code"].ToString(),
                PlannedStartDate = reader["planned_start_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["planned_start_date"]),
                PlannedEndDate = reader["planned_end_date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["planned_end_date"]),
                CustomerLotNo = reader["customer_lot_no"] == DBNull.Value ? null : reader["customer_lot_no"].ToString(),
                ProductCategory = reader["product_category"] == DBNull.Value ? null : reader["product_category"].ToString(),
                Unit = reader["unit"] == DBNull.Value ? null : reader["unit"].ToString(),
                FilmThickness = reader["film_thickness"] == DBNull.Value ? null : reader["film_thickness"].ToString(),
                PackageForm = reader["package_form"] == DBNull.Value ? null : reader["package_form"].ToString(),
                WorkOrderStatus = reader["work_order_status"].ToString(),
                ProductDescription = reader["product_description"].ToString(),
                ProcessVersion = reader["process_version"] == DBNull.Value ? null : reader["process_version"].ToString()
            };
        }
    }
}