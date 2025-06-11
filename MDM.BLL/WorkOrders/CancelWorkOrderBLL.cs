using MDM.DAL;
using System;
using System.Collections.Generic;
using System.Data;

namespace MDM.BLL
{
    public class CancelWorkOrderBLL
    {
        private CancelWorkOrderDAL dal = new CancelWorkOrderDAL();

        public DataTable GetWorkOrderList()
        {
            return dal.GetWorkOrderList();
        }

        // 新增方法：验证用户是否存在
        public bool CheckUserExists(string userId)
        {
            return dal.CheckUserExists(userId);
        }

        // 新增方法：删除工单
        public void DeleteWorkOrders(List<string> workOrderIds)
        {
            dal.DeleteWorkOrders(workOrderIds);
        }
    }
}