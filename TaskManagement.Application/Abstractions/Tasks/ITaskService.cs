using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskService
    {
        ValueTask<TaskItem> CreateTaskAsync(string userId, ICreateTaskData taskData);
        ValueTask<bool> UpdateTaskAsync(string userId, IUpdateTaskData taskData);
        ValueTask<bool> DeleteTaskAsync(string userId, long taskId);
        ValueTask<ITaskGroupResult> GetAllTasksAsync(ITaskFilter taskFilter);
    }
}