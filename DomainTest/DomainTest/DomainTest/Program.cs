using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainTest
{
    // custom implemetation of IEqualityComparer<string> interface
    class StringEqualityComparer : IEqualityComparer<string>
    {
        // function for checking that string2 contains string1
        public bool Equals(string string1, string string2)
        {
            if (string2.Contains(string1)) return true;
            else return false;
        }

        // custom GetHashCode implementation
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
    class Solution
    {
        public static int[] solution(string[] A, string[] B)
        {
            //result list
            List<int> indexes = new List<int>();

            // create and initialize HashSet object hash_set
            HashSet<string> hash_set = new HashSet<string>();
            // create and initialize StringEqualityComparer object comparer
            StringEqualityComparer comparer = new StringEqualityComparer();

            // fill all blocked domain values to HashSet
            for (int i = 0; i < B.Length; i++) hash_set.Add(B[i]);

            // loop for all elements (domains) of A array
            for (int i = 0; i < A.Length; i++)
            {
                // check if hash_set contains current element of A with custom comparer
                if (!hash_set.Contains(A[i], comparer))
                {
                    // if OK - add index to result list of integers
                    indexes.Add(i);
                }
            }
            // return value converted to array of integers
            return indexes.ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // sample arrays (right from the task)
            string[] A_arr = { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us" };
            string[] B_arr = { "microvirus.md", "visitwar.de", "piratebay.co.uk", "list.stolen.credit.card.us" };

            // calling our function to get non-blocked domains, the result stores in array of integers - indexes
            int[] indexes = Solution.solution(A_arr, B_arr);

            // output array of indexes to console
            for (int i = 0; i < indexes.Length; i++)
            {
                Console.Write(indexes[i] + " ");
            }

            // wait until the button pressed
            Console.ReadKey();
        }
    }
}