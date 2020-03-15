using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace CodeRetreat
{
    static class Parser
    {
        public static string[] CreateNotation(string stringToParse)
        {
            var splittedString = stringToParse.Split(' ');
            var notation = new List<string>();
            var stack = new Stack<string>();

            for (var i = 0; i < splittedString.Length; i++)
            {
                var element = splittedString[i];
                double num;

                if (double.TryParse(element, out num))
                    notation.Add(element);
                else if (element == "(")
                    stack.Push(element);
                else if (element == ")")
                {
                    while(stack.Count != 0 && stack.Peek() != "(")
                        notation.Add(stack.Pop());
                    stack.Pop();
                    if (stack.Count != 0 && Operations.Dictionary[stack.Peek()].VariablesCount == 1)
                        notation.Add(stack.Pop());
                }
                else if (Operations.Dictionary[element].VariablesCount == 2)
                {
                    while (stack.Count != 0 && element != "^" && Operations.Dictionary[stack.Peek()].Priority >= Operations.Dictionary[element].Priority)
                        notation.Add(stack.Pop());
                    stack.Push(element);
                }
                else if (Operations.Dictionary[element].VariablesCount == 1)
                    stack.Push(element);
                else notation.Add(element);
            }

            while(stack.Count != 0)
                notation.Add(stack.Pop());

            return notation.ToArray();
        }
    }
}
