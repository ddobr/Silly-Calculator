using System;
using System.Collections.Generic;

namespace CodeRetreat
{
    public class Operation
    {
        public string Name { get;  }
        public int VariablesCount { get; }
        public int Priority { get; }
        public Func<double[], double> Function { get; }

        public Operation(string name, int variablesCount, Func<double[], double> function, int priority)
        {
            Name = name;
            VariablesCount = variablesCount;
            Function = function;
            Priority = priority;
        }

        public override string ToString() => Name;

        public override int GetHashCode() => Name.GetHashCode();
    }

    public static class Operations
    {
        public static Dictionary<string, Operation> Dictionary;

        static Operations()
        {
            Dictionary = new Dictionary<string, Operation>();
            
            Dictionary.Add("+", new Operation("+", 2, operands => operands[1] + operands[0], 1));
            Dictionary.Add("-", new Operation("-", 2, operands => operands[1] - operands[0], 1));
            Dictionary.Add("*", new Operation("*", 2, operands => operands[1] * operands[0], 2));
            Dictionary.Add("/", new Operation("/", 2, operands => operands[1] / operands[0], 2));
            Dictionary.Add("^", new Operation("^", 2, operands => Math.Pow(operands[1], operands[0]), 3));

            //Здесь могут быть Ваши операторы)
            //Для унарных операторов - приоритет -1
            //Не разобрался как быть с правоассоциативными, в парсере костыли из-за этого

            Dictionary.Add("sin", new Operation("sin", 1, operands => Math.Sin(operands[0]), -1));
            Dictionary.Add("cos", new Operation("cos", 1, operands => Math.Cos(operands[0]), -1));
            Dictionary.Add("tg", new Operation("tg", 1, operands => Math.Tan(operands[0]), -1));
            Dictionary.Add("sqrt", new Operation("sqrt", 1, operands => Math.Sqrt(operands[0]), -1));
            
            
            Dictionary.Add("(", new Operation("(", -1, null, 0));
            Dictionary.Add(")", new Operation(")", -1, null, 0));
        }
    }
}
