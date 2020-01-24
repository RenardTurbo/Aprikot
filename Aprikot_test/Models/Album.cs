using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Aprikot_test.Models
{
    public class Album
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

    }
}
