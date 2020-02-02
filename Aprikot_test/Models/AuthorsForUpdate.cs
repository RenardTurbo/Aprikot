using System.Collections;
using System.Collections.Generic;

namespace Aprikot_test.Models
{
    public class AuthorsForUpdate
    {
        public long IdSong { get; set; }
        public IEnumerable<long> IdAuthors { get; set; }
    }
}