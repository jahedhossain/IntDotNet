using Microsoft.AspNetCore.Mvc;
using TodoContextDB.Data;

[Route("api/[controller]")]
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
}

