using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices
{
    public interface IModifyService<T> where T : class, new()
    {
        int Modify(T model);

        int ModifyBatch(IEnumerable<T> models);
    }
}
