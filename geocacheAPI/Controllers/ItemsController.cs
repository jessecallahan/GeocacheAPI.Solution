using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using geocacheAPI.Models;


namespace geocacheAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private readonly geocacheAPIContext _db;

    public ItemsController(geocacheAPIContext db)
    {
      _db = db;
    }

    // GET api/items
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> Get()
    {
      return await _db.Items.ToListAsync();
    }

    // GET: api/Items/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
    var item = await _db.Items.FindAsync(id);

      if (item == null)
        {
          return NotFound();
        }

      return item;
    }

    // POST api/items
    [HttpPost]
    public async Task<ActionResult<Item>> Post(Item item)
    {
      _db.Items.Add(item);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetItem), new { id = item.ItemId }, item);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Item item)
    {
      if (id != item.ItemId)
      {
        return BadRequest();
      }

      _db.Entry(item).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ItemExists(id, item.Name))
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

    private bool ItemExists(int id, string name)
    {
      return _db.Items.Any(e => e.ItemId == id || e.Name == name);
    }
  }
}

