using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UFAR.DM.Checkpoint {
    public static class MergeSort {
        public static int[] MergeSortF(int[] array) {
            if (array.Length == 1)
            {
                return array;
            }
            int half = array.Length / 2;
            int[] arrA = new int[half];
            int[] arrB = new int[array.Length - half];
            

            for (int i = 0; i < half; i++)
            {
                arrA[i] = array[i];
            }
            for (int i = 0; i < array.Length - half; i++)
            {
                arrB[i] = array[half + i];
            }

            arrA = MergeSortF(arrA);
            arrB = MergeSortF(arrB);

            return Merge(arrA, arrB);
        }

        private static int[] Merge(int[] arrA, int[] arrB) {
            int LA = arrA.Length;
            int LB = arrB.Length;

            int newLength = LA + LB;
            int[] rarray = new int[newLength];
            int k = 0;
            int n1 = 0;
            int n2 = 0;

            // Compare and merge
            while (n1 < LA && n2 < LB) {
                if (arrA[n1] < arrB[n2]) {
                    rarray[k] = arrA[n1];
                    n1++;
                } else {
                    rarray[k] = arrB[n2];
                    n2++;
                }
                k++;
            }

            while (n1 < LA) {
                rarray[k] = arrA[n1];
                n1++;
                k++;
            }

            while (n2 < LB) {
                rarray[k] = arrB[n2];
                n2++;
                k++;
            }

            return rarray;
        }

    }
}
