using Microsoft.EntityFrameworkCore;
using PuzzleSolverViewModels.RationalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBases
{
    public class PuzzleSolverDataContext<T> : DbContext
    {
        public DbSet<PuzzleModel<T>> Puzzles { get; set; }
        public DbSet<Steps<T>> Steps { get; set; }
        public PuzzleSolverDataContext(DbContextOptions<PuzzleSolverDataContext<T>> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.UseKeySequences();
        }

    }
}
