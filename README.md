# DomainTest
Test task from SimpleCode
  
A router has an in-memory collection B of M external domains which cannot be visited by local
network user. There is a rule that if a domain is blocked, any its subdomains are blocked too.
For example, if domain adult.hb is blocked, the following hosts are blocked too:
images.adult.hb, ringo.adult.hb, video.ringo.adult.hb

Write a function (in C#):
class Solution { public static int[] solution(string[] A, string[] B); }
that, given a non-empty array A of N hosts, and B of M blocked domains, returns a sequence
consisting of L integers where each integer represents an index of a host in input A array that can
be visited by user.
For example, given:
  
A[0] = unlock.microvirus.md;  
A[1] = visitwar.com;  
A[2] = visitwar.de;  
A[3] = fruonline.co.uk;  
A[4] = australia.open.com;  
A[5] = credit.card.us.  
  
B[0] = microvirus.md;  
B[1] = visitwar.de;  
B[2] = piratebay.co.uk;  
B[3] = list.stolen.credit.card.us.  
  
the function should return the array [1, 3, 4, 5], as explained above.
  
Assume that:
• N and M are integers within the range [1..20,000];
• L is integer within the range [0..20,000];
• each element of array A is a string with length [2.. 256];
• each element of collection B is a string with length [2..256].

Complexity:  
• expected worst-case time complexity is O(N);  
• expected worst-case space complexity is O(M), beyond input storage (not counting the
storage required for input arguments).  
  
Looping over the list B for each item in the list A to find a match is not an option. If we check
1000 hosts in the list of 100 blocked domains, we would do this way 100000 string comparisons.
It would be simply too slow. The list of blocked domains B can be considered as rare changed.
Elements of input arrays cannot be modified.
