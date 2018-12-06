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
    [Route("api/Sales/SalesOrderDetail_inmem")]
    [ApiController]
    public class Sales_SalesOrderDetail_inmemController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public Sales_SalesOrderDetail_inmemController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_Sales_SalesOrderDetail_inmem")]
        public async Task<ActionResult<IEnumerable<Sales.SalesOrderDetail_inmem>>> ListSalesOrderDetail_inmem(int pageIndex, int pageSize)
        {
            return await _db.Sales_SalesOrderDetail_inmem.OrderBy(x => x.SalesOrderDetailID).ThenBy(x => x.SalesOrderID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("salesOrderDetailID/{salesOrderDetailID}/salesOrderID/{salesOrderID}", Name = "GetById_Sales_SalesOrderDetail_inmem")]
        public async Task<ActionResult<Sales.SalesOrderDetail_inmem>> GetSalesOrderDetail_inmem(long salesOrderDetailID, int salesOrderID)
        {
            var result = await _db.Sales_SalesOrderDetail_inmem.FirstOrDefaultAsync(x => x.SalesOrderDetailID == salesOrderDetailID && x.SalesOrderID == salesOrderID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_Sales_SalesOrderDetail_inmem")]
        public async Task<IActionResult> CreateSalesOrderDetail_inmem([FromBody] Sales.SalesOrderDetail_inmem value)
        {
            _db.Sales_SalesOrderDetail_inmem.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("salesOrderDetailID/{salesOrderDetailID}/salesOrderID/{salesOrderID}", Name = "Edit_Sales_SalesOrderDetail_inmem")]
        public async Task<IActionResult> EditSalesOrderDetail_inmem(long salesOrderDetailID, int salesOrderID, [FromBody] Sales.SalesOrderDetail_inmem value)
        {
            var existing = await _db.Sales_SalesOrderDetail_inmem.FirstOrDefaultAsync(x => x.SalesOrderDetailID == salesOrderDetailID && x.SalesOrderID == salesOrderID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.SalesOrderID = value.SalesOrderID;
			existing.SalesOrderDetailID = value.SalesOrderDetailID;
			existing.CarrierTrackingNumber = value.CarrierTrackingNumber;
			existing.OrderQty = value.OrderQty;
			existing.ProductID = value.ProductID;
			existing.SpecialOfferID = value.SpecialOfferID;
			existing.UnitPrice = value.UnitPrice;
			existing.UnitPriceDiscount = value.UnitPriceDiscount;
			existing.ModifiedDate = value.ModifiedDate;

            _db.Sales_SalesOrderDetail_inmem.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_Sales_SalesOrderDetail_inmem")]
        public async Task<IActionResult> DeleteSalesOrderDetail_inmem(long salesOrderDetailID, int salesOrderID)
        {
            var existing = await _db.Sales_SalesOrderDetail_inmem.FirstOrDefaultAsync(x => x.SalesOrderDetailID == salesOrderDetailID && x.SalesOrderID == salesOrderID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.Sales_SalesOrderDetail_inmem.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}