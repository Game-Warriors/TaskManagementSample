using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.UnitTest.Fakes;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;
using TaskManagement.Infrastructure.Common.Models;
using TaskManagement.Infrastructure.Services;

namespace TaskManagement.Application.UnitTest.Services
{
    public class TaskListServiceTest
    {
        private const long CHANGE_STATE_TASK_ID = 13;
        private ITaskListService _taskListService;
        private ITaskListRepository _taskListRepository;

        [SetUp]
        public void Setup()
        {

            ITaskListRepository taskListRepository = new FakeTaskListRepository();
            taskListRepository.AddAsync(new TaskList(CHANGE_STATE_TASK_ID, "tasklist", ETaskState.Done, new List<TaskItem>()));
            _taskListService = new TaskListService(taskListRepository);
            _taskListRepository = taskListRepository;
        }

        [Test]
        public async Task SetTaskStateTest()
        {
            TaskList inprogressList = new TaskList(12, "in progress", ETaskState.InProgress, new List<TaskItem>());
            bool isSuccess = await _taskListService.ChangeTaskList(
                new TaskItem(1, "task", ETaskPriority.Low, "bla bla") { List = inprogressList }, ETaskState.Done);
            TaskList doneList = await _taskListRepository.GetTaskListByState(ETaskState.Done);
            TaskItem taskItem = doneList.Items.FirstOrDefault(input => input.Id == 1) ?? default!;
            Assert.IsNotNull(taskItem);
        }

        [Test]
        public void NotExsitTaskItemSetTaskStateTest()
        {
            Assert.CatchAsync<TaskItemNotExistException>(async
                () => await _taskListService.ChangeTaskList(null!, ETaskState.Done));
        }

        [Test]
        public void TaskListNotExsitSetTaskStateTest()
        {
            Assert.CatchAsync<TaskListNotExistException>(async
                () => await _taskListService.ChangeTaskList(new TaskItem(), ETaskState.InProgress));
        }

        [Test]
        public void InvalidDataSetTaskStateTest()
        {
            Assert.CatchAsync<TaskInvalidDataException>(async
                () => await _taskListService.ChangeTaskList(new TaskItem() { List = new TaskList() }, ETaskState.None));
        }

        [Test]
        public async Task FindOrCreateTaskListTest()
        {
            TaskList taskList = await _taskListService.FindOrCreateTaskListByState(ETaskState.InProgress);
            Assert.IsNotNull(taskList);
            Assert.IsNotNull(taskList.State == ETaskState.InProgress, "Wrong state creating for task list");
        }
    }
}
