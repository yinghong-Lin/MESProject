using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace MDM.DAL.Process
{
    public class ReworkRepository
    {
        private readonly string _connectionString;

        public ReworkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetBatchFlowDataByBatchId(string batchId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    // 完整的SQL查询，包含所有相关表的关联
                    string sql = @"
                        SELECT 
                            b.batch_id,
                            bf.BatchType,
                            bf.Unit,
                            bf.ProductID,
                            bf.oper_id,
                            bf.Description,
                            bf.DetailStationType,
                            bf.ProcessStatus,
                            bf.EquipmentNo,
                            bf.EquipmentStatus,
                            bf.LockStatus,
                            bf.ReworkStatus,
                            bf.Location,
                            bf.ProcessFlowNo,
                            bf.ProcessFlowVersion,
                            bf.StationVersion,
                            bf.Grade,
                            bf.HotType,
                            bf.Qty,
                            bf.GoodQty,
                            bf.NGQty,
                            bf.SubProductQty,
                            bf.ParentBatch,
                            bf.BOMNo,
                            bf.BOMVersion,
                            bf.CarrierNo,
                            bf.StationType,
                            b.WorkOrderNo,
                            b.WIPStatus,
                            -- 工艺流程信息
                            f.flow_description as ProcessFlowDescription,
                            f.release_state as FlowReleaseState,
                            f.flow_type as FlowType,
                            f.flow_detail_type as FlowDetailType,
                            -- 工站信息
                            o.release_state,
                            o.oper_description as OperDescription,
                            o.oper_type as OperType,
                            o.oper_detail_type as OperDetailType,
                            o.is_trackin as IsTrackIn,
                            o.scan_carrier_trackin as ScanCarrierTrackIn,
                            o.scan_carrier_trackout as ScanCarrierTrackOut,
                            o.oper_hour as OperHour,
                            -- 产品信息
                            p.product_description as ProductDescription,
                            p.product_type as ProductType,
                            p.product_detail_type as ProductDetailType,
                            p.product_state as ProductState,
                            -- 工艺包信息
                            prp.prp_description as PrpDescription,
                            prp.release_state as PrpReleaseState,
                            prp.prp_type as PrpType,
                            prp.prp_version as PrpVersion
                        FROM batch b
                        LEFT JOIN batchflow bf ON b.batch_id = bf.batch_id
                        -- 关联工艺流程表
                        LEFT JOIN flows f ON bf.ProcessFlowNo = f.flow_id 
                            AND bf.ProcessFlowVersion = f.flow_version
                        -- 关联工站表
                        LEFT JOIN opers o ON bf.oper_id = o.oper_id
                        -- 关联产品表
                        LEFT JOIN products p ON bf.ProductID = p.product_id
                        -- 关联工艺包表
                        LEFT JOIN prps prp ON p.product_id = prp.product_id
                        WHERE b.batch_id = @BatchId";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@BatchId", batchId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"数据库查询失败: {ex.Message}", ex);
                }
            }
        }

        // 获取工艺流程详细信息
        public DataTable GetFlowDetails(string flowId, string flowVersion)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = @"
                        SELECT 
                            f.flow_id,
                            f.flow_version,
                            f.flow_description,
                            f.release_state,
                            f.flow_type,
                            f.flow_detail_type,
                            o.oper_id,
                            o.oper_description,
                            o.release_state as oper_release_state,
                            fo.op_seq
                        FROM flows f
                        LEFT JOIN flow_oper fo ON f.id = fo.f_id
                        LEFT JOIN opers o ON fo.op_id = o.id
                        WHERE f.flow_id = @FlowId AND f.flow_version = @FlowVersion
                        ORDER BY fo.op_seq";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@FlowId", flowId);
                    cmd.Parameters.AddWithValue("@FlowVersion", flowVersion);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取工艺流程详细信息失败: {ex.Message}", ex);
                }
            }
        }

        // 获取工站信息
        public DataTable GetOperationInfo(string operId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = @"
                        SELECT 
                            oper_id,
                            oper_version,
                            oper_description,
                            release_state,
                            oper_type,
                            oper_detail_type,
                            is_trackin,
                            scan_carrier_trackin,
                            scan_carrier_trackout,
                            oper_hour,
                            is_active
                        FROM opers 
                        WHERE oper_id = @OperId AND is_active = 1";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@OperId", operId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取工站信息失败: {ex.Message}", ex);
                }
            }
        }

        // 获取产品的工艺包信息
        public DataTable GetProductProcessPackage(string productId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = @"
                        SELECT 
                            prp.product_id,
                            prp.prp_version,
                            prp.prp_description,
                            prp.release_state,
                            prp.main_flow,
                            prp.prp_type,
                            f.flow_id,
                            f.flow_description,
                            f.flow_version
                        FROM prps prp
                        LEFT JOIN prp_flow pf ON prp.id = pf.prp_id
                        LEFT JOIN flows f ON pf.f_id = f.id
                        WHERE prp.product_id = @ProductId AND prp.is_active = 1";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ProductId", productId);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取产品工艺包信息失败: {ex.Message}", ex);
                }
            }
        }

        // 获取所有批次信息的方法（用于测试或列表显示）
        public DataTable GetAllBatches()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = @"
                        SELECT 
                            batch_id,
                            BatchType,
                            ProductID,
                            WorkOrderNo,
                            WIPStatus,
                            LockStatus
                        FROM batch 
                        ORDER BY batch_id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取批次列表失败: {ex.Message}", ex);
                }
            }
        }

        // 验证批次是否存在
        public bool BatchExists(string batchId)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT COUNT(*) FROM batch WHERE batch_id = @BatchId";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@BatchId", batchId);

                    conn.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception($"验证批次存在性失败: {ex.Message}", ex);
                }
            }
        }

        // 获取返修流程选项 - 返回该批次的工艺流程信息
        public DataTable GetReworkFlowOptions()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    // 修改SQL查询以匹配实际数据库结构
                    string sql = @"
                SELECT DISTINCT
                    f.flow_id,
                    f.flow_version,
                    f.flow_description,
                    CONCAT(f.flow_id, ' - ', f.flow_version, ' - ', IFNULL(f.flow_description, '')) as DisplayText
                FROM flows f
                WHERE f.is_active = 1
                ORDER BY f.flow_id, f.flow_version";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取返修流程选项失败: {ex.Message}", ex);
                }
            }
        }

        // 获取返修工艺选项 - 返回工艺包信息
        public DataTable GetReworkProcessOptions()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    // 修改SQL查询以匹配实际数据库结构
                    string sql = @"
                SELECT DISTINCT
                    prp.product_id,
                    prp.prp_version,
                    prp.prp_description,
                    CONCAT(prp.product_id, ' - ', prp.prp_version, ' - ', IFNULL(prp.prp_description, '')) as DisplayText
                FROM prps prp
                WHERE prp.is_active = 1
                ORDER BY prp.product_id, prp.prp_version";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取返修工艺选项失败: {ex.Message}", ex);
                }
            }
        }

        // 获取返回工站选项
        public DataTable GetReturnStationOptions()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    // 修改SQL查询以匹配实际数据库结构
                    string sql = @"
                SELECT DISTINCT
                    o.oper_id,
                    o.oper_version,
                    o.oper_description,
                    CONCAT(o.oper_id, ' - ', o.oper_version, ' - ', IFNULL(o.oper_description, '')) as DisplayText
                FROM opers o
                WHERE o.is_active = 1
                ORDER BY o.oper_id, o.oper_version";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取返回工站选项失败: {ex.Message}", ex);
                }
            }
        }

        // 获取原因代码选项
        public DataTable GetReasonCodeOptions()
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    string sql = @"
                SELECT DISTINCT
                    reason_code,
                    reason_description,
                    CONCAT(reason_code, ' - ', reason_description) as DisplayText
                FROM reason_codes
                WHERE is_active = 1
                ORDER BY reason_code";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception($"获取原因代码选项失败: {ex.Message}", ex);
                }
            }
        }

        // 更新批次返修信息
        public bool UpdateBatchReworkInfo(string batchId, string reworkFlowId, string reworkFlowVersion,
            string reworkProcessId, string reworkProcessVersion, string returnStationId, string returnStationVersion,
            string reasonCode, string remark)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            // 更新批次表中的返修状态 - 只更新存在的字段
                            string updateBatchSql = @"
UPDATE batch 
SET 
    ProcessFlowNo = @ReworkFlowId,
    ProcessFlowVersion = @ReworkFlowVersion,
    oper_id = @ReturnStationId
WHERE batch_id = @BatchId";

                            MySqlCommand updateBatchCmd = new MySqlCommand(updateBatchSql, conn, transaction);
                            updateBatchCmd.Parameters.AddWithValue("@BatchId", batchId);
                            updateBatchCmd.Parameters.AddWithValue("@ReworkFlowId", reworkFlowId);
                            updateBatchCmd.Parameters.AddWithValue("@ReworkFlowVersion", reworkFlowVersion);
                            updateBatchCmd.Parameters.AddWithValue("@ReturnStationId", returnStationId);
                            updateBatchCmd.ExecuteNonQuery();

                            // 更新批次流转表中的返修信息
                            string updateBatchFlowSql = @"
UPDATE batchflow 
SET 
    ReworkStatus = 'InRework',
    ProcessFlowNo = @ReworkFlowId,
    ProcessFlowVersion = @ReworkFlowVersion,
    oper_id = @ReturnStationId,
    StationVersion = @ReturnStationVersion,
    Description = CONCAT(IFNULL(Description, ''), ' 返修: ', @Remark)
WHERE batch_id = @BatchId";

                            MySqlCommand updateBatchFlowCmd = new MySqlCommand(updateBatchFlowSql, conn, transaction);
                            updateBatchFlowCmd.Parameters.AddWithValue("@BatchId", batchId);
                            updateBatchFlowCmd.Parameters.AddWithValue("@ReworkFlowId", reworkFlowId);
                            updateBatchFlowCmd.Parameters.AddWithValue("@ReworkFlowVersion", reworkFlowVersion);
                            updateBatchFlowCmd.Parameters.AddWithValue("@ReturnStationId", returnStationId);
                            updateBatchFlowCmd.Parameters.AddWithValue("@ReturnStationVersion", returnStationVersion);
                            updateBatchFlowCmd.Parameters.AddWithValue("@Remark", remark);
                            updateBatchFlowCmd.ExecuteNonQuery();

                            // 创建返修记录表（如果需要的话）
                            // 这里可以添加插入返修记录表的代码

                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception($"更新批次返修信息失败: {ex.Message}", ex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"连接数据库失败: {ex.Message}", ex);
                }
            }
        }
    }
}
