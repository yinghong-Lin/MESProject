using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    public class EqpGroup
    {
        [Key]
        [Required(ErrorMessage = "设备组ID是必填项")]
        public string EqpGroupId { get; set; } = null!;

        [Required(ErrorMessage = "设备组类型是必填项")]
        public string EqpGroupType { get; set; } = null!;

        public string? EqpGroupDescription { get; set; }

        public string? FactoryId { get; set; }

        public string? EventUser { get; set; }

        public string? EventRemark { get; set; }

        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        public string? EventType { get; set; }
    }
}
