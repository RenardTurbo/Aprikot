using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprikot_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aprikot_test.Controllers
{
    [ApiController]
    [Route("reference")]
    public class ReferencesController
    {
        private readonly DomainModelPostgreSqlContext _domainModelPostgreSqlContext;

        public ReferencesController(DomainModelPostgreSqlContext domainModelPostgreSqlContext)
        {
            _domainModelPostgreSqlContext = domainModelPostgreSqlContext;
        }

        [HttpGet]
        public IEnumerable<Reference> Get()
        {
            return _domainModelPostgreSqlContext.References;
        }

    }
}
