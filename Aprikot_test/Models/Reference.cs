using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aprikot_test.Models
{
    public class Reference
    {
        [Key]
        public long Id { get; set; }
        public long Author { get; set; }
        public long Song { get; set; }
        public long Album { get; set; }
    }
}
