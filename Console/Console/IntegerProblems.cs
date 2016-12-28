using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class IntegerProblems
    {
        /// <summary>
        /// Reverse digits of an integer.
        /// Example1: x = 123, return 321
        /// Example2: x = -123, return -321 
        /// </summary>
        /// <param name="x">The int to be reversed</param>
        /// <returns>The reversed int</returns>
        public int ReverseInteger(int x)
        {
            // It is possible to get underflows and overflows. To ovoid them we can use longs. 
            long result = 0;
            long temp = x >= 0 ? x : (x) * -1;
            while (temp > 0)
            {
                result = result * 10 + (temp % 10);
                temp /= 10;
            }

            result = x >= 0 ? result : result * -1;

            if (int.MinValue > result || int.MaxValue < result)
            {
                result = 0;
            }

            return (int)result;
        }

        /// <summary>
        /// Divide two integers without using multiplication, division and mod operator. 
        /// If it is overflow, return MaxInt.
        /// </summary>
        /// <param name="numerator">The numerator</param>
        /// <param name="denominator">The denominator </param>
        /// <returns>The result of the division</returns>
        public int Divide(int numerator, int denominator)
        {
            // We can simplify the solution by doing the calculations on positive numbers.
            // It is possible to get an overflow if you divide MinInt by -1. To avoid issues
            // we can use longs.
            long numeratorLong = (long)Math.Abs((long)numerator);
            long denominatorLong = (long)Math.Abs((long)denominator);
            long result = 0;

            // Let's figure out what is sign of the result. We can do it by using the XOR operator.
            bool negative = numerator < 0 ^ denominator < 0 ? true : false;

            if (denominator == 0 || (numerator == int.MinValue && denominator == -1))
            {
                return int.MaxValue;
            }

            while (numeratorLong >= denominatorLong)
            {
                long temp = denominatorLong;
                long multiple = 1;

                while(numeratorLong >= (temp <<1))
                {
                    temp <<= 1;
                    multiple <<= 1;
                }
                numeratorLong -= temp;
                result += multiple;
            }

            return negative ? (int)-result : (int)result;
        }
    }
}
