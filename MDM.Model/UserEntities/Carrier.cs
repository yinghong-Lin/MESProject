using System;

namespace MDM.Model.UserEntities
{
    public class Carrier
    {
        public string CarrierNo { get; set; }
        public string CarrierType { get; set; }
        public string CarrierDetailType { get; set; }
        public string DurableId { get; set; }
        public string EquipmentId { get; set; }
        public string PortId { get; set; }
        public string CarrierStatus { get; set; }
        public string CleaningStatus { get; set; }
        public string LockStatus { get; set; }
        public int BatchCapacity { get; set; }
        public int CurrentQty { get; set; }
        public string CapacityStatus { get; set; }
        public string Location { get; set; }
        public DateTime? LastMaintenanceDate { get; set; }
    }
}
