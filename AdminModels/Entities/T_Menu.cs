using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace AdminModels.Entities
{
    public class T_Menu : ModelBase
    {
        public T_Menu()
        {
            this.Authorities = new Collection<T_Authority>();
            this.Operations = new Collection<T_Operation>();
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
        [HiddenInput(DisplayValue = true)]
        public T_Menu ParentMenu { get; set; }

        /// <summary>
        /// 外键权限对象
        /// </summary>
        [ForeignKey("AuthorityId")]
        [HiddenInput(DisplayValue = true)]
        public virtual ICollection<T_Authority> Authorities { get; set; }

        [ForeignKey("OperationId")]
        [HiddenInput(DisplayValue = true)]
        public virtual ICollection<T_Operation> Operations { get; set; }
    }
}