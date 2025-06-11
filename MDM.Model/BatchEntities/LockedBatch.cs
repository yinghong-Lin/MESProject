using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.BatchEntities
{
    public class LockedBatch
    {
        public string? LockId { get; set; } // 锁定记录ID
        public string? BatchId { get; set; } // 批次号
        public DateTime LockTime { get; set; } // 锁定时间
        public string? LockCode { get; set; } // 锁定代码
        public string? LockDescription { get; set; } // 锁定说明
        public string? LockedBy { get; set; } // 锁定用户
        public string? LotReasonGroup { get; set; } // Lot原因组
        public string? ReasonProcessFlow { get; set; } // 原因工艺流程
        public string? ReasonStation { get; set; } // 原因工站
        public string? ReasonOperationDesc { get; set; } // 原因工序说明
        public int? ReasonEquipment { get; set; } // 原因设备号
        public string? EventRemark { get; set; } // 事件备注
        public string? WorkOrderId { get; set; } // 关联工单号
        public string? ProductId { get; set; } // 产品编号
        public string? DetainCodeGroup { get; set; } // 滞留代码组别
    }
}