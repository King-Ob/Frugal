using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrogoYou.Model;
using FrogoYou.Helper;

namespace FrogoYou.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemDetailsController : ControllerBase
    {
        private readonly StoreDetailContext _context;

        public ItemDetailsController(StoreDetailContext context)
        {
            _context = context;
        }

        // GET: api/ItemDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDetail>>> GetItemDetails()
        {
            return await _context.ItemDetails.ToListAsync();
        }

        // GET: api/ItemDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDetail>> GetItemDetail(int id)
        {
            var itemDetail = await _context.ItemDetails.FindAsync(id);

            if (itemDetail == null)
            {
                return NotFound();
            }

            return itemDetail;
        }

        // PUT: api/ItemDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItemDetail(int id, ItemDetail itemDetail)
        {
            if (id != itemDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(itemDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ItemDetails
        [HttpPost]
        public async Task<ActionResult<ItemDetail>> PostItemDetail(ItemDetail itemDetail)
        {
            if (itemDetail.ItemUrl.Contains("Zara") )
            {
                Zara z = new Zara();
                z.Zaras(itemDetail.ItemUrl, itemDetail.ItemWantedPrice, itemDetail.ItemStore, itemDetail.ItemCurrentPrice, itemDetail.ItemName);

                _context.ItemDetails.Add(z.RetunA());
            }
            else if(itemDetail.ItemUrl.Contains("bonobos")){
                Bonobos z = new Bonobos();
                z.Bonoboss(itemDetail.ItemUrl, itemDetail.ItemWantedPrice, itemDetail.ItemStore, itemDetail.ItemCurrentPrice, itemDetail.ItemName);

                _context.ItemDetails.Add(z.RetunA());
               

            }
            else if (itemDetail.ItemUrl.Contains("saksfifthavenue") || itemDetail.ItemUrl.Contains("gap") || itemDetail.ItemUrl.Contains("bananarepublic"))
            {
                Saksfifthavenue z = new Saksfifthavenue();
                z.Saksfifthavenues(itemDetail.ItemUrl, itemDetail.ItemWantedPrice, itemDetail.ItemStore, itemDetail.ItemCurrentPrice, itemDetail.ItemName);

                _context.ItemDetails.Add(z.RetunA());

            }
        
            else if (itemDetail.ItemUrl.Contains("hm"))
            {
                Hm z = new Hm();
                z.Hms(itemDetail.ItemUrl, itemDetail.ItemWantedPrice, itemDetail.ItemStore, itemDetail.ItemCurrentPrice, itemDetail.ItemName);

                _context.ItemDetails.Add(z.RetunA());
               
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetItemDetail", new { id = itemDetail.Id }, itemDetail);
        }

        // DELETE: api/ItemDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ItemDetail>> DeleteItemDetail(int id)
        {
            var itemDetail = await _context.ItemDetails.FindAsync(id);
            if (itemDetail == null)
            {
                return NotFound();
            }

            _context.ItemDetails.Remove(itemDetail);
            await _context.SaveChangesAsync();

            return itemDetail;
        }

        private bool ItemDetailExists(int id)
        {
            return _context.ItemDetails.Any(e => e.Id == id);
        }
    }
}
