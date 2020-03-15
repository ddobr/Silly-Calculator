using System;

namespace CodeRetreat
{
    class Program
    {
        static void Main()
        {
            var str = Console.ReadLine();
            var notation = Parser.CreateNotation(str);
            Console.WriteLine(CalculateClass.Calculate(notation));
            Console.ReadKey();
        }
    }
}