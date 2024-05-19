using System;

namespace AlgorithmsDataStructures2
{
    public class Heap
    {
        public int[] HeapArray; // хранит неотрицательные числа-ключи
        private int capacity;

        public Heap()
        {
            HeapArray = null;
            capacity = 0;
        }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...
            int size = (int)Math.Pow(2, depth + 1) - 1;
            HeapArray = new int[size];
            capacity = 0;

            foreach (var key in a)
            {
                Add(key);
            }
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            if (capacity == 0)
                return -1; //куча пуста

            int max = HeapArray[0];
            HeapArray[0] = HeapArray[capacity - 1];
            capacity--;
            HeapifyDown(0);

            return max;
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (capacity >= HeapArray.Length)
                return false; //куча заполнена

            HeapArray[capacity] = key;
            capacity++;
            HeapifyUp(capacity - 1);
            return true;
        }

        private void HeapifyDown(int index)
        {
            int largest = index;
            int leftChild = 2 * index + 1;
            int rightChild = 2 * index + 2;

            if (leftChild < capacity && HeapArray[leftChild] > HeapArray[largest])
                largest = leftChild;

            if (rightChild < capacity && HeapArray[rightChild] > HeapArray[largest])
                largest = rightChild;

            if (largest != index)
            {
                Swap(index, largest);
                HeapifyDown(largest);
            }
        }

        private void HeapifyUp(int index)
        {
            int parent = (index - 1) / 2;
            if (parent >= 0 && HeapArray[parent] < HeapArray[index])
            {
                Swap(parent, index);
                HeapifyUp(parent);
            }
        }

        private void Swap(int index1, int index2)
        {
            int temp = HeapArray[index1];
            HeapArray[index1] = HeapArray[index2];
            HeapArray[index2] = temp;
        }
    }
}
