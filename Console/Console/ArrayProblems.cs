using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    class ArrayProblems
    {


        /// <summary>
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        /// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2.Please note that your returned answers(both index1 and index2) are not zero-based.
        /// You may assume that each input would have exactly one solution.
        /// Input: numbers={2, 7, 11, 15}, target=9
        /// Output: index1=1, index2=2
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];

            int lastValue = numbers[0];
            int instances = 0;

            for(int i=0; i< numbers.Length; i++)
            {
                int complement = target - numbers[i];

                instances = lastValue == numbers[i]? instances++: 1;
                lastValue = numbers[i];

                int index = this.BinarySearch(numbers, complement, i+1, numbers.Length -1);

                if (index != -1)
                {
                    result[0] = i + 1;
                    result[1] = index + 1;
                    return result;
                }
            }
            return result;

        }

        public int BinarySearch(int[] numbers, int value ,int rangeMin, int rangeMax)

        {
            int low = rangeMin;
            int high = rangeMax;

            if (rangeMax > numbers.Length || rangeMin < 0)
                return -1;

            while( low <= high)
            {
                int med = (low + high) / 2;
                if (numbers[med]== value)
                {
                    return med;
                } 
                else if (numbers[med]> value)
                {
                    high = med-1;
                }
                else
                {
                    low = med +1;
                }
            }

            return -1;
        }
    }
}
