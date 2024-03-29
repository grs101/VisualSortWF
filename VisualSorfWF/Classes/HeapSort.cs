﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualSorfWF
{
    class HeapSort
    {
        //класс пирамидальной сортировки

        //siftDown метод - просеивает элемент вниз
        static Int32 siftDown(Int32[] arr, Int32 i, Int32 N) 
        {
            Int32 imax;
            Int32 buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }

        static void Pyramid_Sort(ref Int32[] arr, Int32 len, ref PictureBox picbox, int min, int max)
        {
            //step 1: building the pyramid
            for (Int32 i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = siftDown(arr, i, len);
                if (prev_i != i) ++i;
            }

            //step 2: sorting
            for (Int32 k = len - 1; k > 0; --k)
            {
                Swap.start(ref arr[0], ref arr[k]);
                if (picbox != null)
                {
                    Draw.begin(ref picbox, arr, max);
                }
                Int32 i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = siftDown(arr, i, k);
                }
            }
        }

        public static void begin(ref int [] arr, ref PictureBox picbox, int min, int max)
        {
            //сортировка
            Pyramid_Sort(ref arr, arr.Length, ref picbox, min, max);
        }
    }
}