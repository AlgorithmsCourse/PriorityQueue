using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
 
                // insert a bunch of strings
                string[] strings = { "15", "20", "9", "2", "8", "55", "7", "93", "13", "60" };

                IndexMinPQ<int> pq = new IndexMinPQ<int>(strings.Length);
                for (int i = 0; i < strings.Length; i++)
                {
                var key = Convert.ToInt32(strings[i]);
                    pq.Insert(i, key);
                }

                // delete and print each key
                while (!pq.IsEmpty())
                {
                    int i = pq.DelMin();
                    Console.WriteLine(i + " " + strings[i]);
                }
                Console.WriteLine();


            
        }
    }
}
