using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.BatchEntities
{
    public class Batch
    {
        public string? BatchId { get; set; } // 批次号
        public string? BatchType { get; set; } // 批次类型
        public string? Unit { get; set; } // 单位
        public string? DetailType { get; set; } // 详细类型
        public int BatchQty { get; set; } // 批次数量
        public int SubProductQty { get; set; } // 子产品数量
        public string? WIPStatus { get; set; } // 在制品状态
        public string? LockStatus { get; set; } // 锁定状态
        public string? WorkOrderNo { get; set; } // 工单号
        public string? ProductId { get; set; } // 产品编号
        public string? ProcessFlowNo { get; set; } // 工艺流程号
        public string? ProcessFlowVersion { get; set; } // 工艺流程版本
        public string? StationNo { get; set; } // 工站号
        public DateTime? CreateTime { get; set; }//创建时间
    }
}
