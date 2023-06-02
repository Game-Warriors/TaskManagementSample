using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models
{
    public class UpdateTaskDto : IUpdateTaskData
    {
        public long TaskId { get; set; }
        public string TaskTitle { get; set; } = default!;
        public string TaskNote { get; set; } = default!;
        public ETaskPriority TaskPriority { get; set; }
    }
}
