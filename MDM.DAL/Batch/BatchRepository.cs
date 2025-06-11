using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; // 使用MySQL连接器
using MDM.Model.BatchEntities;

namespace MDM.DAL.Batch
{
    public class BatchRepository : IDisposable
    {
        public readonly string _connectionString;
        private MySqlConnection _connection;

        public BatchRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // 根据工单ID获取工单列表
        public List<WorkOrderList> GetWorkOrdersById(string workOrderId)
        {
            var workOrders = new List<WorkOrderList>();

            try
            {
                using (_connection = new MySqlConnection(_connectionString))
                {
                    _connection.Open();

                    string sql = @"SELECT * FROM work_order_list 
                                 WHERE work_order_id LIKE @workOrderId 
                                 ORDER BY work_order_id";

                    using (var command = new MySqlCommand(sql, _connection))
                    {
                        command.Parameters.AddWithValue("@workOrderId", $"%{workOrderId}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                workOrders.Add(new WorkOrderList
                                {
                                    WorkOrderId = reader["work_order_id"].ToString(),
                                    Bom=reader["bom"].ToString(),
                                    WorkOrderType=reader["work_order_type"].ToString(),
                                    DetailType = reader["detail_type"].ToString(),
                                    PlannedQuantity = reader["planned_quantity"] != DBNull.Value ? Convert.ToInt32(reader["planned_quantity"]) : 0,
                                    Unit=reader["unit"].ToString(),
                                    WorkOrderDescription=reader["work_order_description"].ToString(),
                                    FinishedWorkOrderNo=reader["finished_work_order_no"].ToString(),
                                    BomVersion=reader["bom_version"].ToString(),
                                    ProductDetailType=reader["product_detail_type"].ToString(),
                                    ProductId=reader["product_id"].ToString(),
                                    ProcessFlow=reader["process_flow"].ToString(),
                                    CompanyCode = reader["company_code"].ToString(),
                                    PlannedStartDate = reader["planned_start_date"] != DBNull.Value ? Convert.ToDateTime(reader["planned_start_date"]) : DateTime.MinValue,
                                    PlannedEndDate = reader["planned_end_date"] != DBNull.Value ? Convert.ToDateTime(reader["planned_end_date"]) : DateTime.MinValue,
                                    PackageForm=reader["package_form"].ToString(),
                                    WorkOrderStatus=reader["work_order_status"].ToString(),
                                    InputNum=reader["input_num"] != DBNull.Value ? Convert.ToInt32(reader["input_num"]) : 0,
                                    OnputNum=reader["onput_num"] != DBNull.Value ? Convert.ToInt32(reader["onput_num"]) : 0,
                                    DestroyNum=reader["destroy_num"] != DBNull.Value ? Convert.ToInt32(reader["destroy_num"]) : 0,
                                    CreatedNotProduceNum=reader["created_not_produce_num"] != DBNull.Value ? Convert.ToInt32(reader["created_not_produce_num"]) : 0,
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // 记录错误日志
                throw new Exception("查询工单时出错", ex);
            }

            return workOrders;
        }

        public bool SaveBatch(Model.BatchEntities.Batch batch)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new MySqlCommand(
                        @"INSERT INTO batches (batch_id, batch_type, unit, detail_type, batch_qty, sub_product_qty, wip_status, lock_status, work_order_no, product_id, process_flow_no, process_flow_version, station_no)
                                 VALUES (@batchId, @batchType, @unit, @detailType, @batchQty, @subProductQty, @wipStatus, @lockStatus, @workOrderNo, @productId, @processFlowNo, @processFlowVersion, @stationNo)", connection))
                    {
                        // 参数设置...
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // 记录完整错误信息
                Console.WriteLine($"保存批次失败: {ex.ToString()}");
                throw; // 重新抛出原始异常
            }
        }

        // 新增批量保存方法
        public bool SaveBatches(List<Model.BatchEntities.Batch> batches)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        foreach (var batch in batches)
                        {
                            using (var command = new MySqlCommand(
                                @"INSERT INTO batches (batch_id, batch_type, unit, detail_type, batch_qty, sub_product_qty, wip_status, lock_status, work_order_no, product_id, process_flow_no, process_flow_version, station_no)
                                 VALUES (@batchId, @batchType, @unit, @detailType, @batchQty, @subProductQty, @wipStatus, @lockStatus, @workOrderNo, @productId, @processFlowNo, @processFlowVersion, @stationNo)", connection, transaction))
                            {
                                command.Parameters.AddWithValue("@batchId", batch.BatchId);
                                command.Parameters.AddWithValue("@batchType", batch.BatchType);
                                command.Parameters.AddWithValue("@unit", batch.Unit);
                                command.Parameters.AddWithValue("@detailType", batch.DetailType);
                                command.Parameters.AddWithValue("@batchQty", batch.BatchQty);
                                command.Parameters.AddWithValue("@subProductQty", batch.SubProductQty);
                                command.Parameters.AddWithValue("@wipStatus", batch.WIPStatus);
                                command.Parameters.AddWithValue("@lockStatus", batch.LockStatus);
                                command.Parameters.AddWithValue("@workOrderNo", batch.WorkOrderNo);
                                command.Parameters.AddWithValue("@productId", batch.ProductId);
                                command.Parameters.AddWithValue("@processFlowNo", batch.ProcessFlowNo);
                                command.Parameters.AddWithValue("@processFlowVersion", batch.ProcessFlowVersion);
                                command.Parameters.AddWithValue("@stationNo", batch.StationNo);
                            }
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public List<MDM.Model.BatchEntities.Batch> GetAllBatches()
        {
            var batches = new List<MDM.Model.BatchEntities.Batch>();

            try
            {
                using (_connection = new MySqlConnection(_connectionString))
                {
                    _connection.Open();

                    string sql = @"SELECT * FROM batch";

                    using (var command = new MySqlCommand(sql, _connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                batches.Add(new MDM.Model.BatchEntities.Batch
                                {
                                    BatchId = reader["batch_id"].ToString(),
                                    BatchType = reader["BatchType"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    DetailType = reader["DetailType"].ToString(),
                                    BatchQty = Convert.ToInt32(reader["BatchQty"]),
                                    SubProductQty = Convert.ToInt32(reader["SubProductQty"]),
                                    WIPStatus = reader["WIPStatus"].ToString(),
                                    LockStatus = reader["LockStatus"].ToString(),
                                    WorkOrderNo = reader["WorkOrderNo"].ToString(),
                                    ProductId = reader["ProductId"].ToString(),
                                    ProcessFlowNo = reader["ProcessFlowNo"].ToString(),
                                    ProcessFlowVersion = reader["ProcessFlowVersion"].ToString(),
                                    StationNo = reader["StationNo"].ToString(),
                                    CreateTime = reader["CreateTime"] != DBNull.Value ? Convert.ToDateTime(reader["CreateTime"]) : DateTime.MinValue
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询批次信息时出错", ex);
            }

            return batches;
        }

        public List<MDM.Model.BatchEntities.Batch> GetBatchesByBatchId(string batchId)
        {
            var batches = new List<MDM.Model.BatchEntities.Batch>();

            try
            {
                using (_connection = new MySqlConnection(_connectionString))
                {
                    _connection.Open();

                    string sql = @"SELECT * FROM batch WHERE batch_id LIKE @BatchId";

                    using (var command = new MySqlCommand(sql, _connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", $"%{batchId}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                batches.Add(new MDM.Model.BatchEntities.Batch
                                {
                                    BatchId = reader["batch_id"].ToString(),
                                    BatchType = reader["BatchType"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    DetailType = reader["DetailType"].ToString(),
                                    BatchQty = Convert.ToInt32(reader["BatchQty"]),
                                    SubProductQty = Convert.ToInt32(reader["SubProductQty"]),
                                    WIPStatus = reader["WIPStatus"].ToString(),
                                    LockStatus = reader["LockStatus"].ToString(),
                                    WorkOrderNo = reader["WorkOrderNo"].ToString(),
                                    ProductId = reader["ProductId"].ToString(),
                                    ProcessFlowNo = reader["ProcessFlowNo"].ToString(),
                                    ProcessFlowVersion = reader["ProcessFlowVersion"].ToString(),
                                    StationNo = reader["StationNo"].ToString(),
                                    CreateTime=reader["CreateTime"] != DBNull.Value ? Convert.ToDateTime(reader["CreateTime"]) : DateTime.MinValue
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询批次信息时出错", ex);
            }
            return batches;
        }

        // 根据批次号获取批次流转表信息
        public List<BatchFlow> GetBatchFlowByBatchId(string batchId)
        {
            var batchFlows = new List<BatchFlow>();

            try
            {
                using (_connection = new MySqlConnection(_connectionString))
                {
                    _connection.Open();

                    string sql = @"SELECT * FROM batch_flow WHERE batch_id = @BatchId";

                    using (var command = new MySqlCommand(sql, _connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                batchFlows.Add(new BatchFlow
                                {
                                    BatchId = reader["batch_id"].ToString(),
                                    Qty = Convert.ToDecimal(reader["Qty"]),
                                    GoodQty = Convert.ToDecimal(reader["GoodQty"]),
                                    NGQty = Convert.ToDecimal(reader["NGQty"]),
                                    SubProductQty = Convert.ToDecimal(reader["SubProductQty"]),
                                    BatchType = reader["BatchType"].ToString(),
                                    Unit = reader["Unit"].ToString(),
                                    ProductId = reader["ProductID"].ToString(),
                                    StationNo = reader["StationNo"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    DetailStationType = reader["DetailStationType"].ToString(),
                                    ProcessStatus = reader["ProcessStatus"].ToString(),
                                    EquipmentNo = reader["EquipmentNo"].ToString(),
                                    EquipmentStatus = reader["EquipmentStatus"].ToString(),
                                    LockStatus = reader["LockStatus"].ToString(),
                                    ReworkStatus = reader["ReworkStatus"].ToString(),
                                    Location = reader["Location"].ToString(),
                                    ProcessFlowNo = reader["ProcessFlowNo"].ToString(),
                                    ProcessPackageVersion = reader["ProcessPackageVersion"].ToString(),
                                    ProcessFlowVersion = reader["ProcessFlowVersion"].ToString(),
                                    StationVersion = reader["StationVersion"].ToString(),
                                    Grade = reader["Grade"].ToString(),
                                    HotType = reader["HotType"].ToString(),
                                    ProductionStartDate = reader["ProductionStartDate"] != DBNull.Value ? Convert.ToDateTime(reader["ProductionStartDate"]) : DateTime.MinValue,
                                    OutboundDate = reader["OutboundDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["OutboundDate"]) : null,
                                    StationChangeDate = reader["StationChangeDate"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["StationChangeDate"]) : null,
                                    ParentBatch = reader["ParentBatch"].ToString(),
                                    SubUnit = reader["SubUnit"].ToString(),
                                    BOMNo = reader["BOMNo"].ToString(),
                                    BOMVersion = reader["BOMVersion"].ToString(),
                                    UsedSubBatch = reader["UsedSubBatch"].ToString(),
                                    CarrierNo = reader["CarrierNo"].ToString(),
                                    StationType = reader["StationType"].ToString(),
                                    DetailType = reader["detail_type"].ToString(),
                                    WorkOrderId = reader["work_order_id"].ToString(),
                                    OnProductState = reader["on_product_state"].ToString(),
                                    RepairState = reader["repair_state"].ToString(),
                                    FlowDescription = reader["flow_description"].ToString(),
                                    DestoryNum = Convert.ToInt32(reader["destory_num"]),
                                    FlowState = reader["flow_state"].ToString(),
                                    ProcessName = reader["process_name"].ToString(),
                                    DetainCodeGroup=reader["detain_code_group"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("查询批次流转表信息时出错", ex);
            }
            return batchFlows;
        }

        public bool SaveLockedBatch(LockedBatch lockedBatch)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    var sql = @"INSERT INTO locked_batch (batch_id, lock_time, lock_code, lock_description, locked_by, detain_code_group, reason_process_flow, reason_station, reason_operation_desc, reason_equipment)
                           VALUES (@BatchId, @LockTime, @LockCode, @LockDescription, @LockedBy, @DetainCodeGroup, @ReasonProcessFlow, @ReasonStation, @ReasonOperationDesc, @ReasonEquipment)";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", lockedBatch.BatchId);
                        command.Parameters.AddWithValue("@LockTime", lockedBatch.LockTime);
                        command.Parameters.AddWithValue("@LockCode", lockedBatch.LockCode);
                        command.Parameters.AddWithValue("@LockDescription", lockedBatch.LockDescription);
                        command.Parameters.AddWithValue("@LockedBy", lockedBatch.LockedBy);
                        command.Parameters.AddWithValue("@DetainCodeGroup", lockedBatch.DetainCodeGroup);
                        command.Parameters.AddWithValue("@ReasonProcessFlow", lockedBatch.ReasonProcessFlow);
                        command.Parameters.AddWithValue("@ReasonStation", lockedBatch.ReasonStation);
                        command.Parameters.AddWithValue("@ReasonOperationDesc", lockedBatch.ReasonOperationDesc);
                        command.Parameters.AddWithValue("@ReasonEquipment", lockedBatch.ReasonEquipment);
                        command.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // 日志记录或调试
                Console.WriteLine($"保存锁定信息时出错: {ex.Message}");
                return false;
            }
        }

        // 实现IDisposable接口
        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
        }
    }
}