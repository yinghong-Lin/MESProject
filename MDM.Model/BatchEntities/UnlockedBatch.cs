using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.BatchEntities
{
    public class UnlockedBatch
    {
        public string? UnlockId { get; set; } // 解锁记录ID
        public string? ReasonCode { get; set; } // 原因代码
        public string? ReasonCodeDescription { get; set; } // 原因代码说明
        public string? UnlockComment { get; set; } // 解锁意见
        public string? EventRemark { get; set; } // 事件备注
    }
}