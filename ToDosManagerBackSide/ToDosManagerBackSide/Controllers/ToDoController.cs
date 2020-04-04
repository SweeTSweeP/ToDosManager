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
    [Route("todo")]
    public class ToDoController : Controller
    {
        private ToDosManagerDbContext _dbContext;
        
        public ToDoController(ToDosManagerDbContext context)
        {
            _dbContext = context;
        }

        [HttpGet("~/todo/tasks")]
        public IEnumerable<Record> GetTasks()
        {
            return _dbContext.Tasks.ToList();
        }

        [HttpGet("~/todo/tasks/{date}")]
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

        [HttpPost("~/todo/tasks")]
        public void AddTasksDay(Day TasksDay)
        {
            _dbContext.Add(TasksDay);
        }

        [HttpDelete("~/todo/tasks/{date}")]
        public void DeleteTasksDay(Day TasksDay)
        {
            _dbContext.Remove(TasksDay);
        }

        [HttpPost("~/todo/tasks/{date}")]
        public void AddTask(Record Task)
        {
            _dbContext.Add(Task);
        }

        [HttpPut("~/todo/tasks/{date}/{taskId}")]
        public void UpdateTask(int TaskId, Record Task)
        {
            var Record = _dbContext.Tasks.Find(TaskId);

            Record.Status = Task.Status;
            Record.Description = Task.Description;
            Record.Header = Task.Header;
        }

        [HttpDelete("~/todo/tasks/{date}/{taskId}")]
        public void DeleteTask(int TaskId)
        {
            var Record = _dbContext.Days.Find(TaskId);

            _dbContext.Remove(Record);
        }
    }
}