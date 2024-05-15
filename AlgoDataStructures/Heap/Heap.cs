﻿using System;
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
            if (HeapArray == null) return -1;
            int index = GetLastNotEmptyIndex();
            if (index != -1)
            {
                int max = HeapArray[0];
                HeapArray[0] = HeapArray[index];
                HeapArray[index] = -1;
                RemoveMax(0);
                return max;
            }
            return -1; // если куча пуста
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
            int shift = 1;
            if (2 * index + 2 < HeapArray.Length && HeapArray[2 * index + 1] < HeapArray[2 * index + 2])
            {
                shift = 2;
            }
            if (2 * index + shift < HeapArray.Length && HeapArray[index] < HeapArray[2 * index + shift])
            {
                int temp = HeapArray[index];
                HeapArray[index] = HeapArray[2 * index + shift];
                HeapArray[2 * index + shift] = temp;
                RemoveMax(2 * index + shift);
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

        private bool AddElement(int index)
        {
            if ((index - 1) / 2 >= 0 && HeapArray[(index - 1) / 2] < HeapArray[index])
            {
                int temp = HeapArray[index];
                HeapArray[index] = HeapArray[(index - 1) / 2];
                HeapArray[(index - 1) / 2] = temp;
                return AddElement((index - 1) / 2);
            }
            return true;
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            if (HeapArray == null)
            {
                return false;
            }
            // добавляем новый элемент key в кучу и перестраиваем её
            int index = GetFirstEmptyIndex();
            if (index != -1)
            {
                HeapArray[index] = key;
                return AddElement(index);
            }
            return false; // если куча вся заполнена
        }

    }
}