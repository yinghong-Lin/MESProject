using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.UserEntities
{
    internal class Material
    {
        
            public string MaterialNo { get; set; } // 物料号
            public string MaterialDescription { get; set; } // 物料描述
            public string MaterialType { get; set; } // 物料类型
            public string DetailedType { get; set; } // 详细类型
            public string MaterialName { get; set; } // 物料名
            public string Unit { get; set; } // 单位
            public string MaterialGroup { get; set; } // 物料组
            public float Quantity { get; set; } // 数量
            public string CalculateY { get; set; } // 计算公式
            public string EquipmentModel { get; set; } // 设备配套型
            public string SupplierNo { get; set; } // 供应商号
            public string SupplierMaterialNo { get; set; } // 供应商物料号
        
    }
}
