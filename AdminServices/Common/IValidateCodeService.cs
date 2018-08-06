using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices.Common
{
    public interface IValidateCodeService
    {
        /// <summary>
        /// 创建图片二维码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        byte[] CreateValidateGraphic(string code);

        /// <summary>
        /// 生成随机码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        string CreateValidateCode(int length);
    }
}
