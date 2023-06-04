using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Exceptions.Tasks
{
    public class TaskCreationFailedException : Exception
    {
        public TaskCreationFailedException() : base("Creating task item failed")
        {

        }
    }
}
