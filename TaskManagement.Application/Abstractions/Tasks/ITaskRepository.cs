using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskRepository : IRepository<long, TaskItem>
    {
        Task<IList<TaskItem>> GetAllItemByUserFilterAsync(IList<string> userIds);
    }
}
