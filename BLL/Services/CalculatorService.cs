using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ICalculatorRepository _calculatorRepository;

        public CalculatorService(ICalculatorRepository calculatorRepository)
        {
            _calculatorRepository = calculatorRepository;
        }
    }
}
