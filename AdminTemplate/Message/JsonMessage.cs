using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminTemplate.Message
{
    public class JsonMessage : JsonMessage<object>
    {

    }

    public class JsonMessage<T>
    {
        public JsonMessage()
        {
            this.Errors = new List<ErrorMessage>();
        }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 代码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 失败
        /// </summary>
        public IList<ErrorMessage> Errors { get; set; }

        /// <summary>
        /// 第一个错误消息
        /// </summary>
        public ErrorMessage FirstError
        {
            get
            {
                return this.Errors.FirstOrDefault();
            }
        }

        /// <summary>
        /// 数据
        /// </summary>
        public virtual T Data { get; set; }
    }
}