using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models
{
    public class TaskStateData : ITaskStateData
    {
        public long TaskId { get; set; }

        public ETaskState NewTaskState { get; set; }
    }
}
