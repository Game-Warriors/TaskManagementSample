using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Common;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public ETaskPriority Priority { get; private set; }
        public string? Title { get; private set; }
        public string? Note { get; private set; }


        public TaskList List { get; set; } = null!;

        public TaskItem()
        {
            
        }

        public TaskItem(long id, string title, ETaskPriority priority, string note)
        {
            Id = id;
            Title = title;
            Priority = priority;
            Note = note;
        }

        public TaskItem(string title, ETaskPriority priority, string note)
        {
            Title = title;
            Priority = priority;
            Note = note;
        }

        public void Update(string title, string note, ETaskPriority priority)
        {
            Title = title;
            Note = note;
            Priority = priority;
        }
    }
}