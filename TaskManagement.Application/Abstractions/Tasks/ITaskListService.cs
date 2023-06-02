using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskListService
    {
        ValueTask<bool> ChangeTaskList(TaskItem taskItem, ETaskState newState);
        ValueTask<TaskList> FindOrCreateTaskListByState(ETaskState taskState);
    }
}
