﻿using TaskManagement.Application.Abstractions;
using TaskManagement.Application.Abstractions.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<bool> AddAsync(TaskItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskItem>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<TaskItem>> GetAllItemByUserFilterAsync(IList<string> userIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TaskItem item)
        {
            throw new NotImplementedException();
        }

        Task<TaskItem> IRepository<long, TaskItem>.GetAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
