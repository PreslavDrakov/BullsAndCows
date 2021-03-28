using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    class Program
    {
        static void Sravni(int num1, int num2, ref int bikove, ref int kravi)
        {
            int[] a = new int[4];
            int[] b = new int[4];
            int bik = 0, kr = 0;
            for (int i = 0; i < 4; i++)
            {
                a[i] = num1 % 10;
                num1 = num1 / 10;
            }
            for (int i = 0; i < 4; i++)
            {
                b[i] = num2 % 10;
                num2 = num2 / 10;
            }
            for (int i = 0; i < 4; i++)
            {
                if (a[i] == b[i]) bik++;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (a[i] == b[j]) kr++;
                }
            }
            kr = kr - bik;
            bikove = bik; kravi = kr;
        }



        static bool RepeatDig(int num1)
        {
            int[] a = new int[4];
            for (int i = 0; i < 4; i++)
            {
                a[i] = num1 % 10;
                num1 = num1 / 10;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                {
                    if (a[i] == a[j]) return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            int b = 0, k = 0; int biks, kravs; int number = 0;
            List<int> l = new List<int>();
            List<int> l1 = new List<int>();
            for (int i = 1023; i <= 9876; i++)
            {
                if (!RepeatDig(i)) l.Add(i);
            }
            do
            {
                number = l[0];
                Console.WriteLine("Is this the number {0}", number);
                Console.Write("How many bulls - ");
                biks = int.Parse(Console.ReadLine());
                Console.Write("How many cows - ");
                kravs = int.Parse(Console.ReadLine());
                foreach (int x in l)
                {
                    Sravni(number, x, ref b, ref k);
                    if ((b == biks) && (kravs == k)) l1.Add(x);
                }
                l.Clear();
                foreach (int x in l1)
                {
                    l.Add(x);
                }
                l1.Clear();
                Console.WriteLine(l.Count);
            } while ((l.Count > 0) && (biks != 4));
        }
       

    }
}
