using System;

class Program
{
    static void Main()
    {
        int[] numbers = { 5, 2, 5, 4, 5 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(IsLargerThanNeighbours(numbers, i));
        }
    }

    static bool IsLargerThanNeighbours (int[] numbers, int i)
    {
        bool hasLeftNumber = (i > 0) ? true: false;
        bool hasRightNumber = (i < numbers.Length - 1) ? true : false;
        bool isLarger = false;

        if (hasLeftNumber && hasRightNumber)
        {
            isLarger = (numbers[i] > numbers[i - 1]) && (numbers[i] > numbers[i + 1]) ? true : false;
        }
        else if (hasLeftNumber && !hasRightNumber)
        {
            isLarger = (numbers[i] > numbers[i - 1]) ? true : false;
        }
        else if (!hasLeftNumber && hasRightNumber)
        {
            isLarger = (numbers[i] > numbers[i + 1]) ? true : false;
        }
        return isLarger;
    }
}
