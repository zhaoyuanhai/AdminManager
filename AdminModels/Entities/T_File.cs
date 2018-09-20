using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminModels.Entities
{
    public class T_File : ModelBase
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string Postfix { get; set; }
    }
}
