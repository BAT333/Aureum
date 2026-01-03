using Aureum.Data;
using Aureum.DTOs;
using Aureum.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Aureum.Controllers
{

    /// <summary>
    /// Controller Account
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AureumContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="context">Communicates with database</param>
        /// <param name="mapper">Converts a type</param>
        public AccountController(AureumContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        ///  Create an account record.
        /// </summary>
        /// <param name="accountDto">Required item for creating this account.</param>
        /// <returns>ReadAccountDTO</returns>
        /// <response code="201"> If insertion is successful</response>
        /// <response code="400"> If the insertion is unsuccessful</response>

        [HttpPost]
        [ProducesResponseType(typeof(ReadAccountDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ReadAccountDTO> Post([FromBody] CreateAccountDTO accountDto)
        {
            Account account = _mapper.Map<Account>(accountDto);
            _context.Accounts.Add(account);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = account.Id }, _mapper.Map<ReadAccountDTO>(account));
        }

        /// <summary>
        /// Search for all registered accounts
        /// </summary>
        /// <param name="skip">From the registration you will see</param>
        /// <param name="take">Number of records viewed at a time</param>
        /// <returns>ReadAccountDTO</returns>
        /// <response code="200"> If insertion is successful</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<PagedResultDTO<ReadAccountDTO>> Get([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            take = Math.Clamp(take, 1, 100);
            skip = Math.Max(skip, 0);
            int totalRecords = _context.Accounts.Count();

            List<Account> accounts = _context.Accounts.Skip(skip).Take(take).ToList();

            var readDTO = _mapper.Map<IReadOnlyList<ReadAccountDTO>>(accounts);
            var result = new PagedResultDTO<ReadAccountDTO>(totalRecords, skip, take, readDTO);

            return Ok(result);
        }

        /// <summary>
        /// Search for a record by ID number.
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>ReadAccountDTO</returns>
        /// <response code="200"> If insertion is successful</response>
        /// <response code="404"> If the insertion is unsuccessful</response>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<ReadAccountDTO> GetById(long id)
        {
            Account? accounts = _context.Accounts.FirstOrDefault(accounts => accounts.Id == id);

            if (accounts == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ReadAccountDTO>(accounts));
        }

        /// <summary>
        ///  Update an account completely
        /// </summary>
        /// <param name="id">ID number</param>
        /// <param name="accountDto">Item required to update this account.</param>
        /// <returns>ActionResult</returns>
        /// <response code="204"> If insertion is successful</response>
        /// <response code="404"> If the insertion is unsuccessful</response>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(long id, [FromBody] UpdateAccountDTO accountDto)
        {

            Account? account = _context.Accounts.FirstOrDefault(account => account.Id == id);
            if (account == null) return NotFound();
            _mapper.Map(accountDto, account);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Update an account partially
        /// </summary>
        /// <param name="id">ID number</param>
        /// <param name="accountDto">Item required to update this account.</param>
        /// <returns>ActionResult</returns>
        /// <response code="204"> If insertion is successful</response>
        /// <response code="404"> If the insertion is unsuccessful</response>

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Patch(long id, [FromBody] PatchAccountDTO accountDto)
        {
            Account? account = _context.Accounts.FirstOrDefault(account => account.Id == id);
            if (account == null) return NotFound();
            account.UpdateAccount(accountDto.AccountType, accountDto.Price, accountDto.Description, accountDto.DateOfPurchase);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Delete an account
        /// </summary>
        /// <param name="id">ID number</param>
        /// <returns>ActionResult</returns>
        /// <response code="204"> If insertion is successful</response>
        /// <response code="404"> If the insertion is unsuccessful</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(long id)
        {
            Account? account = _context.Accounts.FirstOrDefault(account => account.Id == id);
            if (account == null) return NotFound();
            _context.Accounts.Remove(account);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
