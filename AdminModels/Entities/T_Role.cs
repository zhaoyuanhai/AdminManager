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
        public T_Role()
        {
            this.Users = new List<T_User>();
            this.Groups = new List<T_Group>();
            this.Authorities = new List<T_Authority>();
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 父元素Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        [ForeignKey("UserId")]
        public virtual ICollection<T_User> Users { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        [ForeignKey("GroupId")]
        public virtual ICollection<T_Group> Groups { get; set; }

        [ForeignKey("AuthorityId")]
        public virtual ICollection<T_Authority> Authorities { get; set; }
    }
}
