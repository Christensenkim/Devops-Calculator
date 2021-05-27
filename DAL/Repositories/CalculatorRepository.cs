using DAL.Context;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class CalculatorRepository: ICalculatorRepository
    {
        readonly CalculatorDBContext _ctx;

        public CalculatorRepository(CalculatorDBContext ctx)
        {
            _ctx = ctx;
        }

        public void SaveResult(string s)
        {
            var equation = _ctx.CalclulationTable.Add(s).Entity;
            _ctx.SaveChanges();
        }

        public IEnumerable<string> ReadCalculations()
        {
            return _ctx.CalclulationTable;
        }
    }
}
