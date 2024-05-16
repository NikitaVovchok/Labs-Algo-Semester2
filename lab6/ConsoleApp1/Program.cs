using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 64, 25, 12, 22, 11, 90, 35, 67, 40, 28 };

        Console.Write("Початковий масив: ");
        PrintArray(arr);

        QuickSort(arr, 0, arr.Length - 1);

        Console.Write("Відсортований масив (у зворотному порядку): ");
        PrintArray(arr);

        Console.ReadLine();
    }

    static void QuickSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(arr, left, right);

            QuickSort(arr, left, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, right);
        }
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[right];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (arr[j] >= pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        Swap(arr, i + 1, right);
        return i + 1;
    }

    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}