using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Models;

namespace TaskManagement.Common.Extensions
{
    public static class EntityExtension
    {
        public static CreateTaskResult ToTaskResult(this TaskItem item)
        {
            return new CreateTaskResult() { TaskId = item.Id, TaskListId = item.List.Id };
        }
    }
}
