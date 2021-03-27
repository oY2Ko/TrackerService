using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrackerService.Models;

namespace TrackerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
            ApplicationContext db;
            public StudentsController(ApplicationContext context)
            {
                db = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<Student>>> Get()
            {
                return await db.Students.ToListAsync();
            }


            [HttpGet("{id}")]
            public async Task<ActionResult<Student>> Get(int id)
            {
                Student student = await db.Students.FirstOrDefaultAsync(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                return new ObjectResult(student);
            }


        [HttpPost]
        public async Task<ActionResult<Student>> Post(Student student)
        {
            Student temporary = await db.Students.FirstOrDefaultAsync(p => p.Login == student.Login);
            if (student == null)
            {
                return BadRequest();
            }
            else {
                if (temporary != null)
                {
                    db.Students.Add(student);
                    await db.SaveChangesAsync();
                    return Ok(student);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

            [HttpPut]
            public async Task<ActionResult<Student>> Put(Student student)
            {
                if (student == null)
                {
                    return BadRequest();
                }
                if (!db.Students.Any(x => x.Id == student.Id))
                {
                    return NotFound();
                }

                db.Update(student);
                await db.SaveChangesAsync();
                return Ok(student);
            }


            [HttpDelete("{id}")]
            public async Task<ActionResult<Student>> Delete(int id)
            {
                Student student = db.Students.FirstOrDefault(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                db.Students.Remove(student);
                await db.SaveChangesAsync();
                return Ok(student);
            }
        }
    }
