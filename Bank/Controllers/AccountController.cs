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
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_account.Balance);
        }

        [HttpPost("deposit")]
        public IActionResult Deposit([FromBody] string value)
        {
            double _value = Convert.ToDouble(value);
            if(_value > 0.00)
            {
                _account.Deposit(_value);
                return Ok(_account.Balance);
            } else
            {
                return Ok(null);
            }
            
        }

        [HttpPost("withdraw")]
        public double Withdraw([FromBody] string value)
        {
            double _value = Convert.ToDouble(value);
            _account.Withdraw(_value);
            return _account.Balance;
        }

        [HttpGet("statement")]
        public List<string> Statement()
        {
            return _account.Statement();
        }
    }
}
