using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IGroupService : IAddService<T_Group>, IModifyService<T_Group>, ISelectService<T_Group>, IDeleteService<T_Group>
    {
    }
}