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

        public AccountsListController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_accountRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            return Ok(_accountRepository.GetAccount(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody]string name)
        {
            _accountRepository.NewAccount(name);
            return Ok(_accountRepository.GetAll());
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
                return BadRequest();
            }
        }

        [HttpPut("withdraw/{id}")]
        public IActionResult withdrawal(int id, [FromBody] string _value)
        {
            var value = Convert.ToDecimal(_value);
            var account = _accountRepository.GetAccount(id);
            account.Withdraw(value);
            return Ok(_accountRepository.GetAccount(id));
        }

        [HttpPut("deposit/{id}")]
        public IActionResult deposit(int id, [FromBody] string value)
        {
            var _value = Convert.ToDecimal(value);
            var account = _accountRepository.GetAccount(id);
            account.Deposit(_value);
            return Ok(_accountRepository.GetAccount(id));
        }

    }
}
