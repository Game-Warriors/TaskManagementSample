using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ICreateTaskResult
    {
        long TaskId { get; }
        long TaskListId { get; }
        ETaskState TaskListState { get; }
    }
}
