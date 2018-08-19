using System;
using System.Collections.Generic;
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
        public string Title { get; set; }

        /// <summary>
        /// 父Id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        [MaxLength(20)]
        public string Icon { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 外键
        /// </summary>
        [ForeignKey("ParentId")]
        public T_Menu ParentMenu { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        [ForeignKey("AuthorityId")]
        public ICollection<T_Authority> Authorities { get; set; }
    }
}
