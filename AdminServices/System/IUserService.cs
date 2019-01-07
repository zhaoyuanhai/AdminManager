using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IUserService : IAddService<T_User>, IModifyService<T_User>, ISelectService<T_User>, IDeleteService<T_User>
    {
        bool Login(string userName, string password);

        bool SetUserRoles(int userId, int[] roleIds);
    }
}