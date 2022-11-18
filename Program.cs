using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace RocketCodingTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1,2,1,100,105,108,120,151,160};

            Console.WriteLine("Base Array: ");
            for (int i = 0; i < a.Length; i++)
                Console.Write(a[i] + ",");
            Console.WriteLine();

            //rotate base array with offset -1:
            Console.WriteLine("1. Rotate Array with offset -7: ");
            int[] a_ = Rotate(a, -7);
            for (int i = 0; i < a_.Length; i++)
                Console.Write(a_[i] + ",");
            Console.WriteLine();

            //
            Console.Write("2. Look for longest equivalent sub array: ");
            Console.WriteLine(longest(sort(a), 0, a.Length-1));
        }

        static int[] Rotate(int[] a, int offset)
        {
            int[] a_ = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                int newPos = (i + offset) % a.Length;
                if (newPos < 0)
                    newPos = a.Length + newPos;
                a_[newPos] = a[i];
            }
            return a_;
        }

        static int longest(int[]a, int leftPivot, int rightPivot) //need sorted array
        {
            if (rightPivot <= leftPivot)
                return 0;

            return max(longest(a, leftPivot, rightPivot - 1), longest(a, leftPivot+1, rightPivot), countSubArray(a, leftPivot, rightPivot));
        }

        static int max(int a, int b, int c)
        {
            int max = a;
            if (max < b)
                max = b;
            if (max < c)
                max = c;
            return max;
        }

        static int countSubArray(int[]a, int leftPivot, int rightPivot)
        {
            for (int i=leftPivot; i<=rightPivot; i++)
            {
                if (a[leftPivot] - a[rightPivot] < -1)
                    return 0;
            }
            return rightPivot - leftPivot + 1;
        }

        static int[] sort(int[]a)
        {
            int max = a[0];
            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a.Length; j++)
                    if (a[i] < a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
            return a;
        }

 

    }
}