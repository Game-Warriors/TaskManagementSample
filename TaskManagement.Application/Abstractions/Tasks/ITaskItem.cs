using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskItem
    {
        long Id { get; }
        string CreatorId { get; }
        string Title { get; }
        string Note { get; }
        ETaskPriority Priority { get; }
    }
}
