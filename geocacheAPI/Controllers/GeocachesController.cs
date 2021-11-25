using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeocacheAPI.Models;
using GeocacheAPI.Responses;

namespace GeocacheAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GeocachesController : ControllerBase
  {
    private readonly GeocacheAPIContext _db;

    public GeocachesController(GeocacheAPIContext db)
    {
      _db = db;
    }

    // GET api/geocaches
    [HttpGet]
    public async Task<Response<GeocacheResponse>> Wrapper()
    {

      var result = await _db
          .Geocaches
          .Select(c => new GeocacheResponse
          {
            Id = c.Id,
            Name = c.Name,
            Lat = c.Lat,
            Lng = c.Lng,
            Items = c
                  .Items
                  .Select(e =>
                  new ItemResponse
                  {
                    Id = e.Id,
                    Name = e.Name,
                    IsActive = e.IsActive,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
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
            Lat = b.Lat,
            Lng = b.Lng,
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
