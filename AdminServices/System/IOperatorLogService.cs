using AdminModels.Entities;

namespace AdminServices.System
{
    public interface IOperatorLogService : IAddService<T_OperatorLog>, IModifyService<T_OperatorLog>, ISelectService<T_OperatorLog>, IDeleteService<T_OperatorLog>
    {
    }
}