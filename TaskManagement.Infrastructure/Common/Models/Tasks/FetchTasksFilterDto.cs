using TaskManagement.Application.Abstractions.Tasks;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class FetchTasksFilterDto : ITaskFilter
    {
        public IList<string> UserIds { get; set; } = default!;
    }
}
