namespace TaskManagement.Application.Exceptions.Tasks
{
    public class TaskInvalidDataException : Exception
    {
        public TaskInvalidDataException(string operation) : base($"Invalid data for task item in {operation} operation")
        {

        }
    }
}
