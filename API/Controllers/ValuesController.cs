using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
//using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Value>>> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Value>> GetValueByIdAsync(int id)
        {
            
            var values = await _context.Values.FindAsync(id);
            return Ok(values);
        }

        [HttpPost("")]
        public ActionResult<Value> PostValue(Value model)
        {
            return null;
        }

        [HttpPut("{id}")]
        public IActionResult PutValue(int id, Value model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Value> DeleteValueById(int id)
        {
            return null;
        }
    }
}