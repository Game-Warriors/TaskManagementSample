using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public ETaskPriority Priority { get; set; }
        public string? Title { get; init; }

        public string? Note { get; init; }

       

        public TaskList List { get; set; } = null!;
    }
}
