using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> CreateItem(Item item)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var dbLocation = await _context.Locations.FindAsync(item.LocationId);
            if (dbLocation == null)
                return BadRequest("Location not found");

            item.Location = dbLocation;

            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Item>>> UpdateItem(Item item)
        {
            var dbItem = await _context.Items.FindAsync(item.ItemId);
            if (dbItem == null)
                return BadRequest("Item not found");

            var dbLocation = await _context.Locations.FindAsync(item.LocationId);
            if (dbLocation == null)
                return BadRequest("Location not found");

            dbItem.Location = dbLocation;

            dbItem.Name = item.Name;
            dbItem.Quantity = item.Quantity;
            dbItem.LocationId = item.LocationId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> DeleteItem(int id)
        {
            var dbItem = await _context.Items.FindAsync(id);
            if (dbItem == null)
                return BadRequest("Item not found");

            _context.Items.Remove(dbItem);
            await _context.SaveChangesAsync();

            return Ok(await _context.Items.ToListAsync());
        }
    }
}