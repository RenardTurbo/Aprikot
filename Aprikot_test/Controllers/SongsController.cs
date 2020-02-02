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
        public void Create([FromBody] SongInfo songInfo)
        {
            _domainModelPostgreSqlContext.Songs.Add(songInfo.Song);
            _domainModelPostgreSqlContext.SaveChanges();
            var songId = _domainModelPostgreSqlContext.Songs
                .Where(x => x.Name == songInfo.Song.Name)
                .Select(x => x.Id)
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

        [HttpGet("GetSongTable")]
        public IEnumerable<SongItem> GetSongTable()
        {
            var songs = _domainModelPostgreSqlContext.Songs.ToArray();
            var referencesId = songs
                .Select(x => _domainModelPostgreSqlContext.References.Where(y => x.Id == y.Song).ToArray()).ToArray();
            var albums = referencesId.Select(x =>
            {
                var albumId = x.First().Album;
                return _domainModelPostgreSqlContext.Albums.FirstOrDefault(y => y.Id == albumId);
            }).ToArray();
            var authors = referencesId.Select(x =>
            {
                var authorIds = x.Select(y => y.Author).ToArray();
                return authorIds.Select(y => _domainModelPostgreSqlContext.Authors.First(z => z.Id == y)).ToArray();
            }).ToArray();
            var songItems = new List<SongItem>();
            for (var i = 0; i < songs.Length; i++)
            {
                songItems.Add(new SongItem
                {
                    Id = songs[i].Id,
                    Song = songs[i].Name,
                    Album = albums[i]?.Name,
                    AlbumId = albums[i]?.Id,
                    Year = albums[i]?.Year,
                    Authors = authors[i]
                });
            }

            return songItems;
        }

        [HttpPost("EditSongName")]
        public void EditSongName([FromBody] Song songForUpdate)
        {
            var song = _domainModelPostgreSqlContext.Songs.First(x => x.Id == songForUpdate.Id);
            song.Name = songForUpdate.Name;
            _domainModelPostgreSqlContext.SaveChanges();
        }

        [HttpPost("EditAlbum")]
        public void EditAlbum([FromBody] AlbumForUpdate albumForUpdate)
        {
          var references =  _domainModelPostgreSqlContext.References.Where(x => x.Song == albumForUpdate.IdSong);
          foreach (var reference in references)
          {
              reference.Album = albumForUpdate.IdAlbum;
          }
          _domainModelPostgreSqlContext.SaveChanges();
        }

        [HttpPost("EditAuthors")]
        public void EditAuthors([FromBody] AuthorsForUpdate authorsForUpdate)
        {
           var references = _domainModelPostgreSqlContext.References.Where(x => x.Song == authorsForUpdate.IdSong);
           var albumId = references.First().Album;
           foreach (var reference in references)
           {
               _domainModelPostgreSqlContext.References.Remove(reference);
           }

           foreach (var idAuthor in authorsForUpdate.IdAuthors)
           {
               _domainModelPostgreSqlContext.References.Add(new Reference
               {
                   Album = albumId,
                   Author = idAuthor,
                   Song = authorsForUpdate.IdSong
               });
           }
           _domainModelPostgreSqlContext.SaveChanges();
        }

        [HttpPost("Delete")]
        public void DeleteSong([FromBody]SongIdModel songId)
        {
           var deleteSong=_domainModelPostgreSqlContext.Songs.First(x => x.Id == songId.SongId);
           _domainModelPostgreSqlContext.Songs.Remove(deleteSong);
           _domainModelPostgreSqlContext.SaveChanges();
        }

        public class SongIdModel
        {
            public long SongId { get; set; }
        }
    }
}