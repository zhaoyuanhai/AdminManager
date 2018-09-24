using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminModels.Entities
{
    public class T_Authority : ModelBase
    {
        public T_Authority()
        {
            this.Menus = new Collection<T_Menu>();
            this.Roles = new Collection<T_Role>();
        }

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

        /// <summary>
        /// 菜单Id
        /// </summary>
        [ForeignKey("MenuId")]
        public virtual ICollection<T_Menu> Menus { get; set; }

        /// <summary>
        /// 操作Id
        /// </summary>
        [ForeignKey("OperationId")]
        public virtual ICollection<T_Operation> Operations { get; set; }
    }
}