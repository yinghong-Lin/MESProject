namespace MDM.Model
{
    public class WorkOrder
    {
        public string WorkOrderId { get; set; }
        public string WorkOrderType { get; set; }
        public string WorkOrderDescription { get; set; }
        public string FinishedWorkOrderNo { get; set; }
        public string Bom { get; set; }
        public string BomVersion { get; set; }
        public string ProductType { get; set; }
        public string DetailType { get; set; }
        public string ProductId { get; set; }
        public string ProcessFlow { get; set; } // 工艺流程号
        public string ProcessVersion { get; set; } // 工艺版本
        public int PlannedQuantity { get; set; }
        public string TestProgram { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? PlannedStartDate { get; set; }
        public DateTime? PlannedEndDate { get; set; }
        public string CustomerLotNo { get; set; }
        public string ProductCategory { get; set; }
        public string Unit { get; set; }
        public string FilmThickness { get; set; }
        public string PackageForm { get; set; }
        public string WorkOrderStatus { get; set; }
        public string ProductDescription { get; set; }
    }
}