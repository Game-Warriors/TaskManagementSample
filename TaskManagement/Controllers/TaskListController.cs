using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Abstractions.Tasks;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        //[HttpGet]
        //public async Task<IActionResult> AllTaskList([FromQuery] string targetUser, ITaskListService taskListService)
        //{
        //    await taskListService.GetAllTaskList
        //}
    }
}
