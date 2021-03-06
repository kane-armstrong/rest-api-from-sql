// DISCLAIMER
// This file contains auto generated code.
// Changes to this file may be overwritten when the files are regenerated.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoGeneratedApi.Controllers
{
    [Route("api/Production/ProductCategory")]
    [ApiController]
    public class Production_ProductCategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Production_ProductCategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Production_ProductCategory")]
        public async Task<ActionResult<IEnumerable<Production.ProductCategory>>> ListProductCategory(int pageIndex, int pageSize)
        {
            return await _db.Production_ProductCategory.OrderBy(x => x.ProductCategoryID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{productCategoryID}", Name = "GetById_Production_ProductCategory")]
        public async Task<ActionResult<Production.ProductCategory>> GetProductCategory(int productCategoryID)
        {
            var result = await _db.Production_ProductCategory.FirstOrDefaultAsync(x => x.ProductCategoryID == productCategoryID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Production_ProductCategory")]
        public async Task<IActionResult> CreateProductCategory([FromBody] Production.ProductCategory value)
        {
            _db.Production_ProductCategory.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{productCategoryID}", Name = "Edit_Production_ProductCategory")]
        public async Task<IActionResult> EditProductCategory(int productCategoryID, [FromBody] Production.ProductCategory value)
        {
            var existing = await _db.Production_ProductCategory.FirstOrDefaultAsync(x => x.ProductCategoryID == productCategoryID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.ProductCategoryID = value.ProductCategoryID;
			existing.Name = value.Name;
			existing.rowguid = value.rowguid;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Production_ProductCategory.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Production_ProductCategory")]
        public async Task<IActionResult> DeleteProductCategory(int productCategoryID)
        {
            var existing = await _db.Production_ProductCategory.FirstOrDefaultAsync(x => x.ProductCategoryID == productCategoryID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Production_ProductCategory.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}