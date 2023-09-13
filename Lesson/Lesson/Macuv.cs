using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson
{
    public class Macuv
    {
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }

        public enum SortAlgorithmType
        {
            Selection,
            Bubble,
            Insertion
        }
        public static int[] arr = { 3, 1, 2 };
        public static int[] Sort(int[] arr, SortAlgorithmType sortAlgorithmType)
        {
            //Selection
            for (var i = 0; i < arr.Length - 1; i++)
            {
                var minKey = i;
                for (var j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minKey])
                    {
                        minKey = j;
                    }
                }

                var temp = arr[i];
                arr[i] = arr[minKey];
                arr[minKey] = temp;

            }

            //Bubble 
            if (sortAlgorithmType == SortAlgorithmType.Bubble)
             {
                for (int a = 0; a <= arr.Length - 2; a++)
                {
                    int x;

                    for (int i = 0; i <= arr.Length - 2; i++)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            x = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = x;
                        }
                    }
                }
            }
            //Insertion
            if (sortAlgorithmType == SortAlgorithmType.Insertion)
            {
                for (var i = 1; i < arr.Length; i++)
                {
                    var key = arr[i];
                    var j = i;
                    while ((j > 1) && (arr[j - 1] > key))
                    {
                        Swap(ref arr[j - 1], ref arr[j]);
                        j--;
                    }
                    arr[j] = key;
                }
            }
            return arr;
        }

    }
}
