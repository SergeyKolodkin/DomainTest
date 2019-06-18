using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainTest
{    
    class Solution
    {
        // this is recursive function that checks given reversed url-array 'a_url' for containing in hashset of blocked domains  'hst'
        public static bool IsBlocked(HashSet<string> a_hst, string[] a_url)
        {
            // if url-array 'a_url' lenght is 0, then there is no more domains in array, so it is non-blocked
            if (a_url.Length == 0) return false;

            // if 'a_hst' contains current url (url-array concatenated to string with '.' delimeter) 
            // then this domain blocked and function returns true. This is O(1) complexity operation
            if (a_hst.Contains(string.Join(".", a_url))) return true;

            // else we call IsBlocked(...) function again, and passing as second parameter all elements of 'a_url'
            // array but last one. By this way we checking all subdomains of 'a_url' for containing in blocked domains HashSet
            else return IsBlocked(a_hst, a_url.Take(a_url.Length - 1).ToArray());
        }
        // this is main class function that gets array of domains 'A', array of blocked domains 'B' 
        // and returns array of integers that contains non-blocked domain's indexes of 'A' array
        public static int[] solution(string[] A, string[] B)
        {
            // result list
            List<int> indexes = new List<int>();

            // declare hashset for storing blocked domains
            HashSet<string> hst = new HashSet<string>();

            // initialize hashset 'hst' by 'B' array values. 
            // Each string in 'B' splitted by '.' character, converted to array and this array reversed
            foreach (var b in B)
                hst.Add(string.Join(".", b.Split('.').Reverse().ToArray()));

            // loop for all domains in 'A' array (for checking is they blocked or not)
            for (int i = 0; i < A.Length; i++)
            {
                // splitting string from 'A' array to reversed array of all domains that url contains
                var url_arr = A[i].Split('.').Reverse().ToArray();

                // checking if current url blocked or not. If not, adding it's index to list 'indexes'
                if (!IsBlocked(hst, url_arr)) indexes.Add(i);
            }

            // return value converted to array of integers
            return indexes.ToArray();
        }
    }
    class Program
    {        
        static void Main()
        {
            // sample arrays (right from the task)
            string[] A_arr = { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us", "sberbank.ru" };
            string[] B_arr = { "microvirus.md", "visitwar.de", "piratebay.co.uk", "list.stolen.credit.card.us", "uk" };

            // result array with indexes of non-blocked domains in 'A_arr'
            int[] non_blocked_domains = Solution.solution(A_arr, B_arr);

            // output array of non-blocked domains to console
            for (int i = 0; i < non_blocked_domains.Length; i++)
                Console.Write(non_blocked_domains[i] + " ");

            // wait until the button pressed
            Console.ReadKey();
        }
    }
}