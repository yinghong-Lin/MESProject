using MDM.DAL;
using System.Data;

namespace MDM.BLL
{
    public class WorkOrderBLL
    {
        private readonly WorkOrderDAL _dal = new WorkOrderDAL();

        public DataTable GetDistinctWorkOrderTypes()
        {
            return _dal.GetDistinctWorkOrderTypes();
        }

        public DataTable GetProductList()
        {
            return _dal.GetProductList();
        }

        public DataTable GetProductDetails(string productCode)
        {
            return _dal.GetProductDetails(productCode);
        }


        public DataTable GetWorkOrderList()
        {
            return _dal.GetWorkOrderList();
        }
        public bool CheckUserExists(string userId)
        {
            return _dal.CheckUserExists(userId);
        }
    }
}