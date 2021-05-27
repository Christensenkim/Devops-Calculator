using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface ICalculatorRepository
    {
        void SaveResult(string s);
        string[] ReadCalculations();
    }
}
