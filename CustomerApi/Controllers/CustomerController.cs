using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CustomerApi.Models;
using CustomerApi.Modls;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDb _context;

        public CustomerController(CustomerDb context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerModel>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerModel>> GetCustomerModel(int id)
        {
            var customerModel = await _context.Customers.FindAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return customerModel;
        }

        // PUT: api/ /5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerModel(int id, CustomerModel customerModel)
        {
            if (id != customerModel.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customerModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(id))
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

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerModel>> PostCustomerModel(CustomerModel customerModel)
        {
            _context.Customers.Add(customerModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerModel", new { id = customerModel.CustomerId }, customerModel);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerModel(int id)
        {
            var customerModel = await _context.Customers.FindAsync(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerModelExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);

            
            
         
        }
    }
}
