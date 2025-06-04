using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    public class Port
    {
        [Key]
        [Required(ErrorMessage = "端口ID是必填项")]
        public string PortId { get; set; } = null!;

        [Required(ErrorMessage = "端口类型是必填项")]
        public string PortType { get; set; } = null!;

        [Required(ErrorMessage = "端口详细类型是必填项")]
        public string PortDetailType { get; set; } = null!;

        public string? PortDescription { get; set; }

        public string? EqpId { get; set; }

        public string? EventUser { get; set; }

        public string? EventRemark { get; set; }

        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public string? EventType { get; set; }
    }
}
