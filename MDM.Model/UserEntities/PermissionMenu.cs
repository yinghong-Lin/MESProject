using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.UserEntities
{
    public class PermissionMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "权限编号是必填项")]
        [StringLength(50)]
        public string PermissionId { get; set; } = null!;

        [Required(ErrorMessage = "菜单编号是必填项")]
        public int MenuId { get; set; }

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