using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_User : ModelBase
    {
        public T_User()
        {
            this.Roles = new List<T_Role>();
            this.Groups = new List<T_Group>();
        }

        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [MinLength(6)]
        [MaxLength(20)]
        [Required]
        public string Password { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(20)]
        public string RealName { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        [MaxLength(11)]
        [MinLength(11)]
        public string Mobile { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        [MaxLength(50)]
        [MinLength(5)]
        public string Email { get; set; }

        /// <summary>
        /// 登录次数
        /// </summary>
        public long LoginCount { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ICollection<T_Role> Roles { get; set; }

        /// <summary>
        /// 组集合
        /// </summary>
        [ForeignKey("GroupId")]
        public virtual ICollection<T_Group> Groups { get; set; }
    }
}
