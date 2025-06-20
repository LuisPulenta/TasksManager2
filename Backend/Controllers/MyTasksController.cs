﻿using Backend.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Entities;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyTasksController : ControllerBase
    {
        private readonly DataContext _context;

        public MyTasksController(DataContext context)
        {
            _context = context;
        }

        //---------------------------------------------------------------
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.MyTasks.OrderBy(t => t.Date).ToList());
        }

        //---------------------------------------------------------------
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            var task = _context.MyTasks
                .FirstOrDefault(x => x.Id == id);
            
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        //---------------------------------------------------------------
        [HttpPost]
        public IActionResult Post(MyTask myTask)
        {
            _context.Add(myTask);
            _context.SaveChanges();
            return Ok(myTask);
        }

        //---------------------------------------------------------------
        [HttpPut]
        public IActionResult Put(MyTask myTask)
        {
            var task = _context.MyTasks
                .FirstOrDefault(x => x.Id == myTask.Id);

            if (task == null)
            {
                return NotFound();
            }
            
            task.Date=myTask.Date;
            task.Description=myTask.Description;
            task.IsCompleted=myTask.IsCompleted;
            
            _context.Update(task);
            _context.SaveChanges();
            return Ok(task); ;
        }

        //---------------------------------------------------------------
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var task = _context.MyTasks
               .FirstOrDefault(x => x.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            _context.Remove(task);
            _context.SaveChanges();
            return NoContent(); ;
        }
    }
}