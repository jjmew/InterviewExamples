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
        /// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers(both index1 and index2) are not zero-based.
        /// You may assume that each input would have exactly one solution.
        /// Input: numbers={2, 7, 11, 15}, target=9
        /// Output: index1=1, index2=2
        /// </summary>
        /// <remarks>This is not the optimal solution but this approach demonstrates the usage of binary search.</remarks>
        /// <param name="numbers">The array containing the list of numbers.</param>
        /// <param name="target">The sum to be found.</param>
        /// <returns></returns>
        public int[] TwoSumSortedArray(int[] numbers, int target)
        {
            if( numbers == null)
            {
                throw new ArgumentNullException("The argument numbers can't be null");
            }
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

        /// <summary>
        /// Given an array of integers that is already sorted in ascending order, find two numbers such that they add up to a specific target number.
        /// The function twoSum should return indices of the two numbers such that they add up to the target, where index1 must be less than index2. Please note that your returned answers(both index1 and index2) are not zero-based.
        /// You may assume that each input would have exactly one solution.
        /// Input: numbers={2, 7, 11, 15}, target=9
        /// Output: index1=1, index2=2
        /// </summary>
        /// <remarks> This solution implements a linear algorithm. We will start with two pointers. One at the begining and one to the end. If the sum of those is greater than what we are looking for then we will move back once 
        /// position the pointer at the end. If it is lower then we will advance the pointer at the begining by one spot. We will do this until we find that the expected sum or both pointers meet.</remarks>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSumSortedArrayV2(int[] numbers, int target)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("The argument numbers can't be null");
            }
            int[] result = new int[2];
            int start = 0;
            int end = numbers.Length - 1;
            while (start < end)
            {
                int sum = numbers[start] + numbers[end];

                if (sum == target)
                {
                    // Adding one to each index since the answer is not zero based
                    result[0] = start + 1;
                    result[1] = end + 1;
                    return result;
                }
                else if (sum > target)
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }

            return result;

        }

        /// <summary>
        /// Find the contiguous subarray within an array (containing at least one number) which has the largest sum. 
        /// For example, given the array[-2, 1, -3, 4, -1, 2, 1, -5, 4],
        /// the contiguous subarray[4, -1, 2, 1] has the largest sum = 6.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int nextMax = 0;
            int previousMax = 0;
            int largestNumber = int.MinValue;

            // if all the numbers are negative then the algorithm doesn't work
            // we need to find the max value and return that.
            for(int i=0; i < nums.Length;i++)
            {
                if(nums[i] > largestNumber)
                {
                    largestNumber = nums[i];
                }
            }

            if (largestNumber <0)
            {
                return largestNumber;
            }

            // Since we have at least one positive number then this algorigthm will work
            for (int i=0; i < nums.Length;i++)
            {
                nextMax = nextMax+ nums[i];

                if(nextMax < 0 )
                {
                    nextMax = 0;
                }
                if (previousMax < nextMax)
                    previousMax = nextMax;

            }
            return previousMax;
        }

        /// <summary>
        /// Rotate an array of n elements to the right by k steps.
        /// For example, with n = 7 and k = 3, the array[1, 2, 3, 4, 5, 6, 7] is rotated to[5, 6, 7, 1, 2, 3, 4]. 
        /// </summary>
        /// <param name="nums">The array to be rotated.</param>
        /// <param name="k">Numbers of postions to be rotated.</param>
        /// <remarks></remarks>
        public void RotateArray(int[] nums, int k)
        {
            if (nums == null)
            {
                throw new ArgumentNullException("The argument nums can't be null");
            }

            int limit = k % nums.Length;
            int[] temp = new int[limit];

            Array.Copy(nums, nums.Length - limit, temp, 0, limit);

            for (int i = 0; i < nums.Length; i++)
            {
                int pos = (nums.Length - 1 - i);
                if (pos < limit)
                {
                    nums[pos] = temp[pos];
                }
                else
                {
                    nums[pos] = nums[pos - limit];
                }
            }
        }

        /// <summary>
        /// Given an array of integers, every element appears twice except for one. Find that single one.
        /// </summary>
        /// <param name="nums">The array to be searched.</param>
        /// <returns>The number that only appears once.</returns>
        /// <remarks>
        /// This is a tricky one. The first instinct will be to compare each element to the whole arrary and see if it exist. This approach
        /// would work but it will be a o( n^2) solution. You could achieve a O(1) solution with hash tables. If this question ever gets asked
        /// during an interview then it is likely that the interviewer just wants to know if you are familiar with binary operators. Hence we 
        /// will solve this one by xor-ing all the elements. Keep in mind that at the end of the day an integer is just a collections of bits.
        /// At the end of the whole operation each bit that was set twice will become 0. The only bit set to 1 will be the bits that were only
        /// set once.
        /// </remarks>
        public int SingleNumber(int[] nums)
        {
            if (nums == null)
            {
                throw new ArgumentNullException("The argument nums can't be null");
            }

            int result = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                result = result ^ nums[i];
            }
            return result;
        }

        /// <summary>
        /// This is simple implementation of a binary search on. 
        /// </summary>
        /// <param name="numbers">The array to be searched.</param>
        /// <param name="value">The value to be found.</param>
        /// <param name="rangeMin">The lower limit (zero based) of the range to be searched. Use 0 if you want to search from the begining.</param>
        /// <param name="rangeMax">The top limit (zero based) of the range to be searched. Use numbers.Lenght if you want to search to the end.</param>
        /// <returns>Returns the index (zero based) of the item if it found. It returns -1 otherwise.</returns>
        public int BinarySearch(int[] numbers, int value ,int rangeMin, int rangeMax)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException("The argument numbers can't be null");
            }
            else if( rangeMin < 0 || rangeMax > (numbers.Length-1))
            {
                throw new ArgumentNullException("The argument rangeMin can't be lower than 0 and the argument rangeMax can't be larger than the array size");
            }

            int low = rangeMin;
            int high = rangeMax;

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
