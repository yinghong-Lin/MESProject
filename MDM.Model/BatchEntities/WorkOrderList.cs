using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.BatchEntities
{
    public class WorkOrderList
    {
        public required string WorkOrderId { get; set; } // 工单号
        public string? WorkOrderType { get; set; } // 工单类型
        public string? WorkOrderDescription { get; set; } // 工单说明
        public string? FinishedWorkOrderNo { get; set; } // 成品工单号
        public string? Bom { get; set; } // BOM编号
        public string? BomVersion { get; set; } // BOM版本
        public string? ProductType { get; set; } // 产品类型
        public string? DetailType { get; set; } // 详细类型
        public string? ProductId { get; set; } // 产品编号
        public string? ProcessFlow { get; set; } // 工艺流程号
        public int? PlannedQuantity { get; set; } // 计划数量
        public string? TestProgram { get; set; } // 测试程序号
        public string? CompanyCode { get; set; } // 公司号
        public DateTime? PlannedStartDate { get; set; } // 计划开始日期
        public DateTime? PlannedEndDate { get; set; } // 计划结束日期
        public string? CustomerLotNo { get; set; } // 客户批次号
        public string? ProductCategory { get; set; } // 产品类别
        public string? Unit { get; set; } // 单位
        public string? FilmThickness { get; set; } // 膜片厚度
        public string? PackageForm { get; set; } // 封装形式
        public string? WorkOrderStatus { get; set; } // 工单状态
        public string? ProductDescription { get; set; } // 产品说明
        public string? ProductDetailType { get; set; } // 详细产品类型
        public int? InputNum { get; set; } // 投入数量
        public int? OnputNum { get; set; } // 产出数量
        public int? DestroyNum { get; set; } // 报废数量
        public int? CreatedNotProduceNum { get; set; } // 已创建未投产数量
    }
}