using System;
using Microsoft.AspNetCore.Mvc;
using Bank.Models.Interfaces;

namespace Bank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountsListController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;

        private readonly IPrintStatement _printStatement;

        public AccountsListController(IAccountRepository accountRepository, IPrintStatement printStatement)
        {
            _accountRepository = accountRepository;
            _printStatement = printStatement;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_accountRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            var response = _accountRepository.GetAccount(id);
            if (response != null)
            {
                return Ok(response);
            } else
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public IActionResult Create([FromBody]string name)
        {
            var response = _accountRepository.NewAccount(name, _printStatement);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]string _Id)
        {
            var Id = Int32.Parse(_Id);
            var response = _accountRepository.DeleteAccount(Id);
            if (response)
            {
                return Ok(_accountRepository.GetAll());
            } else
            {
                return NotFound();
            }
        }

        [HttpPut("withdraw/{id}")]
        public IActionResult withdrawal(int id, [FromBody] string _value)
        {
            var value = Convert.ToDecimal(_value);
            var account = _accountRepository.GetAccount(id);
            if (account != null)
            {
                account.Withdraw(value);
                return Ok(_accountRepository.GetAccount(id));
            } else
            {
                return NotFound();
            }
            
        }

        [HttpPut("deposit/{id}")]
        public IActionResult deposit(int id, [FromBody] string value)
        {
            var _value = Convert.ToDecimal(value);
            var account = _accountRepository.GetAccount(id);
            if (account != null)
            {
                account.Deposit(_value);
                return Ok(_accountRepository.GetAccount(id));
            } else
            {
                return NotFound();
            }
        }

    }
}
