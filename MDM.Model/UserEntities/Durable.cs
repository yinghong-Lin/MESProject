using System;

namespace MDM.Model.UserEntities
{
    public class Durable
    {
        public string DurableId { get; set; }
        public string SpecDescription { get; set; }
        public string DurableType { get; set; }
        public string DurableDetailType { get; set; }
        public string DurableColor { get; set; }
        public int DurableQty { get; set; }
        public int ExpectedLife { get; set; }
        public int MaxUsage { get; set; }
        public int MaxUsageDays { get; set; }
        public int PostCleanMaxUsage { get; set; }
        public int PostCleanMaxDays { get; set; }
    }
}
