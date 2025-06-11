using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.BatchEntities
{
    public class BatchFlow
    {
        public string? BatchId { get; set; } // 批次号
        public decimal Qty { get; set; } // 数量
        public decimal GoodQty { get; set; } // Good 数量
        public decimal NGQty { get; set; } // NG 数量
        public decimal SubProductQty { get; set; } // 子产品数量
        public string? BatchType { get; set; } // 批次类型
        public string? Unit { get; set; } // 单位
        public string? ProductId { get; set; } // 产品编号
        public string? OperId { get; set; } // 工站号
        public string? Description { get; set; } // 描述
        public string? DetailStationType { get; set; } // 详细工站类型
        public string? ProcessStatus { get; set; } // 制程状态
        public string? EquipmentNo { get; set; } // 设备号
        public string? EquipmentStatus { get; set; } // 设备状态
        public string? LockStatus { get; set; } // 锁定状态
        public string? ReworkStatus { get; set; } // 返修状态
        public string? Location { get; set; } // 位置
        public string? ProcessFlowNo { get; set; } // 工艺流程号
        public string? ProcessPackageVersion { get; set; } // 工艺包版本
        public string? ProcessFlowVersion { get; set; } // 工艺流程版本
        public string?StationVersion { get; set; } // 工站版本
        public string? Grade { get; set; } // 等级
        public string? HotType { get; set; } // Hot 类型
        public DateTime ProductionStartDate { get; set; } // 投产时间
        public DateTime? OutboundDate { get; set; } // 出站时间
        public DateTime? StationChangeDate { get; set; } // 工站变更时间
        public string? ParentBatch { get; set; } // 父批次号
        public string? SubUnit { get; set; } // 子单位
        public string? BOMNo { get; set; } // 物料清单编号
        public string? BOMVersion { get; set; } // 物料清单版本
        public string? UsedSubBatch { get; set; } // 使用子批次
        public string? CarrierNo { get; set; } // 载具号
        public string? StationType { get; set; } // 工站类型
        public string? DetailType { get; set; } // 详细类型
        public string? WorkOrderId { get; set; } // 工单号
        public string? OnProductState { get; set; } // 在制品状态
        public string? RepairState { get; set; } // 维修状态
        public string? FlowDescription { get; set; } // 工艺流程描述
        public int DestroyNum { get; set; } // 报废数量
        public string? FlowState { get; set; } // 工艺状态
        public string? ProcessName { get; set; } // 程序名
        public string? LockCode {  get; set; }//锁定代码
        public string? DetainCodeGroup { get; set; } // 滞留代码组别
    }
}