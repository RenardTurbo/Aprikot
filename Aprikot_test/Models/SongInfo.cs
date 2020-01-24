using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprikot_test.Models
{
    public class SongInfo
    {
        public Song Song { get; set; }
        public long AlbumId { get; set; }
        public IEnumerable<long> AuthorIds { get; set; }
    }
}
