using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Test.Common.Fakes
{
    public class FakeTaskListRepository : ITaskListRepository
    {
        private List<TaskList> _items;

        public FakeTaskListRepository()
        {
            _items = new List<TaskList>();
        }

        public Task<bool> AddAsync(TaskList item)
        {
            _items.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(long id)
        {
            int index = _items.FindIndex(input => input.Id == id);
            if (index >= 0)
            {
                _items.RemoveAt(index);
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public Task<TaskList> GetAsync(long id)
        {
            return Task.FromResult(_items.Find(input => input.Id == id) ?? default!);
        }


        public Task<bool> UpdateAsync(TaskList item)
        {
            return Task.FromResult(true);
        }

        public Task<TaskList> GetTaskListByState(ETaskState state)
        {
            return Task.FromResult(_items.Find(input => input.State == state) ?? default!);
        }

        public Task<IList<TaskList>> GetAllAsync()
        {
            return Task.FromResult((IList<TaskList>)_items);
        }
    }
}
