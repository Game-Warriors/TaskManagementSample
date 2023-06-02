using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ICreateTaskData
    {
        string Title { get; }
        ETaskPriority Priority { get; }
        string Note { get; }
    }
}
