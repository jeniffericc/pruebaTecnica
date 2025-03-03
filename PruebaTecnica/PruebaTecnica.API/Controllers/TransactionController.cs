using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.API.Models;
using PruebaTecnica.API.Models.Enums;
using PruebaTecnica.BusinessLogic.Interfaces;
using PruebaTecnica.BusinessLogic.Services;
using PruebaTecnica.Domain.Entities;

namespace PruebaTecnica.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IBankAccountService _bankAccountService;

        public TransactionController(ITransactionService transactionService, IBankAccountService bacnkAccountService)
        {
            _transactionService = transactionService;
            _bankAccountService = bacnkAccountService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionModel model)
        {
            var deposit = await _transactionService.CreateTransactionAsync(model.BankAccount, model.Amount, model.Date, model.TransactionTypeId);

            if (deposit == null)
            {
                return BadRequest("Falló al crear transacción.");
            }
            else
            {
                var bankAccount = await _bankAccountService.GetBankAccountByIdAsync(model.BankAccount);

                if (bankAccount == null)
                {
                    return NotFound("Cuenta bancaria no encontrada.");
                }

                decimal newBalance = 0;
                if (model.TransactionTypeId == (int)TransactionTypeEnum.Deposito)
                {
                    newBalance = bankAccount.Balance + model.Amount;
                }
                else if(model.TransactionTypeId == (int)TransactionTypeEnum.Retiro)
                {
                    newBalance = bankAccount.Balance - model.Amount;
                    if (newBalance < 0)
                    {
                        return BadRequest("Saldo insuficiente.");
                    }
                }
                
                var updateBalance = await _bankAccountService.UpdateBankAccountBalanceAsync(bankAccount.Id, newBalance, bankAccount.AccountNumber, bankAccount.UserId);

                if (!updateBalance)
                {
                    return StatusCode(500, "Error al actualizar el saldo de la cuenta.");
                }
            }
                
            return CreatedAtAction(nameof(GetTransaction), new { transactionId = deposit.TransactionId }, deposit);
        }


        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction(int transactionId)
        {
            var transaction = await _transactionService.GetTransactionAsync(transactionId);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

    }
}
