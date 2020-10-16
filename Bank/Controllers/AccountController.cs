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
        IAccount _account;
        public AccountController()
        {
            _account = new Account();
        }

        [HttpGet]
        public double Get()
        {
            return _account.Balance;
        }
    }
}
