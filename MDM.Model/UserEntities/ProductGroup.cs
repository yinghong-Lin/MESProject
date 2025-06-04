using System;

namespace MDM.Model.UserEntities
{
    public class ProductGroup
    {
        public string ProductGroupId { get; set; }
        public string ProductGroupDescription { get; set; }
        public string FactoryId { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string EventType { get; set; }
    }
}
