using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Enums;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Infrastructure.Common.Models;

namespace TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;

        public TaskService(ITaskRepository taskRepo)
        {
            _taskRepo = taskRepo;
        }

        public async ValueTask<TaskItem> CreateTaskAsync(ICreateTaskData taskData)
        {
            TaskItem taskItem =
                new TaskItem(taskData.Title, taskData.Priority, taskData.Note);

            bool isSuccess = await _taskRepo.AddAsync(taskItem);
            if (isSuccess)
            {
                return taskItem;
            }
            else
                throw new TaskCreationFailedException();
        }

        public async Task<bool> DeleteTaskAsync(long taskId)
        {
            if (taskId < 1)
                throw new TaskInvalidDataException("Delete Task");

            bool isSuccess = await _taskRepo.DeleteAsync(taskId);
            if (isSuccess)
            {
                return true;
            }
            else
                throw new TaskItemNotExistException();
        }

        public async Task<bool> UpdateTaskAsync(IUpdateTaskData taskData)
        {
            TaskItem taskItem = await _taskRepo.GetAsync(taskData.TaskId);
            if (taskItem == null)
                throw new TaskItemNotExistException();

            taskItem.Update(taskData.TaskTitle, taskData.TaskNote, taskData.TaskPriority);

            await _taskRepo.UpdateAsync(taskItem);
            return true;
        }
    }
}