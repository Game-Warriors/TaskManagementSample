using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Exceptions
{
    public class TaskListNotExistException : Exception
    {
        public TaskListNotExistException(ETaskState taskState) : base($"The task list by state {taskState} not exist")
        {
            
        }
    }
}
