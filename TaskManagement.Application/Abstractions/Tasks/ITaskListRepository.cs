using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskListRepository : IRepository<long, TaskList>
    {
        Task<TaskList> GetTaskListByState(ETaskState state);
    }
}
