using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IMenuService : IAddService<T_Menu>, IModifyService<T_Menu>, ISelectService<T_Menu>, IDeleteService<T_Menu>
    {
    }
}