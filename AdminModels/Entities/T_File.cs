using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AdminModels.Entities
{
    public class T_File : ModelBase
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        [Display(Name = "路径")]
        public string Path { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        [Display(Name = "文件名称")]
        public string Name { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        [Display(Name = "内容")]
        [HiddenInput()]
        public byte[] Content { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [Display(Name = "文件类型")]
        public string Type { get; set; }

        /// <summary>
        /// 文件后缀名
        /// </summary>
        [Display(Name = "文件后缀")]
        public string Postfix { get; set; }
    }
}