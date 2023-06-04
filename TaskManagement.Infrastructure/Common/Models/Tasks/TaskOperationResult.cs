using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Enums;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class TaskOperationResult : ITaskOperationResult
    {
        public ETaskOperationState StateResult { get; }

        public object Payload { get; }

        public TaskOperationResult(ETaskOperationState operationState) : this(operationState, null!)
        {
        }

        public TaskOperationResult(ETaskOperationState operationState, object payload)
        {
            StateResult = operationState;
            Payload = payload;
        }
    }
}
