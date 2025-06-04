using MDM.Model.UserEntities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MDM.DAL.Process
{
    public class ProcessRepository
    {
        private readonly string _connectionString;

        public ProcessRepository(string connectionString)
        {
            _connectionString = connectionString;
            Debug.WriteLine("ProcessRepository 已初始化，使用数据库连接");
        }

        // 获取所有工艺流程
        public List<Flow> GetAllFlows(string factoryId = null)
        {
            var flows = new List<Flow>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT id, flow_id, flow_version, is_active, flow_description, 
                                release_state, flow_type, flow_detail_type, factory_id,
                                event_user, event_remark, edit_time, create_time, event_type
                                FROM flows WHERE 1=1";

                if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                {
                    query += " AND factory_id = @factoryId";
                }

                query += " ORDER BY flow_id, flow_version";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                    {
                        command.Parameters.AddWithValue("@factoryId", factoryId);
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                flows.Add(new Flow
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    FlowId = reader["flow_id"]?.ToString(),
                                    FlowVersion = reader["flow_version"]?.ToString(),
                                    IsActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    FlowDescription = reader["flow_description"]?.ToString(),
                                    ReleaseState = reader["release_state"]?.ToString(),
                                    FlowType = reader["flow_type"]?.ToString(),
                                    FlowDetailType = reader["flow_detail_type"]?.ToString(),
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllFlows 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllFlows 被调用，返回 {flows.Count} 条记录");
            return flows;
        }

        // 获取不包含在工艺流程中的工站列表
        public List<Oper> GetNonOperListByFId(string flowId)
        {
            var opers = new List<Oper>();
            string query = "";
            using (var connection = new MySqlConnection(_connectionString))
            {
                query = "select * from opers where id not in (select op_id from flow_oper where f_id = @fId)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fId", flowId);
                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var oper = new Oper
                                {
                                    Id = reader.GetInt32("id"),
                                    OperId = reader.GetString("oper_id"),
                                    OperVersion = reader.GetString("oper_version"),
                                    OperDescription = reader.GetString("oper_description"),
                                    OperType = reader.GetString("oper_type"),
                                    ReleaseState = reader.GetString("release_state"),
                                    IsActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    OperDetailType = reader["oper_detail_type"]?.ToString(),
                                    IsTrackin = reader["is_trackin"] != DBNull.Value && Convert.ToBoolean(reader["is_trackin"]),
                                    ScanCarrierTrackin = reader["scan_carrier_trackin"] != DBNull.Value && Convert.ToBoolean(reader["scan_carrier_trackin"]),
                                    ScanCarrierTrackout = reader["scan_carrier_trackout"] != DBNull.Value && Convert.ToBoolean(reader["scan_carrier_trackout"]),
                                    OperHour = reader["oper_hour"] == DBNull.Value ? null : (int?)reader["oper_hour"],
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                };
                                opers.Add(oper);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetNonOperListByFId 发生异常: {ex.Message}");
                    }
                }
            }
            return opers;
        }

        // 获取所有工艺包
        public List<Prp> GetAllPrps(string factoryId = null)
        {
            var prps = new List<Prp>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT p.*, pr.product_id as product_product_id, pr.product_type, pr.product_description 
                                FROM prps p 
                                LEFT JOIN products pr ON p.product_id = pr.product_id 
                                WHERE 1=1";

                if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                {
                    query += " AND p.factory_id = @factoryId";
                }

                query += " ORDER BY p.product_id, p.prp_version";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                    {
                        command.Parameters.AddWithValue("@factoryId", factoryId);
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var prp = new Prp
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    ProductId = reader["product_id"]?.ToString(),
                                    PrpVersion = reader["prp_version"]?.ToString(),
                                    IsActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    PrpDescription = reader["prp_description"]?.ToString(),
                                    ReleaseState = reader["release_state"]?.ToString(),
                                    MainFlow = reader["main_flow"]?.ToString(),
                                    PrpType = reader["prp_type"]?.ToString(),
                                    FlowPrpType = reader["flow_prp_type"]?.ToString(),
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                };

                                // 设置关联的产品信息
                                if (reader["product_product_id"] != DBNull.Value)
                                {
                                    prp.Product = new Product
                                    {
                                        ProductId = reader["product_product_id"]?.ToString(),
                                        ProductType = reader["product_type"]?.ToString(),
                                        ProductDescription = reader["product_description"]?.ToString()
                                    };
                                }

                                prps.Add(prp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllPrps 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllPrps 被调用，返回 {prps.Count} 条记录");
            return prps;
        }

        // 根据工艺包ID获取关联的工艺流程
        public List<Flow> GetFlowsByPrpId(int prpId)
        {
            var flows = new List<Flow>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT f.* FROM flows f 
                                INNER JOIN prp_flow pf ON f.id = pf.f_id 
                                WHERE pf.prp_id = @prpId 
                                ORDER BY f.flow_id, f.flow_version";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@prpId", prpId);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                flows.Add(new Flow
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    FlowId = reader["flow_id"]?.ToString(),
                                    FlowVersion = reader["flow_version"]?.ToString(),
                                    IsActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    FlowDescription = reader["flow_description"]?.ToString(),
                                    ReleaseState = reader["release_state"]?.ToString(),
                                    FlowType = reader["flow_type"]?.ToString(),
                                    FlowDetailType = reader["flow_detail_type"]?.ToString(),
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetFlowsByPrpId 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetFlowsByPrpId 被调用，prpId: {prpId}, 返回 {flows.Count} 条记录");
            return flows;
        }

        // 根据工艺流程ID获取工艺路线（工站序列）
        public List<Oper> GetOpersByFlowId(int flowId)
        {
            var opers = new List<Oper>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"SELECT o.*, fo.op_seq 
                FROM flow_oper fo 
                INNER JOIN opers o ON fo.op_id = o.id 
                WHERE fo.f_id = @flowId 
                ORDER BY fo.op_seq";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@flowId", flowId);

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var oper = new Oper
                                {
                                    Id = Convert.ToInt32(reader["id"]),
                                    OperId = reader["oper_id"]?.ToString(),
                                    OperVersion = reader["oper_version"]?.ToString(),
                                    IsActive = reader["is_active"] != DBNull.Value && Convert.ToBoolean(reader["is_active"]),
                                    OperDescription = reader["oper_description"]?.ToString(),
                                    ReleaseState = reader["release_state"]?.ToString(),
                                    OperType = reader["oper_type"]?.ToString(),
                                    OperDetailType = reader["oper_detail_type"]?.ToString(),
                                    IsTrackin = reader["is_trackin"] != DBNull.Value && Convert.ToBoolean(reader["is_trackin"]),
                                    ScanCarrierTrackin = reader["scan_carrier_trackin"] != DBNull.Value && Convert.ToBoolean(reader["scan_carrier_trackin"]),
                                    ScanCarrierTrackout = reader["scan_carrier_trackout"] != DBNull.Value && Convert.ToBoolean(reader["scan_carrier_trackout"]),
                                    OperHour = reader["oper_hour"] == DBNull.Value ? null : (int?)reader["oper_hour"],
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                };

                                opers.Add(oper);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetOpersByFlowId 发生异常: {ex.Message}");
                        throw; // Re-throw to let the service layer handle it
                    }
                }
            }

            Debug.WriteLine($"GetOpersByFlowId 被调用，flowId: {flowId}, 返回 {opers.Count} 条记录");
            return opers;
        }

        // 获取所有产品组
        public List<ProductGroup> GetAllProductGroups(string factoryId = null)
        {
            var groups = new List<ProductGroup>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM product_group WHERE 1=1";

                if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                {
                    query += " AND factory_id = @factoryId";
                }

                query += " ORDER BY product_group_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                    {
                        command.Parameters.AddWithValue("@factoryId", factoryId);
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                groups.Add(new ProductGroup
                                {
                                    ProductGroupId = reader["product_group_id"]?.ToString(),
                                    ProductGroupDescription = reader["product_group_description"]?.ToString(),
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllProductGroups 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllProductGroups 被调用，返回 {groups.Count} 条记录");
            return groups;
        }

        // 获取所有产品
        public List<Product> GetAllProducts(string factoryId = null, string productGroupId = null)
        {
            var products = new List<Product>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM products WHERE 1=1";

                if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                {
                    query += " AND factory_id = @factoryId";
                }

                if (!string.IsNullOrEmpty(productGroupId) && productGroupId != "All")
                {
                    query += " AND product_group_id = @productGroupId";
                }

                query += " ORDER BY product_id";

                using (var command = new MySqlCommand(query, connection))
                {
                    if (!string.IsNullOrEmpty(factoryId) && factoryId != "All")
                    {
                        command.Parameters.AddWithValue("@factoryId", factoryId);
                    }

                    if (!string.IsNullOrEmpty(productGroupId) && productGroupId != "All")
                    {
                        command.Parameters.AddWithValue("@productGroupId", productGroupId);
                    }

                    try
                    {
                        connection.Open();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductId = reader["product_id"]?.ToString(),
                                    ProductType = reader["product_type"]?.ToString(),
                                    ProductDetailType = reader["product_detail_type"]?.ToString(),
                                    ProductDescription = reader["product_description"]?.ToString(),
                                    ProductState = reader["product_state"]?.ToString(),
                                    Unit = reader["unit"]?.ToString(),
                                    BomId = reader["bom_id"]?.ToString(),
                                    BomVersion = reader["bom_version"]?.ToString(),
                                    ProductGroupId = reader["product_group_id"]?.ToString(),
                                    FactoryId = reader["factory_id"]?.ToString(),
                                    EventUser = reader["event_user"]?.ToString(),
                                    EventRemark = reader["event_remark"]?.ToString(),
                                    EditTime = reader["edit_time"] == DBNull.Value ? null : (DateTime?)reader["edit_time"],
                                    CreateTime = reader["create_time"] == DBNull.Value ? DateTime.Now : (DateTime)reader["create_time"],
                                    EventType = reader["event_type"]?.ToString()
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"GetAllProducts 发生异常: {ex.Message}");
                    }
                }
            }

            Debug.WriteLine($"GetAllProducts 被调用，返回 {products.Count} 条记录");
            return products;
        }
    }
}
