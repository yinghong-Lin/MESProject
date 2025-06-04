using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    public class EqpGroupHis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string EqpGroupId { get; set; } = null!;

        [Required]
        [StringLength(100)]
        public string EqpGroupType { get; set; } = null!;

        public string? EqpGroupDescription { get; set; }

        [StringLength(100)]
        public string? FactoryId { get; set; }

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
