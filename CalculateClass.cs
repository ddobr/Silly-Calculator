using System;
using System.Collections.Generic;

namespace CodeRetreat
{
    static class CalculateClass
    {
        public static double Calculate(string[] notation)
        {
            var results = new Stack<double>();
            foreach (var element in notation)
            {
                if (double.TryParse(element, out var number))
                    results.Push(number);
                else
                {
                    var operation = Operations.Dictionary[element];
                    var operands = new double[operation.VariablesCount];
                    for (int i = 0; i < operands.Length; i++)
                        operands[i] = results.Pop();
                    results.Push(operation.Function(operands));
                }
            }
            return results.Pop();
        }
    }
}