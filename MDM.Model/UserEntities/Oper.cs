using System;

namespace MDM.Model.UserEntities
{
    public class Oper
    {
        public int Id { get; set; }
        public string OperId { get; set; }
        public string OperVersion { get; set; }
        public bool IsActive { get; set; }
        public string OperDescription { get; set; }
        public string ReleaseState { get; set; }
        public string OperType { get; set; }
        public string OperDetailType { get; set; }
        public bool IsTrackin { get; set; }
        public bool ScanCarrierTrackin { get; set; }
        public bool ScanCarrierTrackout { get; set; }
        public int? OperHour { get; set; }
        public string FactoryId { get; set; }
        public string EventUser { get; set; }
        public string EventRemark { get; set; }
        public DateTime? EditTime { get; set; }
        public DateTime CreateTime { get; set; }
        public string EventType { get; set; }
    }
}
