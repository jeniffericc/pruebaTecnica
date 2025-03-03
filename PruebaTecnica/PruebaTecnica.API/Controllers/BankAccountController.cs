using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models;
using PruebaTecnica.BusinessLogic.Interfaces;
using PruebaTecnica.BusinessLogic.Services;

namespace PruebaTecnica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;

        public BankAccountController(IBankAccountService bankAccountService)
        {
            _bankAccountService = bankAccountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBankAccount([FromBody] CreateBankAccountModel model)
        {
            var bankAccount = await _bankAccountService.CreateBankAccountAsync(model.UserId, model.AccountNumber, model.Balance);
            return CreatedAtAction(nameof(GetBalance), new { bankAccountId = bankAccount.Id }, bankAccount);
        }

        [HttpGet("{accountNumber}/balance")]
        public async Task<IActionResult> GetBalance(string accountNumber)
        {
            var balance = await _bankAccountService.GetBalanceAsync(accountNumber);
            return Ok(new { Balance = balance });
        }

        [HttpGet("getById/{bankAccountId}")]
        public async Task<IActionResult> GetBankAccountById(int bankAccountId)
        {
            var bankAccount = await _bankAccountService.GetBankAccountByIdAsync(bankAccountId);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return Ok(bankAccount);
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetBankAccount(string accountNumber)
        {
            var bankAccount = await _bankAccountService.GetBankAccountAsync(accountNumber);
            if (bankAccount == null)
            {
                return NotFound();
            }

            return Ok(bankAccount);
        }
    }
}
