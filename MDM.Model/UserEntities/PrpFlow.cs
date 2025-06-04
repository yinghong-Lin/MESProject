namespace MDM.Model.UserEntities
{
    public class PrpFlow
    {
        public int Id { get; set; }
        public int PrpId { get; set; }
        public int FId { get; set; }

        // 关联的工艺包信息
        public Prp Prp { get; set; }

        // 关联的工艺流程信息
        public Flow Flow { get; set; }
    }
}
