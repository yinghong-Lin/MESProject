using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    // 工厂表模型
    public class Factory
    {
        [Key]
        [Required(ErrorMessage = "工厂ID是必填项")]
        public int FactoryId { get; set; }

        [Required(ErrorMessage = "工厂类型是必填项")]
        [StringLength(50)]
        public string FactoryType { get; set; } = null!;

        [StringLength(200)]
        public string? FactoryDescription { get; set; }

        [StringLength(100)]
        public string? EventUser { get; set; }

        public string? EventRemark { get; set; }

        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreateTime { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? EventType { get; set; }
    }
}
