using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeocacheAPI.Models;
using System;

namespace GeocacheAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ItemsController : ControllerBase
  {
    private readonly GeocacheAPIContext _db;

    public ItemsController(GeocacheAPIContext db)
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

      if (nameCheck(item.Name))
      {
        return new BadRequestObjectResult("name the same");
      }
      if (checkActiveListforThrees(item))
      {
        return new BadRequestObjectResult("more then 3 active items in this geocache");
      }
      _db.Items.Add(item);

      if (item.IsActive)
      {
        item.StartDate = DateTime.Now;
        item.EndDate = default;
      }
      else
      {
        item.StartDate = default;
        item.EndDate = DateTime.Now;
      }
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);

    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Patch(int id, Item item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }
      if (checkActiveListforThrees(item))
      {
        return new BadRequestObjectResult("more then 3 active items in this geocache");
      }
      Item serverItem = await _db.Items.FindAsync(id);

      serverItem.Name = item.Name;
      serverItem.GeocacheId = item.GeocacheId;

      if (!item.IsActive && serverItem.IsActive)
      {
        serverItem.EndDate = DateTime.Now;
      }
      if (!serverItem.IsActive && item.IsActive)
      {
        serverItem.StartDate = DateTime.Now;
        serverItem.EndDate = default;
      }
      serverItem.IsActive = item.IsActive;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ItemExists(id))
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

    private bool ItemExists(int id)
    {
      return _db.Items.Any(e => e.Id == id);
    }

    private bool checkActiveListforThrees(Item item)
    {
      var geocacheIdQuery = from n in _db.Items
                            where n.IsActive & n.GeocacheId == item.GeocacheId & n.Id != item.Id
                            select n;
      int count = geocacheIdQuery.Count();

      if (count >= 3)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    private bool nameCheck(string name)
    {
      return _db.Items.Any(e => e.Name == name);
    }
  }

}

