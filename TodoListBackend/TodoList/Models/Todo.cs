
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class Todo
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public bool TaskStatus { get; set; }
    }
}
