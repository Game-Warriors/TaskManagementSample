using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions
{
    public interface IBoardService
    {
        ValueTask<ICreateTaskResult> CreateBoardTaskItemAsync(string userId, ICreateTaskData createTaskData);
    }
}
