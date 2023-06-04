using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class CreateTaskResult : ICreateTaskResult
    {
        public long TaskId { get; init; }
        public long TaskListId { get; init; }
        public ETaskState TaskListState { get; init; }
    }
}
