using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private IRepositoryWrapper _repositoryWrapper;
        private readonly ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper repoWrapper)
        {
            _logger = logger;
            _repositoryWrapper = repoWrapper;
        }

        //Get api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAcc = _repositoryWrapper.Account.FindByCondition( account => account.AccountType.Equals("Domestic"));
            var users = _repositoryWrapper.User.FindAll();

            return new string[] { "value 1", "value2" };
        }
    }
}
