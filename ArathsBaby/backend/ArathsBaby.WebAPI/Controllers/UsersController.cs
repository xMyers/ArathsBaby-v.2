using ArathsBaby.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArathsBaby.WebAPI.Controllers
{
    [EnableCors("CORSPolicy")]
    [ApiController]
    [Route("api/[controller]")]

    public class UsersController: ControllerBase
    {
        private readonly ArathsBabyContext _context;

        public UsersController(ArathsBabyContext context)
        {
            _context = context;
        }

        /**----------------------------------------------------------------**/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        /**----------------------------------------------------------------**/

        [HttpGet("{id}", Name = "obtenerUser")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        /**----------------------------------------------------------------**/

        [HttpPost]
        public async Task<ActionResult<Users>> PostUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("obtenerUser", new { id = user.Id }, user);
        }
        /**----------------------------------------------------------------**/

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, Users user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /**----------------------------------------------------------------**/

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        //[HttpPost("Login")]
        //public async Task<ActionResult<Users>> PostLogin(Users user)
        //{
        //    user = await _context.Users.Where(u => u.Email == user.Email
        //                                        && u.Password == user.Password).FirstOrDefaultAsync();

        //    return CreatedAtAction("obtenerUser", new { id = user.Id }, user);
        //}

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}

