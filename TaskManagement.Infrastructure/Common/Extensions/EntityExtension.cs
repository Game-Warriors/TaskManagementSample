using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Models.Tasks;

namespace TaskManagement.Infrastructure.Common.Extensions
{
    public static class EntityExtension
    {
        public static CreateTaskResult ToCreateTaskResult(this TaskItem item)
        {
            return new CreateTaskResult() { TaskId = item.Id, TaskListId = item.List.Id, TaskListState = item.List.State };
        }

        public static TaskItemResult ToTaskItemResult(this TaskItem item)
        {
            return new TaskItemResult() { Id = item.Id, CreatorId = item.CreatorId, Note = item.Note, Priority = item.Priority, Title = item.Title };
        }
    }
}
