using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IAuthorityService : IAddService<T_Authority>, IModifyService<T_Authority>, ISelectService<T_Authority>, IDeleteService<T_Authority>
    {
        
    }
}