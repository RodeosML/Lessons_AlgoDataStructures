﻿using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures4
{
    public static class BalancedBST
    {
        public static int[] BalanceBST;
        public static int[] GenerateBBSTArray(int[] a)
        {
            Array.Sort(a);

            BalanceBST = new int[a.Length];
            Balance(a, 0);

            return BalanceBST;
        }

        private static void Balance(int[] array, int index)
        {
            if (array.Length == 0)
                return;

            int centerIndex = array.Length / 2;

            if (index < BalanceBST.Length)
                BalanceBST[index] = array[centerIndex];

            int[] leftArrWithoutMid = new int[centerIndex];
            int[] rightArrWithoutMid = new int[array.Length - leftArrWithoutMid.Length - 1];

            Array.Copy(array, 0, leftArrWithoutMid, 0, leftArrWithoutMid.Length);
            Array.Copy(array, centerIndex + 1, rightArrWithoutMid, 0, rightArrWithoutMid.Length);

            Balance(leftArrWithoutMid, 2 * index + 1);
            Balance(rightArrWithoutMid, 2 * index + 2);
        }
    }
}