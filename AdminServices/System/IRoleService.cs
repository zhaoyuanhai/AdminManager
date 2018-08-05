using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IRoleService : IAddService<T_Role>, IModifyService<T_Role>, ISelectService<T_Role>, IDeleteService<T_Role>
    {
    }
}