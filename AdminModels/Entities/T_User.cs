using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AdminModels.Entities
{
    public class T_User : ModelBase
    {
        public T_User()
        {
            this.Roles = new Collection<T_Role>();
            this.Groups = new Collection<T_Group>();
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(20)]
        [Display(Name = "用户名")]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MinLength(6)]
        [MaxLength(20)]
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        [Display(Name = "姓名"), UIHint("String")]
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(11)]
        [MinLength(11)]
        [Display(Name = "手机号")]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(50)]
        [MinLength(5)]
        [Display(Name = "电子邮箱")]
        public string Email { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        [Display(Name = "登陆次数")]
        public long LoginCount { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [ForeignKey("RoleId")]
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<T_Role> Roles { get; set; }

        /// <summary>
        /// 组集合
        /// </summary>
        [ForeignKey("GroupId")]
        [HiddenInput(DisplayValue = false)]
        public virtual ICollection<T_Group> Groups { get; set; }
    }
}