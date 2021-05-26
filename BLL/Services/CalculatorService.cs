﻿using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
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

        public string Calculate(string value)
        {
            string calc = new DataTable().Compute(value, null).ToString();
            Console.WriteLine(calc);
            return calc;
        }
    }
}
