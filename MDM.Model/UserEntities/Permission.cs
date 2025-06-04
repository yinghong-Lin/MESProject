using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.UserEntities
{
    public class Permission
    {
        [Key]
        [Required(ErrorMessage = "权限号是必填项")]
        [StringLength(50)]
        public string PermissionId { get; set; } = null!;

        [Required(ErrorMessage = "权限名是必填项")]
        [StringLength(100)]
        public string PermissionName { get; set; } = null!;

        public string? PermissionDescription { get; set; }

        [StringLength(50)]
        public string? PermissionType { get; set; }

        [StringLength(50)]
        public string? SystemId { get; set; }

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