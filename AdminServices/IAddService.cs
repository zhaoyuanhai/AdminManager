using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices
{
    public interface IAddService<T> where T : class, new()
    {
        void Add(T model);

        void AddBatch(IEnumerable<T> models);
    }
}
