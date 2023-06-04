using TaskManagement.Application.Abstractions.Tasks;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class TaskGroupResult : ITaskGroupResult
    {
        public int ItemCounts { get; }

        public IEnumerable<ITaskItem> TaskItems { get; }


        public TaskGroupResult(IEnumerable<ITaskItem> taskItems, int itemCounts)
        {
            ItemCounts = itemCounts;
            TaskItems = taskItems;
        }
    }
}
