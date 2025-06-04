namespace MDM.Model.UserEntities
{
    public class FlowOper
    {
        public int Id { get; set; }
        public int FId { get; set; }
        public int OpId { get; set; }
        public int OpSeq { get; set; }

        // 关联的工艺流程信息
        public Flow Flow { get; set; }

        // 关联的工站信息
        public Oper Oper { get; set; }
    }
}
