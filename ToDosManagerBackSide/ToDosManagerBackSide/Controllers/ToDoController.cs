using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDosManagerBackSide.Data;
using ToDosManagerBackSide.Domain.Entities;

namespace ToDosManagerBackSide.Controllers
{
    [ApiController]
    [Route("ToDo")]
    public class ToDoController : Controller
    {
        private ToDosManagerDbContext _dbContext;

        public ToDoController(ToDosManagerDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("Tasks")]
        public IEnumerable<Record> GetTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        [HttpGet("ToDo/{date}")]
        public IEnumerable<Record> GetTaskById(DateTime TasksDay)
        {
            var query = _dbContext.Days.FirstOrDefault(s => s.TasksDay == TasksDay);

            if (query != null)
            {
                return query.TaskRecords;
            }
            else
            {
                return Enumerable.Empty<Record>();
            }
        }

        [HttpPost("ToDo")]
        public void AddTasksDay(Day TasksDay)
        {
            _dbContext.Add(TasksDay);
        }
        
        
    }
}