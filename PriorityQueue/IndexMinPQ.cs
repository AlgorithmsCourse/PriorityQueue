﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityQueue
{
    class IndexMinPQ<Key> where Key: IComparable
    {
        //array of some subset of keys that are comparable
        Key[] _keys;
        //priority order of keys, but by using int value associated with them instead of comparable value
        int[] _pq;
        //index of each key with it's position in PQ; maps each int to a key, and therefor each key to a ranking in PQ
        int[] _index;
        //num of items in PQ
        int N = 0;

        public IndexMinPQ(int capacity)
        {
            _keys = new Key[capacity];
            _pq = new int[capacity + 1];
            _index = new int[capacity];
            for(int i = 0; i<capacity; i++)
            {
                _index[i] = -1;
            }

        }

        //client will need to check first if a key is already associated with k to determine call to Insert() or Change()
        public void Insert(int k, Key key)
        {
            
            N++;
            //put the comparable 'key' values on array at index k -- k now references key on the PQ
            _keys[k] = key;
            //load the key onto end of PQ, using the key's index value
            _pq[N] = k;
            //sets the associated index of 'key' to its initial rank at end of PQ
            _index[k] = N;
            Swim(N);

        }
        //call swim on the value at PQ index k
        public void Swim(int k)
        {
            //check if there is a parent; if k = 1, there is no parent
            // AND check if the value at K  is less than the value at the parent parent
            while(k>1 && kIsLess(k, k/2))
            {
                var temp = _pq[k];
                _pq[k] = _pq[k / 2];
                _pq[k / 2] = temp;
                _index[_pq[k]] = k;
                _index[_pq[k/2]] = k/2;
                k = k / 2;
            }

        }

        private void Sink(int k)
        {
            //make sure not to compare past N
        }
        private bool kIsLess(int k, int l)
        {   //convert pq indexes k and k/2 to their comparable 'key' value
            var kVal = _keys[_pq[k]];
            var lVal = _keys[_pq[l]];
            //if kval is less than lVal, then CompareTo will return -1 and statement will be True
            return kVal.CompareTo(lVal) < 0;
        }
        
        //checks if key associated with int k is already on the _pq
        public bool Contains(int k)
        {
            return _index[k] != -1;

        }
        //will only change out a key if it is currently lower than the value that is currently at that index
        //therefore, will only need to test swim  on new value to see if position on _pq will change
        public void Change(int k, Key key)
        {
            _keys[k] = key;
            Swim(_pq[_index[k]]);
        }
        //Deletes item from PQ by replacing it with item at N and decrementing N;
        public void Delete(int k)
        {
            //TODO: Implement Delete
        }

        public Key Min()
        {
            return _keys[_pq[1]];
        }

        public int MinIndex()
        {
            return _pq[1];
        }
        public int DelMin()
        {
            var IdxMin = _pq[1];
            _pq[1] = _pq[N];
            _index[IdxMin] = -1;

            Sink(_pq[1]);
            
            N--;
            return IdxMin;
        }

        public bool isEmpty() => N == 0;


        int Size() => N;


        
    }
}
