using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bank.Models.Interfaces;
using Bank.Models;
using Microsoft.Extensions.Logging;

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

        [HttpPost]
        public IActionResult Create([FromBody]string name)
        {
            _accountRepository.NewAccount(name);
            return Ok(_accountRepository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]string Id)
        {
            var _Id = Int32.Parse(Id);
            var response = _accountRepository.DeleteAccount(_Id);
            if (response)
            {
                return Ok(_accountRepository.GetAll());
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetAccount(int id)
        {
            return Ok(_accountRepository.GetAccount(id));
        }

        [HttpPut("withdraw/{id}")]
        public IActionResult withdrawal(int id, [FromBody] string value)
        {
            var _value = Int32.Parse(value);
            var account = _accountRepository.GetAccount(id);
            account.Withdraw(_value);
            return Ok(_accountRepository.GetAccount(id));
        }

        [HttpPut("deposit/{id}")]
        public IActionResult deposit(int id, [FromBody] string value)
        {
            var _value = Int32.Parse(value);
            var account = _accountRepository.GetAccount(id);
            account.Deposit(_value);
            return Ok(_accountRepository.GetAccount(id));
        }

    }
}
