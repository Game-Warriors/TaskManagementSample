using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskGroupResult
    {
        int ItemCounts { get; }
        IEnumerable<ITaskItem> TaskItems { get; }
    }
}
