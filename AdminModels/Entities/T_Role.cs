using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminModels.Entities
{
    public class T_Role : ModelBase
    {
        public T_Role()
        {
            this.Users = new Collection<T_User>();
            this.Groups = new Collection<T_Group>();
            this.Authorities = new Collection<T_Authority>();
        }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

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