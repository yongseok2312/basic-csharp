﻿namespace ex08_generics2
{
    internal class Program
    {
        // 배열 복사 가능 -> 일반화
        // 메서드 뒤에 <T>, 각 매개변수의 타입대신 T로 변경
        static void CopyArray<T>(T[] src, T[] dest)
         {
                for (int i = 0; i < src.Length; i++)
            {
                dest[i] = src[i];
            }
        }
        //static void CopyArray(float[] src, float[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //    {
        //        dest[i] = src[i];
        //    }
        //}

        //static void CopyArray(string[] src, string[] dest)
        //{
        //    for (int i = 0; i < src.Length; i++)
        //    {
        //        dest[i] = src[i];
        //    }
        //}

        static void Main(string[] args)
        {
            int[] array1 = {10, 20, 30, 50, 70};
            int[] array2 = new int[array1.Length];

            CopyArray(array1 , array2);

            Console.WriteLine(array2[4]);

            float[] array3 = {3.4f, 2.2f, 7.7f };
            float[] array4 = new float[array3.Length];

            CopyArray(array3, array4);
            Console.WriteLine(array4[2]);

            string[] array5 = { "H", "B", "Q" };
            string[] array6 = new string[array5.Length];

            CopyArray( array5, array6);
            Console.WriteLine(array6[2]);

        }

       

    }
}
