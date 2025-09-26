using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StageBear.Models;

namespace StageBear.Data
{
    public class StageBearContext : DbContext
    {
        public StageBearContext (DbContextOptions<StageBearContext> options)
            : base(options)
        {
        }

        public DbSet<StageBear.Models.Show> Show { get; set; } = default!;
        public DbSet<StageBear.Models.Category> Category { get; set; } = default!;
        public DbSet<StageBear.Models.Venue> Venue { get; set; } = default!;
        public DbSet<StageBear.Models.Owner> Owner { get; set; } = default!;
    }
}
