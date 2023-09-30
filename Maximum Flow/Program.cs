using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FordFulkerson fordFulkerson = new FordFulkerson();
            int result = fordFulkerson.Solve(Directory.GetParent(Environment.CurrentDirectory)?.Parent?.FullName + @"\input.txt");
            Console.WriteLine("Max flow is - "+result);
            Console.WriteLine();
            Console.WriteLine("The state of the flows in the graph at the end:");
            fordFulkerson.PrintFlows();
            Console.ReadLine();
        }
    }
}