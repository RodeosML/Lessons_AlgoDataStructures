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
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = 0;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
            size = tree_size;
        }

        public int? FindKeyIndex(int key)
        {
            // ищем в массиве индекс ключа
            int index = 0;
            while (index < size)
            {
                if (Tree[index] == null)
                    return -index; // возвращаем индекс, где ключ должен быть вставлен
                if (Tree[index] == key)
                    return index;
                index = key < Tree[index] ? 2 * index + 1 : 2 * index + 2; // определяем направление движения
            }
            return null;
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            int? index = FindKeyIndex(key);
            if (index != null && index < 0) // ключ не найден, вставляем его
            {
                Tree[-(int)index] = key;
                capacity++;
                return -(int)index;
            }
            return index ?? -1; // индекс добавленного/существующего ключа или -1 если не удалось
        }

    }
}