using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecisionCloud.Areas.Identity.Data;
using DecisionCloud.Model;

namespace DecisionCloud.Controllers
{
    [Route("api/brands")]
    [ApiController]
    public class BrandController : Controller
    {
        private ApplicationDbContext _db;

        public BrandController(ApplicationDbContext db)
        {
            _db = db;
        }
 
        [HttpGet]
        public async Task<ActionResult<List<BrandModel>>> GetBrands()
        {
            return await _db.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandModel>> GetBrand(Guid id)
        {
            var brand = await _db.Brands.FindAsync(id);

            if (brand == null)
            {
                return NotFound();
            }

            return brand;
        }

        [HttpPost]
        public async Task<ActionResult<BrandModel>> PostBrand(BrandModel b)
        {
            _db.Brands.Add(b);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new { id = b.BrandId }, b);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BrandModel>> DeleteBrand(Guid id)
        {
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            _db.Brands.Remove(brand);
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}
