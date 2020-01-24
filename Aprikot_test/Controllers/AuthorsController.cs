using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprikot_test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Aprikot_test.Controllers
{
    [ApiController]
    [Route("authors")]
    public class AuthorsController : ControllerBase
    {
        
        private readonly DomainModelPostgreSqlContext _domainModelPostgreSqlContext;

        public AuthorsController( DomainModelPostgreSqlContext domainModelPostgreSqlContext)
        {
            _domainModelPostgreSqlContext = domainModelPostgreSqlContext;
        }

        [HttpGet]
        public IEnumerable<Author> Get()
        {
            return _domainModelPostgreSqlContext.Authors;
        }

        [HttpPost("create")]
        public void Create([FromBody]Author author)
        {
            _domainModelPostgreSqlContext.Authors.Add(author);
            _domainModelPostgreSqlContext.SaveChanges();
        }
    }
}
