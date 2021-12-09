using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Model1Context db;
        public ValuesController(Model1Context context)
        {
            db = context;
            if (!db.models1.Any())
            {
                db.models1.Add(new Model1 { Column2 = "Tom", Column3 = 26 });
                db.models1.Add(new Model1 { Column2 = "Alice", Column3 = 31 });
                db.SaveChanges();
            }
        }
 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model1>>> Get()
        {
            return await db.models1.ToListAsync();
        }
 
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Model1>> Get(int id)
        {
            Model1 user = await db.models1.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }
 
        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Model1>> Post(Model1 user)
        {
            if (user == null)
            {
                return BadRequest();
            }
 
            db.models1.Add(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
 
        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Model1>> Put(Model1 user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!db.models1.Any(x => x.Id ==user.Id))
            {
                return NotFound();
            }
 
            db.Update(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
 
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Model1>> Delete(int id)
        {
            Model1 user = db.models1.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            db.models1.Remove(user);
            await db.SaveChangesAsync();
            return Ok(user);
        }
    }
}
