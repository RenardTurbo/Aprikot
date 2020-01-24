using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aprikot_test.Models;
using Microsoft.EntityFrameworkCore;

namespace Aprikot_test
{
    public class DomainModelPostgreSqlContext : DbContext
    {
        public DomainModelPostgreSqlContext(DbContextOptions<DomainModelPostgreSqlContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Reference> References { get; set; }
    }
}
