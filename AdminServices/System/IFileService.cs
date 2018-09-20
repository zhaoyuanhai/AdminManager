using AdminModels.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminServices.System
{
    public interface IFileService : IAddService<T_File>, IModifyService<T_File>, ISelectService<T_File>, IDeleteService<T_File>
    {
    }
}
