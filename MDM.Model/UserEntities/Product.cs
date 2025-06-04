using System;

namespace MDM.Model.UserEntities
{
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductType { get; set; }
        public string ProductDetailType { get; set; }
        public string ProductDescription { get; set; }
        public string ProductState { get; set; }
        public string Unit { get; set; }
        public string BomId { get; set; }
        public string BomVersion { get; set; }
        public string ProductGroupId { get; set; }
        public string FactoryId { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string EventType { get; set; }
    }
}
