using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Models.Tasks;
using TaskManagement.Infrastructure.Services;
using TaskManagement.Test.Common.Fakes;

namespace TaskManagement.Application.UnitTest.Services
{
    internal class TaskServiceTest
    {
        private const long DELETE_TASK_Id = 11;
        private const long UPDATE_TASK_Id = 12;
        private const string FIRST_USER_ID = "123ddas";
        private const string SECOND_USER_ID = "567ddas";

        private ITaskService _taskService;
        private ITaskRepository _taskRepository;

        [SetUp]
        public void Setup()
        {
            ITaskRepository taskRepository = new FakeTaskRepository();
            taskRepository.AddAsync(new TaskItem(DELETE_TASK_Id, "none", Domain.Enums.ETaskPriority.Low, "Delete Test", FIRST_USER_ID));
            taskRepository.AddAsync(new TaskItem(UPDATE_TASK_Id, "test1", Domain.Enums.ETaskPriority.Low, "Update Test", FIRST_USER_ID));

            taskRepository.AddAsync(new TaskItem(101, "task101", Domain.Enums.ETaskPriority.Low, "Search Test", FIRST_USER_ID));
            taskRepository.AddAsync(new TaskItem(102, "task102", Domain.Enums.ETaskPriority.Medium, "Search Test", FIRST_USER_ID));
            taskRepository.AddAsync(new TaskItem(103, "task103", Domain.Enums.ETaskPriority.Low, "Search Test", SECOND_USER_ID));
            taskRepository.AddAsync(new TaskItem(104, "task104", Domain.Enums.ETaskPriority.Low, "Search Test", SECOND_USER_ID));

            _taskService = new TaskService(taskRepository);
            _taskRepository = taskRepository;
        }

        [Test]
        public async Task CreateTaskTest()
        {
            TaskItem result = await _taskService.CreateTaskAsync(FIRST_USER_ID, new CreateTaskDto() { Title = "New task", Priority = Domain.Enums.ETaskPriority.Low, Note = "new task note" });
            Assert.IsTrue(result != null);
            //Assert.Pass();
        }

        [Test]
        public async Task UpdateTaskTest()
        {
            string newTitle = "UpdateTask";
            string newNote = "Update Task note";
            bool isSuccess = await _taskService.UpdateTaskAsync(FIRST_USER_ID,
                new UpdateTaskDto() { TaskId = UPDATE_TASK_Id, TaskTitle = newTitle, TaskPriority = Domain.Enums.ETaskPriority.High, TaskNote = newNote });

            TaskItem taskItem = await _taskRepository.GetAsync(UPDATE_TASK_Id);
            Assert.IsTrue(isSuccess, "Update task failed");
            Assert.IsTrue(taskItem.Title == newTitle, "Task title update failed");
            Assert.IsTrue(taskItem.Priority == Domain.Enums.ETaskPriority.High, "Task priority update failed");
            Assert.IsTrue(taskItem.Note == newNote, "Task note update failed");
            //Assert.Pass();
        }

        [Test]
        public void NotExistUpdateTaskTest()
        {
            Assert.CatchAsync<TaskItemNotExistException>(async () => await _taskService.UpdateTaskAsync(FIRST_USER_ID, new UpdateTaskDto() { TaskId = 40, TaskTitle = "task1" })
            , "NotExistUpdateTaskTest failed");
        }

        [Test]
        public void NoAccessUpdateTaskTest()
        {
            Assert.CatchAsync<TaskItemNotAccessException>(async () => await _taskService.UpdateTaskAsync(SECOND_USER_ID, new UpdateTaskDto() { TaskId = UPDATE_TASK_Id, TaskTitle = "task1" })
            , "NotExistUpdateTaskTest failed");
        }

        [Test]
        public async Task DeleteTaskTest()
        {
            bool isSuccess = await _taskService.DeleteTaskAsync(FIRST_USER_ID, DELETE_TASK_Id);
            Assert.IsTrue(isSuccess);
        }

        [Test]
        public void NoAccessDeleteTaskTest()
        {
            Assert.CatchAsync<TaskItemNotAccessException>(async () => await _taskService.DeleteTaskAsync(SECOND_USER_ID, DELETE_TASK_Id));
        }

        [Test]
        public void NotExistDeleteTaskTest()
        {
            Assert.CatchAsync<TaskItemNotExistException>(async () => await _taskService.DeleteTaskAsync(FIRST_USER_ID, 20)
            , "NotExistDeleteTaskTest failed");
        }

        [Test]
        public void DeleteTaskByInvalidIdTest()
        {
            Assert.CatchAsync<TaskInvalidDataException>(async () => await _taskService.DeleteTaskAsync(FIRST_USER_ID, 0)
            , "DeleteTaskByInvalidIdTest failed");
            //Assert.Pass();
        }

        [Test]
        public async Task GetAllTaskNoFilterTest()
        {
            ITaskGroupResult result = await _taskService.GetAllTasksAsync(new FetchTasksFilterDto() { });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ItemCounts > 0);
        }


        [Test]
        public async Task GetAllTaskByFilterFilterTest()
        {
            ITaskGroupResult result = await _taskService.GetAllTasksAsync(new FetchTasksFilterDto() { UserIds = new[] { SECOND_USER_ID } });
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ItemCounts == 2);
            Assert.IsTrue(result.TaskItems.First().CreatorId == SECOND_USER_ID);
        }
    }
}