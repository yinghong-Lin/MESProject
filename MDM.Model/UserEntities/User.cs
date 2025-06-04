using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDM.Model.UserEntities
{
    public class User
    {
        [Key]
        [Required(ErrorMessage = "用户编号是必填项")]
        [RegularExpression(@"^[a-zA-Z0-9]{2,50}$",
            ErrorMessage = "用户编号必须为2-50位英文或数字组合")]
        public string UserId { get; set; } = null!;

        [Required(ErrorMessage = "用户类型是必填项")]
        public string UserType { get; set; } = null!;

        [Required(ErrorMessage = "用户名是必填项")]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = "用户密码是必填项")]
        public string UserPassword { get; set; } = null!;

        public string? UserEnglishName { get; set; }
        public string? DisplayLanguage { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public string? EventUser { get; set; }
        public string? EventRemark { get; set; }
        public DateTime? EditTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? CreateTime { get; set; }

        public string? EventType { get; set; }
    }
}
