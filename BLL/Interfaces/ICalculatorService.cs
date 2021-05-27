using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICalculatorService
    {
        string Calculate(string value);
        string[] getResults();
    }
}
