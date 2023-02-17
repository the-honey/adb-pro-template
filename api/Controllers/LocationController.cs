using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly DataContext _context;

        public LocationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Location>>> GetLocations()
        {
            return Ok(await _context.Locations.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Location>>> CreateLocation(Location location)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

            return Ok(await _context.Locations.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Location>>> UpdateLocation(Location location)
        {
            var dbLocation = await _context.Locations.FindAsync(location.LocationId);
            if (dbLocation == null)
                return BadRequest("Location not found");

            dbLocation.Name = location.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Locations.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Location>>> DeleteLocation(int id)
        {
            var dbLocation = await _context.Locations.FindAsync(id);
            if (dbLocation == null)
                return BadRequest("Location not found");

            _context.Locations.Remove(dbLocation);
            await _context.SaveChangesAsync();

            return Ok(await _context.Locations.ToListAsync());
        }
    }
}