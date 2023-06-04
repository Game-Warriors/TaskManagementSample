using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Extensions;
using TaskManagement.Infrastructure.Common.Models;

namespace TaskManagement.Infrastructure.Services
{
    public class BoardService : IBoardService
    {
        private readonly ITaskService _taskService;
        private readonly ITaskListService _taskListService;

        public BoardService(ITaskService taskService, ITaskListService taskListService)
        {
            _taskService = taskService;
            _taskListService = taskListService;
        }

        public async ValueTask<ICreateTaskResult> CreateBoardTaskItemAsync(string userId, ICreateTaskData createTaskData)
        {
            TaskItem taskItem = await _taskService.CreateTaskAsync(userId, createTaskData);
            await _taskListService.ChangeTaskListAsync(taskItem, Domain.Enums.ETaskState.ToDo);
            return taskItem.ToCreateTaskResult();
        }
    }
}
