using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей
        public int size;
        public int capacity;

        public aBST(int depth)
        {
            int tree_size = (int)(Math.Pow(2, depth + 1) - 1);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
            size = tree_size;
        }

        public int? FindKeyIndex(int key)
        {
            if (Tree[0] == key || capacity == 0)
                return 0;

            int? node = null;
            for (int i = 0; i < size; i++)
            {
                node = Tree[i];
                if (node == key)
                    return i;
                else if (node == null)
                    return -i;

                bool goLeft = node > key;
                i = goLeft ? 2 * i : 2 * i + 1;
            }
            return null;
        }

        public int AddKey(int key)
        {
            int? res = FindKeyIndex(key);
            if (res != null && capacity <= size)
            {
                if (capacity == 0)
                {
                    Tree[0] = key;
                    capacity++;
                }

                else if (res < 0 && res != null )
                {
                    Tree[(int)res * (-1)] = key;
                    capacity++;
                    return (int)res * (-1);
                }

                return (int)res;
            }
            else
                return -1;
        }

    }
}