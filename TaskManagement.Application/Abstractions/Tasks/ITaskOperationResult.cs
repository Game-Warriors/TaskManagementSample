using TaskManagement.Application.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskOperationResult
    {
        ETaskOperationState StateResult { get; }
        object Payload { get; }
    }
}
