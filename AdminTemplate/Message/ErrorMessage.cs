using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTemplate.Message
{
    public class ErrorMessage
    {
        /// <summary>
        /// 错误消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 描述信息
        /// </summary>
        public string Description { get; set; }
    }
}