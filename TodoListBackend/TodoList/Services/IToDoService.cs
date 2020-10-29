using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public interface IToDoService
    {
        Response getToDoList();

        Response AddTask(string taskName);

        Response UpdateTaskStatus(int Id, bool status);

    }
}
