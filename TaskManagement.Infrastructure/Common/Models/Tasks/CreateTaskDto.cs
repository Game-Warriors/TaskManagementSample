using System.ComponentModel.DataAnnotations;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Infrastructure.Common.Models.Tasks
{
    public class CreateTaskDto : ICreateTaskData
    {
        [Required]
        public string Title { get; set; } = default!;
        public ETaskPriority Priority { get; set; }
        public string Note { get; set; } = default!;
    }
}
