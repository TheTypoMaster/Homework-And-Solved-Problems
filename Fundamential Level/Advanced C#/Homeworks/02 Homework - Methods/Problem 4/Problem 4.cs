using System;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 1, 2, 3, 4, 4 };

        Console.WriteLine(GetIndexOfFirstElementLargerThatNeighbours(numbers));
    }

    static int GetIndexOfFirstElementLargerThatNeighbours(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            if (IsLargerThanNeighbours(numbers, i))
            {
                return i;
            }
        }
        return -1;
    }

    static bool IsLargerThanNeighbours(int[] numbers, int i)
    {
        bool hasLeftNumber = (i > 0) ? true : false;
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
