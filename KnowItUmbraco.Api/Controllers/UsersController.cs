using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KnowItUmbraco.Api.Data;
using KnowItUmbraco.Api.Models;

namespace KnowItUmbraco.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase {
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context) {
        _context = context;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers() {
        Console.WriteLine("Debugging: GetUsers");
        return await _context.Users.ToListAsync();
    }

    // GET: api/users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id) {
        var user = await _context.Users.FindAsync(id);

        if (user == null) {
            return NotFound();
        }

        return user;
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user) {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // DELETE: api/users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id) {
        var user = await _context.Users.FindAsync(id);
        if (user == null) {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
