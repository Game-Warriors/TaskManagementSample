using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Infrastructure.Common.Extensions;
using TaskManagement.Infrastructure.Common.Models.Tasks;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskDto createData, [FromServices] IBoardService boardService)
        {
            string userId = User.UserId();
            ICreateTaskResult result = await boardService.CreateBoardTaskItemAsync(userId, createData);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteTaskDto deleteData, [FromServices] ITaskService taskService)
        {
            string userId = User.UserId();
            await taskService.DeleteTaskAsync(userId, deleteData.TaskId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateData, [FromServices] ITaskService taskService)
        {
            string userId = User.UserId();
            await taskService.UpdateTaskAsync(userId, updateData);
            return Ok();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllTasks([FromQuery] string filerUserId, [FromServices] ITaskService taskService)
        {
            ITaskGroupResult result = await taskService.GetAllTasksAsync(new FetchTasksFilterDto() { UserIds = new string[] { filerUserId } });
            return Ok(result);
        }
    }
}
