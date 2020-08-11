using ArathsBaby.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArathsBaby.WebAPI.Controllers
{
    [EnableCors("CORSPolicy")]
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController: ControllerBase
    {
        private readonly ArathsBabyContext _context;

        public ProductController(ArathsBabyContext context)
        {
            _context = context;
        }

        /**----------------------------------------------------------------**/

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _context.Products.ToListAsync();
        }

        /**----------------------------------------------------------------**/

        [HttpGet("{id}",Name = "obtenerProdu")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /**----------------------------------------------------------------**/

        [HttpPost]
        public async Task<ActionResult<Product>> PostTodoItem(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("obtenerProdu", new { id = product.Id }, product);
        }
        /**----------------------------------------------------------------**/

        [HttpPut("{id}")]
        public async Task<ActionResult> PutProduct(int id, Product produ)
        {
            if (id != produ.Id)
            {
                return BadRequest();
            }

            _context.Entry(produ).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        /**----------------------------------------------------------------**/

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
