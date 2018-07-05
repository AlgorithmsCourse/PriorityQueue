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
                while (!pq.IsEmpty)
                {
                    int i = pq.DelMin();
                    Console.WriteLine(i + " " + strings[i]);
                }
                Console.WriteLine();

                ////// reinsert the same strings
                ////for (int i = 0; i < strings.Length; i++)
                ////{
                ////    pq.Insert(i, strings[i]);
                ////}

                // print each key using the iterator
                foreach (int i in pq)
                {
                    Console.WriteLine(i + " " + strings[i]);
                }
                while (!pq.IsEmpty)
                {
                    Console.WriteLine("Min k={0} at {1}", pq.MinKey, pq.MinIndex);
                    Console.WriteLine("Removed {0}", pq.DelMin());
                }
            
        }
    }
}
