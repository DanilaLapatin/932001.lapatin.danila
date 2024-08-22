using System;
using Lab1.Models;

namespace Lab1.Services
{
    public class CalcService
    {
        private readonly Random _random = new();

        public CalcModel GetCalcModel()
        {
            var x = _random.Next() % 11;
            var y = _random.Next() % 11;
            return new CalcModel(
                x, y,
                sum: $"{x} + {y} = {x + y}",
                dif: $"{x} - {y} = {x - y}",
                mult: $"{x} * {y} = {x * y}",
                div: y != 0 ? $"{x} /  {y} = {x / y}" : "Division by zero"
            );
        }
    }
}