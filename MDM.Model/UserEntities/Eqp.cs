using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    public class Eqp
    {
        [Key]
        [Required(ErrorMessage = "设备号是必填项")]
        public string EqpId { get; set; } = null!;

        [Required(ErrorMessage = "设备类型是必填项")]
        public string EqpType { get; set; } = null!;

        [Required(ErrorMessage = "设备详细类型是必填项")]
        public string EqpDetailType { get; set; } = null!;

        public string? EqpDescription { get; set; }

        public string? EqpGroupId { get; set; }

        public string? ParentEqpId { get; set; }

        public string? EqpLevel { get; set; }

        public string? EventUser { get; set; }

        public string? EventRemark { get; set; }

        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string? EventType { get; set; }

        // 工厂ID字段，不存储在数据库中，仅用于显示
        [NotMapped]
        public string? FactoryId { get; set; }
    }
}