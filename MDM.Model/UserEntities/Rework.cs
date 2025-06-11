using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    [Table("batch")]
    public class Batch
    {
        [Key]
        [Column("batch_id")]
        public string BatchId { get; set; }

        [Column("BatchType")]
        public string BatchType { get; set; }

        [Column("Unit")]
        public string Unit { get; set; }

        [Column("DetailType")]
        public string DetailType { get; set; }

        [Column("BatchQty")]
        public int BatchQty { get; set; }

        [Column("SubProductQty")]
        public int SubProductQty { get; set; }

        [Column("WIPStatus")]
        public string WIPStatus { get; set; }

        [Column("LockStatus")]
        public string LockStatus { get; set; }

        [Column("WorkOrderNo")]
        public string WorkOrderNo { get; set; }

        [Column("ProductID")]
        public string ProductID { get; set; }

        [Column("ProcessFlowNo")]
        public string ProcessFlowNo { get; set; }

        [Column("ProcessFlowVersion")]
        public string ProcessFlowVersion { get; set; }

        [Column("oper_id")]
        public string OperId { get; set; }
    }

    [Table("batchflow")]
    public class BatchFlow
    {
        [Key]
        [Column("batch_id")]
        public string BatchId { get; set; }

        [Column("Qty")]
        public decimal Qty { get; set; }

        [Column("GoodQty")]
        public decimal GoodQty { get; set; }

        [Column("NGQty")]
        public decimal NGQty { get; set; }

        [Column("SubProductQty")]
        public decimal SubProductQty { get; set; }

        [Column("BatchType")]
        public string BatchType { get; set; }

        [Column("Unit")]
        public string Unit { get; set; }

        [Column("ProductID")]
        public string ProductID { get; set; }

        [Column("oper_id")]
        public string OperId { get; set; }

        [Column("Description")]
        public string Description { get; set; }

        [Column("DetailStationType")]
        public string DetailStationType { get; set; }

        [Column("ProcessStatus")]
        public string ProcessStatus { get; set; }

        [Column("EquipmentNo")]
        public string EquipmentNo { get; set; }

        [Column("EquipmentStatus")]
        public string EquipmentStatus { get; set; }

        [Column("LockStatus")]
        public string LockStatus { get; set; }

        [Column("ReworkStatus")]
        public string ReworkStatus { get; set; }

        [Column("Location")]
        public string Location { get; set; }

        [Column("ProcessFlowNo")]
        public string ProcessFlowNo { get; set; }

        [Column("ProcessPackageVersion")]
        public string ProcessPackageVersion { get; set; }

        [Column("ProcessFlowVersion")]
        public string ProcessFlowVersion { get; set; }

        [Column("StationVersion")]
        public string StationVersion { get; set; }

        [Column("Grade")]
        public string Grade { get; set; }

        [Column("HotType")]
        public string HotType { get; set; }

        [Column("ProductionStartDate")]
        public DateTime ProductionStartDate { get; set; }

        [Column("OutboundDate")]
        public DateTime? OutboundDate { get; set; }

        [Column("StationChangeDate")]
        public DateTime? StationChangeDate { get; set; }

        [Column("ParentBatch")]
        public string ParentBatch { get; set; }

        [Column("SubUnit")]
        public string SubUnit { get; set; }

        [Column("BOMNo")]
        public string BOMNo { get; set; }

        [Column("BOMVersion")]
        public string BOMVersion { get; set; }

        [Column("UsedSubBatch")]
        public string UsedSubBatch { get; set; }

        [Column("CarrierNo")]
        public string CarrierNo { get; set; }

        [Column("StationType")]
        public string StationType { get; set; }
    }
}