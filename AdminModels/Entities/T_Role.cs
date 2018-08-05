using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_Role : ModelBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 父元素Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 外键
        /// </summary>
        [ForeignKey("ParentId")]
        public T_Role Role { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public virtual ICollection<T_User> Users { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public virtual ICollection<T_Authority> Authorities { get; set; }
    }
}
