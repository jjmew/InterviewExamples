using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            ArrayProblems t = new ArrayProblems();

            //int[] num = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 5, 5, 6, 7, 8, 9, 10 };

            //int a= t.BinarySearch(num, 1);
            //a = t.BinarySearch(num, 0);
            //a = t.BinarySearch(num, 5);
            //a = t.BinarySearch(num, 10);


            int[] num = { 5, 25, 75};

            t.TwoSum(num, 100);

        }
    }
}
