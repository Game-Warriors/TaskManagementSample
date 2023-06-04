using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Extensions;
using TaskManagement.Infrastructure.Common.Models.Tasks;

namespace TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;

        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async ValueTask<TaskItem> CreateTaskAsync(string userId, ICreateTaskData taskData)
        {
            TaskItem taskItem =
                new TaskItem(taskData.Title, taskData.Priority, taskData.Note, userId);

            bool isSuccess = await _taskRepo.AddAsync(taskItem);
            if (isSuccess)
            {
                return taskItem;
            }
            else
                throw new TaskCreationFailedException();
        }

        public async ValueTask<bool> DeleteTaskAsync(string userId, long taskId)
        {
            if (taskId < 1)
                throw new TaskInvalidDataException("Delete Task");

            TaskItem taskItem = await _taskRepo.GetAsync(taskId);
            if (taskItem == null)
                throw new TaskItemNotExistException();

            if (taskItem.CreatorId != userId)
                throw new TaskItemNotAccessException(taskId, userId, "Delete Task");
            bool isSuccess = await _taskRepo.DeleteAsync(taskId);
            if (isSuccess)
            {
                return true;
            }
            else
                throw new TaskItemNotExistException();
        }

        public async ValueTask<ITaskGroupResult> GetAllTasksAsync(ITaskFilter filterData)
        {
            IList<string> userIds = filterData.UserIds?.Where(input => !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input)).ToArray() ?? default!;
            if (userIds == null || userIds.Count < 1)
            {
                IList<TaskItem> items = await _taskRepo.GetAllAsync();
                return new TaskGroupResult(items.Select(input => (ITaskItem)input.ToTaskItemResult()), items.Count);
            }
            else
            {
                IList<TaskItem> items = await _taskRepo.GetAllItemByUserFilterAsync(userIds);
                return new TaskGroupResult(items.Select(input => (ITaskItem)input.ToTaskItemResult()), items.Count);
            }
        }

        public async ValueTask<bool> UpdateTaskAsync(string userId, IUpdateTaskData taskData)
        {
            TaskItem taskItem = await _taskRepo.GetAsync(taskData.TaskId);
            if (taskItem == null)
                throw new TaskItemNotExistException();

            if (taskItem.CreatorId != userId)
                throw new TaskItemNotAccessException(taskData.TaskId, userId, "Update Task");

            taskItem.Update(taskData.TaskTitle, taskData.TaskNote, taskData.TaskPriority);

            await _taskRepo.UpdateAsync(taskItem);
            return true;
        }
    }
}