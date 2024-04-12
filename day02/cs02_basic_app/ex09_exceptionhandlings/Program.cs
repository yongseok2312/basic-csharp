﻿using System.Diagnostics; // Debug 클래스를 사용하려면 추가

namespace ex09_exceptionhandlings
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[] array = new int[3] {1, 2, 3 };
            try
            {
             for (int i = 0; i < 4; i++)
                {
                 Console.WriteLine($"{array[i]}");
             }

            }
            catch(IndexOutOfRangeException ex)  // 모든 예외클래스의 조상이 Exception이므로
            {   // 어떤 예외클래스를 써야할지 모르면 무조건 Exception 클래스
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("프로그램 종료!");
            }
        }
    }
}
