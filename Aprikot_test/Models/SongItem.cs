using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprikot_test.Models
{
    public class SongItem
    {
        public long Id { get; set; }
        public IEnumerable<Author> Authors { get; set; }
        public string Album { get; set; }
        public long? AlbumId { get; set; }
        public string Song { get; set; }
        public int? Year { get; set; }
    }
}
