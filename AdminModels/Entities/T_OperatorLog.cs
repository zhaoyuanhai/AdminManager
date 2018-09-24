using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminModels.Entities
{
    public class T_OperatorLog : ModelBase
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 外键
        /// </summary>
        [ForeignKey("UserId")]
        public T_User User { get; set; }

        /// <summary>
        /// 操作内容
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime GenDate { get; set; }
    }
}