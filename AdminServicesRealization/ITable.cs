using AdminModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServicesRealization
{
    internal interface ITable<T> where T : class, new()
    {
        DbSet<T> Table { get; }
    }
}
