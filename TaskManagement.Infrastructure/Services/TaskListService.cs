using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Services
{
    public class TaskListService : ITaskListService
    {
        private readonly ITaskListRepository _taskListRepo;

        public TaskListService(ITaskListRepository taskListRepository)
        {
            _taskListRepo = taskListRepository;
        }

        public async ValueTask<bool> ChangeTaskList(TaskItem taskItem, ETaskState newState)
        {
            if (taskItem == null)
                throw new TaskItemNotExistException();

            if (taskItem.List == null)
                throw new TaskListNotExistException(newState);

            if (newState == ETaskState.None)
                throw new TaskInvalidDataException("Change Task List");

            if (taskItem.List.State == newState)
            {
                return true;
            }

            TaskList taskList = await FindOrCreateTaskListByState(newState);
            taskList.AddNewItem(taskItem);
            await _taskListRepo.UpdateAsync(taskList);
            return true;
        }

        public async ValueTask<TaskList> FindOrCreateTaskListByState(ETaskState taskState)
        {
            TaskList taskList = await _taskListRepo.GetTaskListByState(taskState);
            if (taskList == null)
            {
                taskList = new TaskList() { State = taskState, Title = taskState.ToString() };
                await _taskListRepo.AddAsync(taskList);
            }
            return taskList;
        }
    }
}