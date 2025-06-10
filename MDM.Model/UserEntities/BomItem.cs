namespace MDM.Model.UserEntities
{
    public class BomItem
    {
        public int Id { get; set; }
        public string MaterialNo { get; set; } // 物料号
        public string MaterialName { get; set; } // 物料名
        public string MaterialType { get; set; } // 物料类型
        public string DetailedMaterialType { get; set; } // 详细物料类型
        public int ConsumptionQuantity { get; set; } // 消耗数量
        public string MaterialUnit { get; set; } // 物料单位
        public string BomNo { get; set; } // BOM编号
        public int MaterialBatchQuantity { get; set; } // 物料批次数量

        // 关联的BOM信息
        public Bom Bom { get; set; }

        // 关联的物料信息
       // public Material Material { get; set; }
    }

    public class Bom
    {
        public int Id { get; set; }
        public string BomNo { get; set; } // BOM编号
        public string Description { get; set; } // 描述
        public List<BomItem> BomItems { get; set; } = new List<BomItem>();
    }

   
}