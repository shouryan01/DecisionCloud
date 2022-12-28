using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DecisionCloud.Data;
using DecisionCloud.Model;
using DecisionCloud.Areas.Identity.Data;

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

        [HttpPost]
        public async Task<ActionResult<BrandModel>> PostBrand(BrandModel b)
        {
            _db.Brands.Add(b);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrands), new { id = b.BrandId }, b);
        }
    }
}
