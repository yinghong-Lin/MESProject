using System;
using System.Collections.Generic;

using MDM.DAL.Batch;
using MDM.Model.BatchEntities;

using MySql.Data.MySqlClient;

namespace MDM.BLL.Batch
{
    public class BatchService : IDisposable
    {
        public readonly BatchRepository _repository;
        private string _lastError;
        private string _connectionString;

        public string LastError => _lastError;
        public string GetLastError() => _lastError;

        public BatchService(string connectionString)
        {
            _repository = new BatchRepository(connectionString);
            _connectionString = connectionString;
        }

        public List<MDM.Model.BatchEntities.Batch> GetAllBatches()
        {
            return _repository.GetAllBatches();
        }

        public List<MDM.Model.BatchEntities.Batch> GetBatchesByBatchId(string batchId)
        {
            return _repository.GetBatchesByBatchId(batchId);
        }

        public List<WorkOrderList> GetWorkOrdersById(string workOrderId)
        {
            return _repository.GetWorkOrdersById(workOrderId);
        }

        public bool CreateBatch(Model.BatchEntities.Batch batch)
        {
            _lastError = null;

            if (batch == null)
            {
                _lastError = "批次对象为空";
                return false;
            }

            try
            {
                using (var connection = new MySqlConnection(_repository._connectionString))
                {
                    connection.Open();

                    // 添加事务处理
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string sql = @"INSERT INTO batch
                                    (batch_id, BatchType, Unit, DetailType, BatchQty, 
                                    SubProductQty, WIPStatus, LockStatus, WorkOrderNo, 
                                    ProductId, ProcessFlowNo, ProcessFlowVersion, StationNo, CreateTime)
                                    VALUES 
                                    (@BatchId, @BatchType, @Unit, @DetailType, @BatchQty, 
                                    @SubProductQty, @WIPStatus, @LockStatus, @WorkOrderNo, 
                                    @ProductId, @ProcessFlowNo, @ProcessFlowVersion, @StationNo, @CreateTime)";

                            using (var command = new MySqlCommand(sql, connection, transaction))
                            {
                                // 明确指定参数类型
                                command.Parameters.Add("@BatchId", MySqlDbType.VarChar).Value = batch.BatchId;
                                command.Parameters.Add("@BatchType", MySqlDbType.VarChar).Value = batch.BatchType ?? (object)DBNull.Value;
                                command.Parameters.Add("@Unit", MySqlDbType.VarChar).Value = batch.Unit ?? (object)DBNull.Value;
                                command.Parameters.Add("@DetailType", MySqlDbType.VarChar).Value = batch.DetailType ?? (object)DBNull.Value;
                                command.Parameters.Add("@BatchQty", MySqlDbType.Int32).Value = batch.BatchQty;
                                command.Parameters.Add("@SubProductQty", MySqlDbType.Int32).Value = batch.SubProductQty;
                                command.Parameters.Add("@WIPStatus", MySqlDbType.VarChar).Value = batch.WIPStatus ?? (object)DBNull.Value;
                                command.Parameters.Add("@LockStatus", MySqlDbType.VarChar).Value = batch.LockStatus ?? (object)DBNull.Value;
                                command.Parameters.Add("@WorkOrderNo", MySqlDbType.VarChar).Value = batch.WorkOrderNo ?? (object)DBNull.Value;
                                command.Parameters.Add("@ProductId", MySqlDbType.VarChar).Value = batch.ProductId ?? (object)DBNull.Value;
                                command.Parameters.Add("@ProcessFlowNo", MySqlDbType.VarChar).Value = batch.ProcessFlowNo ?? (object)DBNull.Value;
                                command.Parameters.Add("@ProcessFlowVersion", MySqlDbType.VarChar).Value = batch.ProcessFlowVersion ?? (object)DBNull.Value;
                                command.Parameters.Add("@StationNo", MySqlDbType.VarChar).Value = batch.StationNo ?? (object)DBNull.Value;
                                command.Parameters.Add("@CreateTime", MySqlDbType.DateTime).Value = batch.CreateTime;

                                int result = command.ExecuteNonQuery();

                                if (result > 0)
                                {
                                    transaction.Commit();
                                    return true;
                                }
                                else
                                {
                                    transaction.Rollback();
                                    _lastError = "没有行被影响";
                                    return false;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            _lastError = $"执行SQL命令时出错: {ex.Message}";
                            Console.WriteLine($"SQL错误: {ex}");
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                _lastError = $"MySQL错误 (代码 {mySqlEx.Number}): {mySqlEx.Message}";
                Console.WriteLine($"MySQL错误: {mySqlEx}");
                return false;
            }
            catch (Exception ex)
            {
                _lastError = $"数据库操作失败: {ex.Message}";
                Console.WriteLine($"数据库错误: {ex}");
                return false;
            }
        }

        public bool UpdateWorkOrder(WorkOrderList workOrder, int batchQty)
        {
            _lastError = null;

            if (workOrder == null)
            {
                _lastError = "工单对象为空";
                return false;
            }

            try
            {
                using (var connection = new MySqlConnection(_repository._connectionString))
                {
                    connection.Open();

                    string sql = @"UPDATE work_order_list 
                          SET created_not_produce_num = created_not_produce_num + @BatchQty 
                          WHERE work_order_id = @WorkOrderId";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@createdNotProduceNum", workOrder.CreatedNotProduceNum);
                        command.Parameters.AddWithValue("@workOrderId", workOrder.WorkOrderId);
                        command.Parameters.AddWithValue("@BatchQty", batchQty);
                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _lastError = ex.Message;
                Console.WriteLine($"更新工单失败: {ex}");
                return false;
            }
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

        public bool UpdateBatch(MDM.Model.BatchEntities.Batch batch)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE batch SET CreateTime = @CreateTime WHERE BatchId = @BatchId";

                    using (MySqlCommand cmd = new MySqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@CreateTime", batch.CreateTime);
                        cmd.Parameters.AddWithValue("@BatchId", batch.BatchId);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteBatch(string batchId)
        {
            try
            {
                using (var connection = new MySqlConnection(_repository._connectionString))
                {
                    connection.Open();

                    string sql = @"DELETE FROM batch WHERE batch_id = @BatchId";

                    using (var command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BatchId", batchId);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            return true;
                        }
                        else
                        {
                            _lastError = "没有行被影响";
                            return false;
                        }
                    }
                }
            }
            catch (MySqlException mySqlEx)
            {
                _lastError = $"MySQL错误 (代码 {mySqlEx.Number}): {mySqlEx.Message}";
                Console.WriteLine($"MySQL错误: {mySqlEx}");
                return false;
            }
            catch (Exception ex)
            {
                _lastError = $"数据库操作失败: {ex.Message}";
                Console.WriteLine($"数据库错误: {ex}");
                return false;
            }
        }

        // 根据批次号获取批次流转表信息
        public List<BatchFlow> GetBatchFlowByBatchId(string batchId)
        {
            return _repository.GetBatchFlowByBatchId(batchId);
        }

        //保存锁定信息
        public bool SaveLockedBatch(LockedBatch lockedBatch)
        {
            try
            {
                using (var connection = new MySqlConnection(_repository._connectionString))
                {
                    connection.Open();
                    var sql = @"INSERT INTO locked_batch 
                (batch_id, lock_time, lock_code, lock_description, locked_by, 
                detain_code_group, reason_process_flow, reason_station, 
                reason_operation_desc, reason_equipment, event_remark,lock_id)
                VALUES 
                (@BatchId, @LockTime, @LockCode, @LockDescription, @LockedBy, 
                @DetainCodeGroup, @ReasonProcessFlow, @ReasonStation, 
                @ReasonOperationDesc, @ReasonEquipment,@EventRemark,@LockId)";  // 添加参数

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
                        command.Parameters.AddWithValue("@EventRemark", lockedBatch.EventRemark);

                        // 生成一个新的lock_id值
                        command.Parameters.AddWithValue("@LockId", Guid.NewGuid().ToString()); // 或者使用其他ID生成方式

                        var result = command.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                _lastError = $"保存锁定信息时出错: {ex.Message}";
                Console.WriteLine($"保存锁定信息时出错: {ex.Message}");
                return false;
            }
        }

        // 查询数据库中最新的批次号
        public string GenerateNextBatchId()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    // 使用事务确保并发安全
                    using (var transaction = connection.BeginTransaction())
                    {
                        // 获取当前最大批次号
                        string query = "SELECT batch_id FROM batch ORDER BY batch_id DESC LIMIT 1 FOR UPDATE";
                        string latestBatchId;

                        using (var command = new MySqlCommand(query, connection, transaction))
                        {
                            latestBatchId = command.ExecuteScalar()?.ToString();
                        }

                        int nextNumber = 1;
                        if (!string.IsNullOrEmpty(latestBatchId) &&
                            latestBatchId.StartsWith("B") &&
                            int.TryParse(latestBatchId.Substring(1), out int lastNumber))
                        {
                            nextNumber = lastNumber + 1;
                        }

                        // 更新到数据库中的序列表（可选）
                        // 这里直接返回生成的批次号
                        transaction.Commit();
                        return $"B{nextNumber:D3}";
                    }
                }
            }
            catch (Exception ex)
            {
                // 记录日志
                throw new Exception("生成批次号失败", ex);
            }
        }
    }
 }