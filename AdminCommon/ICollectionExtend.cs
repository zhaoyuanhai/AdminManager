using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminCommon
{
    public static class ICollectionExtend
    {
        public static void AddRange<T>(this ICollection<T> ts, IEnumerable<T> models)
        {
            models.ToList().ForEach(item => ts.Add(item));
        }

        public static void RemoveRange<T>(this ICollection<T> ts, IEnumerable<T> models)
        {
            models.ToList().ForEach(item => ts.Remove(item));
        }
    }
}
