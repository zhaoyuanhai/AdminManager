using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_Authority : ModelBase
    {
        public T_Authority()
        {
            this.Menus = new List<T_Menu>();
            this.Roles = new List<T_Role>();
        }

        /// <summary>
        /// 权限名称
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 权限类型
        /// </summary>

        public int TypeId { get; set; }

        /// <summary>
        /// 类型对象
        /// </summary>
        [ForeignKey("TypeId")]
        public T_AuthorityType Type { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ICollection<T_Role> Roles { get; set; }

        [ForeignKey("MenuId")]
        public virtual ICollection<T_Menu> Menus { get; set; }
    }
}
