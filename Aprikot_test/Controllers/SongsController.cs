using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprikot_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aprikot_test.Controllers
{
    [ApiController]
    [Route("songs")]
    public class SongsController : ControllerBase
    {
        private readonly DomainModelPostgreSqlContext _domainModelPostgreSqlContext;

        public SongsController(DomainModelPostgreSqlContext domainModelPostgreSqlContext)
        {
            _domainModelPostgreSqlContext = domainModelPostgreSqlContext;
        }

        [HttpGet]
        public IEnumerable<Song> Get()
        {
            return _domainModelPostgreSqlContext.Songs;
        }

        [HttpPost("create")]
        public void Create([FromBody]SongInfo songInfo)
        {
            _domainModelPostgreSqlContext.Songs.Add(songInfo.Song);
            _domainModelPostgreSqlContext.SaveChanges();
            var songId= _domainModelPostgreSqlContext.Songs
                .Where(x => x.Name == songInfo.Song.Name)
                .Select(x=>x.Id)
                .First();
            foreach (var authorId in songInfo.AuthorIds)
            {
                _domainModelPostgreSqlContext.References.Add(new Reference
                {
                    Album = songInfo.AlbumId,
                    Author = authorId,
                    Song = songId
                });
            }
            _domainModelPostgreSqlContext.SaveChanges();
        }
    }
}
