using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        /// <summary>
        /// Method to get the toDo list.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetToDoList")]
        public IActionResult GetToDoList()
        {
            try
            {
                var toDoList = _toDoService.getToDoList();
                return Ok(toDoList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to add the task to the list.
        /// </summary>
        /// <param name="taskName"></param>
        /// <returns></returns>
        [HttpGet("AddTask/{taskName}")]
        public IActionResult AddToDoList(string taskName)
        {
            try
            {
                var toDoTask = _toDoService.AddTask(taskName);
                return Ok(toDoTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Method to update the task status.
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("UpdateTask/{Id}/{status}")]
        public IActionResult UpdateToDoListStatus(int Id, bool status)
        {
            try
            {
                var updateTask = _toDoService.UpdateTaskStatus(Id, status);
                return Ok(updateTask);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}