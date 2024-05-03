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
            if (size == 0)
                return null;

            int i = 0;
            while (i < size && Tree[i] != null)
            {
                if ((int)Tree[i] == key)
                    return i;

                if (key < (int)Tree[i])
                {
                    i = 2 * i + 1;
                }
                else
                {
                    i = 2 * i + 2;
                }
            }

            if (Tree[i] == null)
                return -i;

            return null;
        }

        public int AddKey(int key)
        {
            int? index = FindKeyIndex(key);
            if (index != null && index < 0)
            {
                Tree[-(int)index] = key;
                capacity++;
                return -(int)index;
            }
            return index ?? -1;
        }

    }
}