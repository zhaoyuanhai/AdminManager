using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_User : ModelBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public long LoginCount { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public virtual ICollection<T_Role> Roles { get; set; }

        /// <summary>
        /// 权限列表
        /// </summary>
        public virtual ICollection<T_Authority> Authorities { get; set; }

        /// <summary>
        /// 组集合
        /// </summary>
        public virtual ICollection<T_Group> Groups { get; set; }

        /// <summary>
        /// 菜单列表
        /// </summary>
        public virtual ICollection<T_Menu> Menus { get; set; }
    }
}
