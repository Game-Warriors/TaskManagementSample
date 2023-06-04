using System.Linq;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Test.Common.Fakes
{
    public class FakeTaskRepository : ITaskRepository
    {
        private List<TaskItem> _items;

        public FakeTaskRepository()
        {
            _items = new List<TaskItem>();
        }

        public Task<bool> AddAsync(TaskItem item)
        {
            _items.Add(item);
            if (item.Id < 1)
                item.Id = 40;
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

        public Task<IList<TaskItem>> GetAllAsync()
        {
            return Task.FromResult((IList<TaskItem>)_items);
        }

        public Task<IList<TaskItem>> GetAllItemByUserFilterAsync(IList<string> userIds)
        {
            IList<TaskItem> result = _items.Where(input => userIds.Any(item => item == input.CreatorId)).ToArray();
            return Task.FromResult(result);
        }

        public Task<TaskItem> GetAsync(long id)
        {
            return Task.FromResult(_items.Find(input => input.Id == id) ?? default!);
        }

        public Task<bool> UpdateAsync(TaskItem item)
        {
            return Task.FromResult(true);
        }
    }
}