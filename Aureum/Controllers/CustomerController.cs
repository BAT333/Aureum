using Aureum.Data;
using Aureum.DTOs;
using Aureum.DTOs.CustomerDTO;
using Aureum.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Aureum.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly AureumContext _context;
        private readonly IMapper _mapper;

        public CustomerController(AureumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ReadCustomerDTO> Post([FromBody] CreateCustomerDTO customerDTO)
        {
            Customer customer = _mapper.Map<Customer>(customerDTO);

            _context.Customers.Add(customer);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, _mapper.Map<ReadCustomerDTO>(customer));
        }

        [HttpGet]
        public ActionResult<PagedResultDTO<ReadCustomerDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            skip = Math.Max(skip, 0);
            take = Math.Clamp(take, 1, 100);
            int totalRecords = _context.Customers.Count();

            var customers = _context.Customers.Skip(skip).Take(take).ToList();
            var readDTO = _mapper.Map<IReadOnlyList<ReadCustomerDTO>>(customers);

            var result = new PagedResultDTO<ReadCustomerDTO>(totalRecords, skip, take, readDTO);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<ReadCustomerDTO> GetById(long id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            var readDTO = _mapper.Map<ReadCustomerDTO>(customer);

            return Ok(readDTO);
        }

        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] UpdateCustomerDTO customerDTO)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            _mapper.Map(customerDTO, customer);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(long id, [FromBody] PatchCustomerDTO customerDTO)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            customer.Update(customerDTO.Name);

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            Customer? customer = _context.Customers.FirstOrDefault(c => c.Id == id);

            if (customer == null) return NotFound();

            _context.Customers.Remove(customer);

            _context.SaveChanges();

            return NoContent();
        }
    }
}
