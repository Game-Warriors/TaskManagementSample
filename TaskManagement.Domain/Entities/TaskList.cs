using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskList : BaseEntity
    {
        public ETaskState State { get; set; }
        public string? Title { get; set; }

        public IList<TaskItem> Items { get; private set; } = new List<TaskItem>();
    }
}
