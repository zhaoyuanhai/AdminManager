using AdminModels.Entities;
using System.Collections.Generic;

namespace AdminServices.System
{
    public interface IMenuService : IAddService<T_Menu>, IModifyService<T_Menu>, ISelectService<T_Menu>, IDeleteService<T_Menu>
    {
        IEnumerable<T_Menu> GetMenusByUserId(int userId);

        IEnumerable<T_Operation> GetOperationsByMenuId(int id);

        bool SaveMenuOperation(int menuId, int[] operations);
    }
}