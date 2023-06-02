﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Abstractions.Tasks
{
    public interface ITaskRepository : IRepository<long, TaskItem>
    {

    }
}