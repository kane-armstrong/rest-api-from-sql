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
    [Route("api/HumanResources/Shift")]
    [ApiController]
    public class HumanResources_ShiftController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public HumanResources_ShiftController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_HumanResources_Shift")]
        public async Task<ActionResult<IEnumerable<HumanResources.Shift>>> ListShift(int pageIndex, int pageSize)
        {
            return await _db.HumanResources_Shift.OrderBy(x => x.ShiftID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{shiftID}", Name = "GetById_HumanResources_Shift")]
        public async Task<ActionResult<HumanResources.Shift>> GetShift(byte shiftID)
        {
            var result = await _db.HumanResources_Shift.FirstOrDefaultAsync(x => x.ShiftID == shiftID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_HumanResources_Shift")]
        public async Task<IActionResult> CreateShift([FromBody] HumanResources.Shift value)
        {
            _db.HumanResources_Shift.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{shiftID}", Name = "Edit_HumanResources_Shift")]
        public async Task<IActionResult> EditShift(byte shiftID, [FromBody] HumanResources.Shift value)
        {
            var existing = await _db.HumanResources_Shift.FirstOrDefaultAsync(x => x.ShiftID == shiftID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.ShiftID = value.ShiftID;
			existing.Name = value.Name;
			existing.StartTime = value.StartTime;
			existing.EndTime = value.EndTime;
			existing.ModifiedDate = value.ModifiedDate;

            _db.HumanResources_Shift.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_HumanResources_Shift")]
        public async Task<IActionResult> DeleteShift(byte shiftID)
        {
            var existing = await _db.HumanResources_Shift.FirstOrDefaultAsync(x => x.ShiftID == shiftID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.HumanResources_Shift.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}