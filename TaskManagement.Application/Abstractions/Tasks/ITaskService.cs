using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskService
    {
        ValueTask<TaskItem> CreateTaskAsync(ICreateTaskData taskData);
        Task<bool> UpdateTaskAsync(IUpdateTaskData taskData);
        Task<bool> DeleteTaskAsync(long taskId);
    }
}