﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminModels.Entities
{
    public class T_Operation : ModelBase
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 事件
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 类名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 权限对象
        /// </summary>
        [ForeignKey("AuthorityId")]
        public virtual ICollection<T_Authority> Authorities { get; set; }

        [ForeignKey("MenuId")]
        public virtual ICollection<T_Menu> Menus { get; set; }
    }
}