using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using TodoContextDB.Data;

[Route("api/[action]")]
[ApiController]
public class UserController : ControllerBase
{
    public readonly TodoContext _context;
    public UserController(TodoContext Context)
    {
        _context = Context;
    }

    [HttpPost]

    public async Task<ActionResult> CreateUser([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest();
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetUserId([FromQuery] int id)
    {

        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    [HttpGet]

    public async Task<ActionResult> GetAllUsers()
    {
        try
        {
            var users = await _context.Users.ToListAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] User user)
    {
        try
        {
            if (user == null)
            {
                return BadRequest();
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser([FromQuery] int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}