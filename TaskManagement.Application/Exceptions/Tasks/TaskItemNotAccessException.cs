namespace TaskManagement.Application.Exceptions.Tasks
{
    public class TaskItemNotAccessException : Exception
    {
        public TaskItemNotAccessException(long itemId, string userId, string accessType) : base($"Restricted {accessType} access by user id:{userId} to task item by id:{itemId}")
        {

        }
    }
}
