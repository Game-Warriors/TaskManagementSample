using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class TaskStateDto : ITaskStateData
    {
        public long TaskId { get; set; }

        public ETaskState NewTaskState { get; set; }
    }
}
