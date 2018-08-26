using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_Menu : ModelBase
    {
        public T_Menu()
        {
            this.Authorities = new List<T_Authority>();
        }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        [MaxLength(10)]
        [Display(Name = "标题")]
        public string Title { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        [Display(Name = "父菜单", ResourceType = typeof(T_Menu))]
        public int? ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(20)]
        [Display(Name = "图标")]
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Display(Name = "排序")]
        public int Order { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        [Display(Name = "菜单")]
        public string Url { get; set; }

        /// <summary>
        /// 外键父对象
        /// </summary>
        [ForeignKey("ParentId")]
        public T_Menu ParentMenu { get; set; }

        /// <summary>
        /// 外键权限对象
        /// </summary>
        [ForeignKey("AuthorityId")]
        public ICollection<T_Authority> Authorities { get; set; }
    }
}
