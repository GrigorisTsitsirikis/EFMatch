using EFDataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataLibrary.DataAccess
{
    public class MatchContext:  DbContext
    {
        public MatchContext(DbContextOptions options) : base(options) { }
            public DbSet<Match> Match { get; set; }
            public DbSet<MatchOdds> MatchOdds { get; set; }
    }
}

