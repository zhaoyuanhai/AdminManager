using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_Authority : ModelBase
    {
        /// <summary>
        /// 权限名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 父对象
        /// </summary>
        [ForeignKey("ParentId")]
        public T_Authority Authority { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<T_User> Users { get; set; }

        /// <summary>
        /// 角色列表
        /// </summary>
        public virtual ICollection<T_Role> Roles { get; set; }
    }
}
