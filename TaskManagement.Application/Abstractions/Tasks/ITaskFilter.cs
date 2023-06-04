namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskFilter
    {
        IList<string> UserIds { get; }
    }
}
