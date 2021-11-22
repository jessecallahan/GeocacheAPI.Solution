using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using geocacheAPI.Models;
using geocacheAPI.Responses;

namespace geocacheAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GeocachesController : ControllerBase
  {
    private readonly geocacheAPIContext _db;

    public GeocachesController(geocacheAPIContext db)
    {
      _db = db;
    }

    // GET api/geocaches
    [HttpGet]
  public async Task<Response<GeocacheResponse>> Wrapper()
{
    // still using LINQ projection,
    // but now using strongly-typed models.
    //
    // this allows for reuse and a better understanding
    // of our responses.
    // 
    // By using a Response<T> model, we can add additional
    // metadata as well, like stats (i.e. total count, pages, cursor, etc.)
    var result = await _db
        .Geocaches
        .Select(c => new GeocacheResponse
        {
            Id = c.Id,
            Name = c.Name,
            Coordinate = c.Coordinate,
            Items = c
                .Items
                .Select(e =>
                new ItemResponse {
                    Id = e.Id,
                    Name = e.Name,
                    IsActive = e.IsActive 
                }).Where(
                  e => e.IsActive
                )
        }).ToListAsync();

    

    return new Response<GeocacheResponse>(result);
}


    // GET: api/geocaches/5
    [HttpGet("{id}")]
   public async Task<ActionResult> GetGeocache(int id)
{
    var geocache = await _db.Geocaches.Include(b => b.Items).Select(b =>
        new Geocache()
        {
              Id = b.Id,
            Name = b.Name,
            Coordinate = b.Coordinate,
            Items = b.Items
        }).SingleOrDefaultAsync(b => b.Id == id);
    if (geocache == null)
    {
        return NotFound();
    }

    return Ok(geocache);
}

    // POST api/Geocaches
    [HttpPost]
    public async Task<ActionResult<Geocache>> Post(Geocache geocache)
    {
      _db.Geocaches.Add(geocache);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetGeocache), new { id = geocache.Id }, geocache);
    }

  }


  
}
