using System;

namespace MDM.Model.UserEntities
{
    public class OperWithSequence
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

        // 工艺路线特有属性
        public int OpSeq { get; set; }
        public int FlowId { get; set; }

        // 从 Oper 对象创建 OperWithSequence
        public static OperWithSequence FromOper(Oper oper, int opSeq, int flowId)
        {
            return new OperWithSequence
            {
                Id = oper.Id,
                OperId = oper.OperId,
                OperVersion = oper.OperVersion,
                IsActive = oper.IsActive,
                OperDescription = oper.OperDescription,
                ReleaseState = oper.ReleaseState,
                OperType = oper.OperType,
                OperDetailType = oper.OperDetailType,
                IsTrackin = oper.IsTrackin,
                ScanCarrierTrackin = oper.ScanCarrierTrackin,
                ScanCarrierTrackout = oper.ScanCarrierTrackout,
                OperHour = oper.OperHour,
                FactoryId = oper.FactoryId,
                EventUser = oper.EventUser,
                EventRemark = oper.EventRemark,
                EditTime = oper.EditTime,
                CreateTime = oper.CreateTime,
                EventType = oper.EventType,
                OpSeq = opSeq,
                FlowId = flowId
            };
        }
    }
}
