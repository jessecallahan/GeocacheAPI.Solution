using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeocacheAPI.Models;


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

    // GET api/items/inactive
    [HttpGet("inactive/")]
    public async Task<ActionResult<IEnumerable<Item>>> GetInactive()
    {
      var result = await _db.Items.Where(x => x.IsActive == false).ToListAsync();
      return result;
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
        return new BadRequestObjectResult("items must have unique names");
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

    // PATCH: api/Items/5
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

      changeName(serverItem, item);
      changeLocation(serverItem, item);

      if (!item.IsActive && serverItem.IsActive)
      {
        serverItem.EndDate = DateTime.Now;
      }
      if (!serverItem.IsActive && item.IsActive)
      {
        serverItem.StartDate = DateTime.Now;
        serverItem.EndDate = default;
      }

      changeActiveStatus(serverItem, item);

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

    // DELETE: api/items/5
    [Route("{id:int}")]
    [AcceptVerbs("DELETE")]
    public async Task<IActionResult> DeleteItem(int id)
    {
      System.Console.WriteLine(id);
      Item item = await _db.Items.FindAsync(id);
      if (item == null)
      {
        return NotFound();
      }

      _db.Items.Remove(item);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    // error handlers
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
      return _db.Items.Any(e => e.Name.ToLower() == name.ToLower());
    }

    //setters/mutators
    private bool changeActiveStatus(Item prevItem, Item currItem)
    {
      return prevItem.IsActive = currItem.IsActive;
    }

    private int changeLocation(Item prevItem, Item currItem)
    {
      return prevItem.GeocacheId = currItem.GeocacheId;
    }

    private string changeName(Item prevItem, Item currItem)
    {
      return prevItem.Name = currItem.Name;
    }
  }

}

