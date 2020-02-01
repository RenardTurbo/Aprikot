using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aprikot_test.Models
{
    public class SongItem
    {
        public IEnumerable<string> Authors { get; set; }
        public string Album { get; set; }
        public string Song { get; set; }
        public int? Year { get; set; }
    }
}
