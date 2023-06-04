namespace TaskManagement.Application.Exceptions.Identities
{
    public class InvalidUserIdException : Exception
    {
        public InvalidUserIdException() : base("The input user id is invalid")
        {
            
        }
    }
}
