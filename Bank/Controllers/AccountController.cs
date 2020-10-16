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
        public double Get()
        {
            return _account.Balance;
        }

        [HttpPost("deposit")]
        public double Deposit([FromBody] string value)
        {
            double _value = Convert.ToDouble(value);
            _account.Deposit(_value);
            return _account.Balance;
        }

        [HttpPost("withdraw")]
        public double Withdraw([FromBody] string value)
        {
            double _value = Convert.ToDouble(value);
            _account.Withdraw(_value);
            return _account.Balance;
        }
    }
}
