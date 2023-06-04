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
        public string CreatorId { get; }
        public ETaskPriority Priority { get; private set; }
        public string? Title { get; private set; }
        public string? Note { get; private set; }


        public TaskList List { get; set; } = null!;

        public TaskItem()
        {

        }

        public TaskItem(long id, string title, ETaskPriority priority, string note, string creatorId)
        {
            Id = id;
            Title = title;
            Priority = priority;
            Note = note;
            CreatorId = creatorId;
        }

        public TaskItem(string title, ETaskPriority priority, string note, string creatorId)
        {
            Title = title;
            Priority = priority;
            Note = note;
            CreatorId = creatorId;
        }

        public void Update(string title, string note, ETaskPriority priority)
        {
            Title = title;
            Note = note;
            Priority = priority;
        }

        public void SetList(TaskList taskList)
        {
            List = taskList;
        }
    }
}