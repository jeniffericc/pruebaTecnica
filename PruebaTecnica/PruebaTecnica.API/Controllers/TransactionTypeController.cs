using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models;
using PruebaTecnica.BusinessLogic.Interfaces;

namespace PruebaTecnica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeService _ttService;

        public TransactionTypeController(ITransactionTypeService ttService)
        {
            _ttService = ttService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTransactionType([FromBody] CreateTransactionTypeModel model)
        {

            if (model.Name == null)
            {
                return BadRequest("Tipo de transacción inválida.");
            }

            var tt = await _ttService.CreateTransactionTypeAsync(model.Name, model.IsDeleted);
            
            if (tt == null)
                return BadRequest("Falló la creación de tipo de transacción.");

            return CreatedAtAction(nameof(GetTransactionType), new { transactionTypeId = tt.TransactionTypeId }, tt);
        }

        [HttpGet("{transactionTypeId}")]
        public async Task<IActionResult> GetTransactionType(int transactionTypeId)
        {
            var transactionType = await _ttService.GetTransactionTypeAsync(transactionTypeId);
            if (transactionType == null)
            {
                return NotFound();
            }

            return Ok(transactionType);
        }
    }
}
