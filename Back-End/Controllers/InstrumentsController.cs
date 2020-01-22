using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InstrumentalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrumentsController : ControllerBase
    {
        private List<string> instCategory = new List<string>
            { "Percussion", "Wind", "Stringed", "Electronic", "Other" };
        private readonly DatabaseContext _context;

        public InstrumentsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Instruments
        // USE: Retrieve list of all instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstruments()
        {
            return await _context.Instruments.ToListAsync();
        }

        // GET: api/Instruments/{Id}
        // USE: Retrieve instrument with specific {Id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrument(int id)
        {
            var instrument = await _context.Instruments.FindAsync(id);

            if (instrument == null)
            {
                return NotFound("Invalid Id: No instrument exists with Id["
                    + id
                    + "]. Remove the Id from the request to see all instruments.");
            }

            return instrument;
        }

        // POST: api/Instruments
        // USE : Add new instrument entry to next available database location
        [HttpPost]
        public async Task<ActionResult<Instrument>> PostInstrument(Instrument instrument)
        {
            if (!instCategory.Contains(instrument.Category))
            {
                return BadRequest("Invalid Category: Please choose a category from the dropdown.");
            }

            if (!(instrument.ItemName.Length >= 1 && instrument.ItemName.Length <= 20))
            {
                return BadRequest("Invalid Name: Instrument must be between 1 and 20 characters.");
            }

            _context.Instruments.Add(instrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // PUT: api/Instruments/{Id}
        // USE: Replace instrument entry at specific {Id} with new instrument
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(string id, Instrument instrument)
        {
            int numberID;
            try
            {
                numberID = Int32.Parse(id);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid ID: Integer values allowed only.");
            }

            instrument.Id = numberID;
            if (!instCategory.Contains(instrument.Category))
            {
                return BadRequest("Invalid Category: Please choose a category from the dropdown.");
            }

            if (!(instrument.ItemName.Length >= 1 && instrument.ItemName.Length <= 20))
            {
                return BadRequest("Invalid Name: Instrument must be between 1 and 20 characters.");
            }

            _context.Entry(instrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentExists(numberID))
                {
                    return NotFound("Invalid Id: No instrument exists with Id[" + numberID + "].");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments/{Id}
        // USE   : Delete instrument entry at specific {Id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instrument>> DeleteInstrument(string id)
        {
            int numberID;
            try
            {
                numberID = Int32.Parse(id);
            }
            catch (Exception e)
            {
                return BadRequest("Invalid ID: Integer values allowed only.");
            }
            
            var instrument = await _context.Instruments.FindAsync(numberID);
            if (instrument == null)
            {
                return NotFound("Invalid Id: No instrument exists with Id[" + id + "].");
            }

            _context.Instruments.Remove(instrument);
            await _context.SaveChangesAsync();

            return instrument;
        }

        private bool InstrumentExists(int id)
        {
            return _context.Instruments.Any(e => e.Id == id);
        }
    }
}
