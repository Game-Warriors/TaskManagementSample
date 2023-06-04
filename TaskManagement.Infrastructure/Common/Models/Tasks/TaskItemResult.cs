using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class TaskItemResult : ITaskItem
    {
        public long Id { get; set; } = default!;
        public string CreatorId { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Note { get; set; } = default!;
        public ETaskPriority Priority { get; set; }
    }
}
