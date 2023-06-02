using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskStateData
    {
        long TaskId { get; }
        ETaskState NewTaskState { get; }
    }
}
