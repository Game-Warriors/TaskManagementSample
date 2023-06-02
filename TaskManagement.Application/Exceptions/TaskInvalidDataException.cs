namespace TaskManagement.Application.Exceptions
{
    public class TaskInvalidDataException : Exception
    {
        public TaskInvalidDataException(string operation) : base($"Invalid data for task item in {operation} operation")
        {
            
        }
    }
}
