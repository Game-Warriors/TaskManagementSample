using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions;

namespace TaskManagement.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepo;
        public TaskService(ITaskRepository taskService)
        {
            _taskRepo = taskService;
        }

        public Task<bool> CompleteTaskAsync(long taskId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateTaskAsync(ICreateTaskData taskData)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTaskAsync(long taskId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTaskAsync(IUpdateTaskData taskData)
        {
            throw new NotImplementedException();
        }
    }
}
