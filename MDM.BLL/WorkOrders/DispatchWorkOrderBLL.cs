using MDM.DAL;
using MDM.DAL.WorkOrders;
using MDM.Model;
using System;
using System.Collections.Generic;

namespace MDM.BLL
{
    public class DispatchWorkOrderBLL
    {
        private readonly DispatchWorkOrderDAL _dispatchWorkOrderDAL = new DispatchWorkOrderDAL();

        public List<WorkOrder> GetWorkOrderHeaders()
        {
            return _dispatchWorkOrderDAL.GetWorkOrderHeaders();
        }

        public List<WorkOrder> GetWorkOrdersByStartDate(DateTime? startDate)
        {
            return _dispatchWorkOrderDAL.GetWorkOrdersByStartDate(startDate);
        }

        public List<WorkOrder> GetProcessFlows()
        {
            return _dispatchWorkOrderDAL.GetProcessFlows();
        }

        public void UpdateProcessFlow(string workOrderId, string newProcessFlow, string newProcessVersion)
        {
            _dispatchWorkOrderDAL.UpdateProcessFlow(workOrderId, newProcessFlow, newProcessVersion);
        }
    }
}