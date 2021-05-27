using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Context
{
    public class CalculatorDBContext: DbContext
    {
        public CalculatorDBContext(DbContextOptions<CalculatorDBContext> opt)
            : base(opt) { }

        public DbSet<string> CalclulationTable { get; set; }
    }
}
