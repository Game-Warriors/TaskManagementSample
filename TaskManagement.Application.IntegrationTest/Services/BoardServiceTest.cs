using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Enums;
using TaskManagement.Infrastructure.Common.Models;
using TaskManagement.Infrastructure.Common.Models.Tasks;
using TaskManagement.Infrastructure.Services;
using TaskManagement.Test.Common.Fakes;

namespace TaskManagement.Application.IntegrationTest.Services
{
    internal class BoardServiceTest
    {
        private IBoardService _boardService;


        [SetUp]
        public void Setup()
        {
            ITaskListRepository taskListRepository = new FakeTaskListRepository();
            ITaskListService taskListService = new TaskListService(taskListRepository);
            ITaskRepository taskRepository = new FakeTaskRepository();
            ITaskService taskService = new TaskService(taskRepository);
            _boardService = new BoardService(taskService, taskListService);
        }

        [Test]
        public async Task CreateTaskItemInBoardTest()
        {
            ICreateTaskData createTaskData = new CreateTaskDto() { Title = "New task", Priority = Domain.Enums.ETaskPriority.Low, Note = "new task note" };
            ICreateTaskResult result = await _boardService.CreateBoardTaskItemAsync("123",createTaskData);
            Assert.IsFalse(result == null, "The task creation result is null");
            Assert.IsFalse(result?.TaskId < 1, "The task id is invalid");
            Assert.IsTrue(result?.TaskListState == ETaskState.ToDo, $"The task init list is not {ETaskState.ToDo}");
        }
    }
}