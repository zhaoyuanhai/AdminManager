using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_Group : ModelBase
    {
        public T_Group()
        {
            this.Users = new List<T_User>();
            this.Roles = new List<T_Role>();
        }

        /// <summary>
        /// 组名称
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 父组
        /// </summary>
        [ForeignKey("ParentId")]
        public T_Group Group { get; set; }

        /// <summary>
        /// 组描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 所属用户
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<T_User> Users { get; set; }

        /// <summary>
        /// 所有角色
        /// </summary>
        [ForeignKey("RoleId")]
        public virtual ICollection<T_Role> Roles { get; set; }
    }
}
