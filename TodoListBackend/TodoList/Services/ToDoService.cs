using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IList<Todo> _toDoList;
        private Response _response;

        public ToDoService()
        {
            _toDoList = new List<Todo>
            {
                new Todo {TaskId = 1, TaskName = "Create angular project", TaskStatus = false},
                new Todo {TaskId = 2, TaskName = "Create dot net project", TaskStatus = true},
                new Todo {TaskId = 3, TaskName = "Connect two projects", TaskStatus = false}
            };
            _response = new Response();
        }

        /// <summary>
        /// Method to add task in the list.
        /// </summary>
        /// <param name="todo"></param>
        /// <returns></returns>
        public Response AddTask(string taskName)
        {
            if (taskName != null)
            {
                _toDoList.Add(new Todo { TaskId = 4, TaskName = taskName, TaskStatus = false });

                _response.result = _toDoList;
                _response.StatusCode = (int)HttpStatusCode.OK;
                _response.Message = "List fetched successfully";
            }
            else
            {
                _response.result = null;
                _response.StatusCode = (int)HttpStatusCode.BadRequest;
                _response.Message = "Input not valid";
            }
            return _response;
        }

        /// <summary>
        /// Method to get todo list.
        /// </summary>
        /// <returns></returns>
        public Response getToDoList()
        {
            _response.result = _toDoList;
            _response.StatusCode = (int)HttpStatusCode.OK;
            _response.Message = "List fetched successfully";
            return _response;
        }

        /// <summary>
        /// Method to update the task.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public Response UpdateTaskStatus(int Id, bool status)
        {
            var singleTask = _toDoList.Where(x => x.TaskId == Id).FirstOrDefault();
            if (singleTask != null)
            {
                singleTask.TaskStatus = status;
                _response = getToDoList();
            }
            else
            {
                _response.result = null;
                _response.StatusCode = (int)HttpStatusCode.NotFound;
                _response.Message = "Record not found";
            }

            return _response;
        }
    }
}
