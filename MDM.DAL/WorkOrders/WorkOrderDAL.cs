using System.Data;
using MySql.Data.MySqlClient;

namespace MDM.DAL
{
    public class WorkOrderDAL
    {
        private readonly string _connString = "Server=localhost;Database=mdm_db;User ID=root;Password=123456;";

        public DataTable GetDistinctWorkOrderTypes()
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = @"SELECT DISTINCT 
                                work_order_type AS TypeCode,
                                work_order_description AS TypeDescription,
                                detail_type AS DetailType
                              FROM work_order_list";
                var cmd = new MySqlCommand(sql, conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetProductList()
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = @"SELECT DISTINCT 
                                product_id AS ProductCode,
                                product_description AS ProductDescription
                              FROM work_order_list";
                var cmd = new MySqlCommand(sql, conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetProductDetails(string productCode)
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = @"SELECT 
                                product_type AS ProductType,
                                product_category AS ProductCategory,
                                process_flow AS ProcessFlow,
                                bom AS BOM,
                                bom_version AS BOMVersion,
                                unit AS Unit,
                                package_form AS PackagingForm,
                                process_version AS ProcessVersion -- 确保包含 ProcessVersion 列
                              FROM work_order_list
                              WHERE product_id = @productCode";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@productCode", productCode);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public DataTable GetWorkOrderList()
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = @"SELECT 
                        work_order_id,
                        work_order_type,
                        work_order_description,
                        finished_work_order_no,
                        bom,
                        bom_version,
                        product_type,
                        detail_type,
                        product_id,
                        process_flow,
                        planned_quantity,
                        test_program,
                        company_code,
                        planned_start_date,
                        planned_end_date,
                        customer_lot_no,
                        product_category,
                        unit,
                        film_thickness,
                        package_form,
                        work_order_status,
                        product_description
                      FROM work_order_list";
                var cmd = new MySqlCommand(sql, conn);
                var da = new MySqlDataAdapter(cmd);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public bool CheckUserExists(string userId)
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = "SELECT COUNT(*) FROM users WHERE user_id = @userId";
                var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userId", userId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // 修改 WorkOrderDAL.cs 中的 InsertWorkOrder 方法
        public void InsertWorkOrder(
           string workOrderId,
           string workOrderType,
           string workOrderDescription,
           string finishedWorkOrderNo,
           string bom,
           string bomVersion,
           string productType,
           string detailType,
           string productId,
           string processFlow,
           string plannedQuantity,
           string testProgram,
           string companyCode,
           string plannedStartDate,
           string plannedEndDate,
           string customerLotNo,
           string productCategory,
           string unit,
           string filmThickness,
           string packageForm,
           string workOrderStatus,
           string productDescription,
           string processVersion) // 新增工艺版本参数
        {
            using (var conn = new MySqlConnection(_connString))
            {
                conn.Open();
                string sql = @"INSERT INTO work_order_list (
                    work_order_id, work_order_type, work_order_description, finished_work_order_no, 
                    bom, bom_version, product_type, detail_type, product_id, process_flow, 
                    planned_quantity, test_program, company_code, planned_start_date, planned_end_date, 
                    customer_lot_no, product_category, unit, film_thickness, package_form, 
                    work_order_status, product_description, process_version
                ) VALUES (
                    @workOrderId, @workOrderType, @workOrderDescription, @finishedWorkOrderNo, 
                    @bom, @bomVersion, @productType, @detailType, @productId, @processFlow, 
                    @plannedQuantity, @testProgram, @companyCode, 
                    @plannedStartDate, @plannedEndDate, 
                    @customerLotNo, @productCategory, @unit, @filmThickness, @packageForm, 
                    @workOrderStatus, @productDescription, @processVersion
                )";

                var cmd = new MySqlCommand(sql, conn);

                // 添加参数
                cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
                cmd.Parameters.AddWithValue("@workOrderType", workOrderType);
                cmd.Parameters.AddWithValue("@workOrderDescription", workOrderDescription);
                cmd.Parameters.AddWithValue("@finishedWorkOrderNo",
                    string.IsNullOrWhiteSpace(finishedWorkOrderNo) ? DBNull.Value : (object)finishedWorkOrderNo);
                cmd.Parameters.AddWithValue("@bom", bom);
                cmd.Parameters.AddWithValue("@bomVersion", bomVersion);
                cmd.Parameters.AddWithValue("@productType", productType);
                cmd.Parameters.AddWithValue("@detailType", detailType);
                cmd.Parameters.AddWithValue("@productId", productId);
                cmd.Parameters.AddWithValue("@processFlow", processFlow);
                cmd.Parameters.AddWithValue("@plannedQuantity",
                    string.IsNullOrWhiteSpace(plannedQuantity) ? DBNull.Value : (object)plannedQuantity);
                cmd.Parameters.AddWithValue("@testProgram",
                    string.IsNullOrWhiteSpace(testProgram) ? DBNull.Value : (object)testProgram);
                cmd.Parameters.AddWithValue("@companyCode",
                    string.IsNullOrWhiteSpace(companyCode) ? DBNull.Value : (object)companyCode);

                // 处理日期字段 - 空字符串转换为 DBNull.Value
                cmd.Parameters.AddWithValue("@plannedStartDate",
                    string.IsNullOrWhiteSpace(plannedStartDate) ? DBNull.Value : (object)plannedStartDate);
                cmd.Parameters.AddWithValue("@plannedEndDate",
                    string.IsNullOrWhiteSpace(plannedEndDate) ? DBNull.Value : (object)plannedEndDate);

                cmd.Parameters.AddWithValue("@customerLotNo",
                    string.IsNullOrWhiteSpace(customerLotNo) ? DBNull.Value : (object)customerLotNo);
                cmd.Parameters.AddWithValue("@productCategory", productCategory);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@filmThickness",
                    string.IsNullOrWhiteSpace(filmThickness) ? DBNull.Value : (object)filmThickness);
                cmd.Parameters.AddWithValue("@packageForm", packageForm);
                cmd.Parameters.AddWithValue("@workOrderStatus",
                    string.IsNullOrWhiteSpace(workOrderStatus) ? DBNull.Value : (object)workOrderStatus);
                cmd.Parameters.AddWithValue("@productDescription", productDescription);
                cmd.Parameters.AddWithValue("@processVersion", processVersion); // 新增工艺版本参数

                cmd.ExecuteNonQuery();
            }
        }
    }
}