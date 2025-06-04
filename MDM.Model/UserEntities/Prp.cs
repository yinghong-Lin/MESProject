using System;

namespace MDM.Model.UserEntities
{
    public class Prp
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string PrpVersion { get; set; }
        public bool IsActive { get; set; }
        public string PrpDescription { get; set; }
        public string ReleaseState { get; set; }
        public string MainFlow { get; set; }
        public string PrpType { get; set; }
        public string FlowPrpType { get; set; }
        public string FactoryId { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string EventType { get; set; }

        // 关联的产品信息
        public Product Product { get; set; }
    }
}
