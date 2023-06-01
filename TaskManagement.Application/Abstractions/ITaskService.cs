using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Abstractions
{
    public interface ITaskService
    {
        Task<bool> CreateTaskAsync(ICreateTaskData taskData);
        Task<bool> UpdateTaskAsync(IUpdateTaskData taskData);
        Task<bool> CompleteTaskAsync(long taskId);
        Task<bool> DeleteTaskAsync(long taskId);
    }
}
