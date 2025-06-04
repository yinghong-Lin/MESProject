using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDM.Model.UserEntities
{
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "菜单名是必填项")]
        [StringLength(100)]
        public string MenuName { get; set; } = null!;

        [StringLength(10)]
        public string? FunctionId { get; set; }

        public string? MenuDescription { get; set; }

        public int ParentMenuId { get; set; }

        [StringLength(100)]
        public string? EventUser { get; set; }

        public string? EventRemark { get; set; }

        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? CreateTime { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? EventType { get; set; }
    }
}