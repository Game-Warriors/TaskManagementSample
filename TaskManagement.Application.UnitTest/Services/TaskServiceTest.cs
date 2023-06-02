using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.UnitTest.Fakes;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Common.Models;
using TaskManagement.Infrastructure.Services;

namespace TaskManagement.Application.UnitTest.Services
{
    public class TaskServiceTest
    {
        private const long DELETE_TASK_Id = 11;
        private const long UPDATE_TASK_Id = 12;

        private ITaskService _taskService;
        private ITaskRepository _taskRepository;

        [SetUp]
        public void Setup()
        {
            ITaskRepository taskRepository = new FakeTaskRepository();
            taskRepository.AddAsync(new TaskItem(DELETE_TASK_Id, "none", Domain.Enums.ETaskPriority.Low, "Delete Test"));
            taskRepository.AddAsync(new TaskItem(UPDATE_TASK_Id, "test1", Domain.Enums.ETaskPriority.Low, "Update Test"));
            _taskService = new TaskService(taskRepository);
            _taskRepository = taskRepository;
        }

        [Test]
        public async Task CreateTaskTest()
        {
            TaskItem result = await _taskService.CreateTaskAsync(new CreateTaskDto() { Title = "New task" , Priority = Domain.Enums.ETaskPriority.Low, Note = "new task note" });
            Assert.IsTrue(result != null);
            //Assert.Pass();
        }

        [Test]
        public async Task UpdateTaskTest()
        {
            string newTitle = "UpdateTask";
            string newNote = "Update Task note";
            bool isSuccess = await _taskService.UpdateTaskAsync(
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
            Assert.CatchAsync<TaskItemNotExistException>(async () => await _taskService.UpdateTaskAsync(new UpdateTaskDto() { TaskId = 40, TaskTitle = "task1" })
            , "NotExistUpdateTaskTest failed");
            //Assert.Pass();
        }

        [Test]
        public async Task DeleteTaskTest()
        {
            bool isSuccess = await _taskService.DeleteTaskAsync(DELETE_TASK_Id);
            Assert.IsTrue(isSuccess);
            //Assert.Pass();
        }

        [Test]
        public void NotExistDeleteTaskTest()
        {
            Assert.CatchAsync<TaskItemNotExistException>(async () => await _taskService.DeleteTaskAsync(20)
            , "NotExistDeleteTaskTest failed");
            //Assert.Pass();
        }

        [Test]
        public void DeleteTaskByInvalidIdTest()
        {
            Assert.CatchAsync<TaskInvalidDataException>(async () => await _taskService.DeleteTaskAsync(0)
            , "DeleteTaskByInvalidIdTest failed");
            //Assert.Pass();
        }
    }
}
