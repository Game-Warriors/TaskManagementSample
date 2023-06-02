using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Exceptions
{
    public class TaskItemNotExistException : Exception
    {
        public TaskItemNotExistException() : base("The task item not exist")
        {

        }
    }
}
