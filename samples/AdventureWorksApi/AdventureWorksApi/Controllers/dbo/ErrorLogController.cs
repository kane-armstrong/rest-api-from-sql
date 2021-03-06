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
    [Route("api/dbo/ErrorLog")]
    [ApiController]
    public class dbo_ErrorLogController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public dbo_ErrorLogController(ApplicationDbContext db)
        {
            _db = db;
        }

		[HttpGet]
        [Route("", Name = "List_dbo_ErrorLog")]
        public async Task<ActionResult<IEnumerable<dbo.ErrorLog>>> ListErrorLog(int pageIndex, int pageSize)
        {
            return await _db.dbo_ErrorLog.OrderBy(x => x.ErrorLogID).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        }

		[HttpGet]
        [Route("{errorLogID}", Name = "GetById_dbo_ErrorLog")]
        public async Task<ActionResult<dbo.ErrorLog>> GetErrorLog(int errorLogID)
        {
            var result = await _db.dbo_ErrorLog.FirstOrDefaultAsync(x => x.ErrorLogID == errorLogID);
            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

		[HttpPost]
        [Route("", Name = "Create_dbo_ErrorLog")]
        public async Task<IActionResult> CreateErrorLog([FromBody] dbo.ErrorLog value)
        {
            _db.dbo_ErrorLog.Add(value);
            await _db.SaveChangesAsync();
            return Ok(value);
        }

		[HttpPut("{errorLogID}", Name = "Edit_dbo_ErrorLog")]
        public async Task<IActionResult> EditErrorLog(int errorLogID, [FromBody] dbo.ErrorLog value)
        {
            var existing = await _db.dbo_ErrorLog.FirstOrDefaultAsync(x => x.ErrorLogID == errorLogID);
            if (existing == null)
            {
                return NotFound();
            }

			existing.ErrorLogID = value.ErrorLogID;
			existing.ErrorTime = value.ErrorTime;
			existing.UserName = value.UserName;
			existing.ErrorNumber = value.ErrorNumber;
			existing.ErrorSeverity = value.ErrorSeverity;
			existing.ErrorState = value.ErrorState;
			existing.ErrorProcedure = value.ErrorProcedure;
			existing.ErrorLine = value.ErrorLine;
			existing.ErrorMessage = value.ErrorMessage;

            _db.dbo_ErrorLog.Update(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		[HttpDelete("", Name = "Delete_dbo_ErrorLog")]
        public async Task<IActionResult> DeleteErrorLog(int errorLogID)
        {
            var existing = await _db.dbo_ErrorLog.FirstOrDefaultAsync(x => x.ErrorLogID == errorLogID);
            if (existing == null)
            {
                return NotFound();
            }
            _db.dbo_ErrorLog.Remove(existing);
            await _db.SaveChangesAsync();
            return NoContent();
        }

		// No GetByUniqueKeyActions generated

		// No EditByUniqueKeyActions generated

		// No DeleteByUniqueKeyActions generated

	}
}