using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprikot_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aprikot_test.Controllers
{
    [ApiController]
    [Route("albums")]
    public class AlbumsController : ControllerBase
    {
        private readonly DomainModelPostgreSqlContext _domainModelPostgreSqlContext;

        public AlbumsController(DomainModelPostgreSqlContext domainModelPostgreSqlContext)
        {
            _domainModelPostgreSqlContext = domainModelPostgreSqlContext;
        }

        [HttpGet]
        public IEnumerable<Album> Get()
        {
            return _domainModelPostgreSqlContext.Albums;
        }

        [HttpPost("create")]
        public void Create([FromBody]Album album)
        {
            _domainModelPostgreSqlContext.Albums.Add(album);
            _domainModelPostgreSqlContext.SaveChanges();
        }
        
        [HttpPost("EditAlbum")]
        public void EditAlbum([FromBody] Album albumForUpdate)
        {
            var album = _domainModelPostgreSqlContext.Albums.First(x => x.Id == albumForUpdate.Id);
            album.Name = albumForUpdate.Name;
            album.Year = albumForUpdate.Year;
            _domainModelPostgreSqlContext.SaveChanges();
        }
    }
}
