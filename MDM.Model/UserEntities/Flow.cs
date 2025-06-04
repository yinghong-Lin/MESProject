using System;

namespace MDM.Model.UserEntities
{
    public class Flow
    {
        public int Id { get; set; }
        public string FlowId { get; set; }
        public string FlowVersion { get; set; }
        public bool IsActive { get; set; }
        public string FlowDescription { get; set; }
        public string ReleaseState { get; set; }
        public string FlowType { get; set; }
        public string FlowDetailType { get; set; }
        public string FactoryId { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public string EventType { get; set; }
    }
}
