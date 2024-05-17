using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {

        public int[] HeapArray; // хранит неотрицательные числа-ключи

        public Heap() { HeapArray = null; }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            HeapArray = new int[(int)Math.Pow(2, depth + 1) - 1];

            Array.Fill(HeapArray, -1);

            foreach (int num in a)
            {
                Add(num);
            }
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            if (HeapArray == null || HeapArray[0] == -1)
                return -1;

            int max = HeapArray[0];
            HeapArray[0] = HeapArray[GetLastNotEmptyIndex()];
            HeapArray[GetLastNotEmptyIndex()] = -1;
            RemoveMax(0);

            return max; // если куча пуста
        }

        private int GetLastNotEmptyIndex()
        {
            for (int i = HeapArray.Length - 1; i >= 0; i--)
            {
                if (HeapArray[i] != -1)
                {
                    return i;
                }
            }
            return -1;
        }

        private void RemoveMax(int index)
        {
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;
            int maxChild = index;

            if (leftChild < HeapArray.Length && HeapArray[leftChild] > HeapArray[maxChild])
            {
                maxChild = leftChild;
            }
            if (rightChild < HeapArray.Length && HeapArray[rightChild] > HeapArray[maxChild])
            {
                maxChild = rightChild;
            }

            if (maxChild != index)
            {
                int temp = HeapArray[index];
                HeapArray[index] = HeapArray[maxChild];
                HeapArray[maxChild] = temp;
                RemoveMax(maxChild);
            }
        }

        private int GetFirstEmptyIndex()
        {
            for (int i = 0; i < HeapArray.Length; i++)
            {
                if (HeapArray[i] == -1)
                {
                    return i;
                }
            }
            return -1;
        }

        private void AddElement(int index)
        {
            while (index > 0 && HeapArray[index] > HeapArray[(index - 1) / 2])
            {
                int parentIndex = (index - 1) / 2;
                int temp = HeapArray[index];
                HeapArray[index] = HeapArray[parentIndex];
                HeapArray[parentIndex] = temp;
                index = parentIndex;
            }
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            int index = GetFirstEmptyIndex();
            if (index != -1)
            {
                HeapArray[index] = key;
                AddElement(index);
                return true;
            }
            return false; // если куча вся заполнена
        }

    }
}