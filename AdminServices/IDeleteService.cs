using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices
{
    public interface IDeleteService<T> where T : class, new()
    {
        int Delete(T model);

        int Delete(int id);

        int DeleteBatch(IEnumerable<T> models);

        int DeleteBatch(IEnumerable<int> ids);
    }
}
