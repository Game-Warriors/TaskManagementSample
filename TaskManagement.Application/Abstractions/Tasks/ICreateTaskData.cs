using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ICreateTaskData
    {
        string Title { get; }
        ETaskPriority Priority { get; }
        string Note { get; }
    }
}
