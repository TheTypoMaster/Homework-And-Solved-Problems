using System;
using System.Linq;
using System.Numerics;

class ArraySlider
{
    static void Main()
    {
        int currentIndex = 0;
        int offset = 0;
        string operation;
        int operand = 0;

        BigInteger[] array = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries).Select(x => BigInteger.Parse(x)).ToArray();

        string command = Console.ReadLine();
        while (command != "stop")
        {
            string[] stringArgs = command.Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries);
            offset = int.Parse(stringArgs[0]) % array.Length;
            operation = stringArgs[1];
            operand = int.Parse(stringArgs[2]);

            if (offset > 0)
            {
                currentIndex = (currentIndex + offset) % array.Length;
            }
            else
            {
                currentIndex = (currentIndex + offset + array.Length) % array.Length;
            }

            CalculateResult(currentIndex, array, operation, operand);
            command = Console.ReadLine();
        }
        Console.WriteLine("[{0}]", string.Join(", ", array));
    }

    private static void CalculateResult(int currentIndex, BigInteger[] array, string operation, int operand)
    {
        switch (operation)
        {
            case "&":
                array[currentIndex] &= operand; break;
            case "|":
                array[currentIndex] |= operand; break;
            case "^":
                array[currentIndex] ^= operand; break;
            case "+":
                array[currentIndex] += operand; break;
            case "-":
                array[currentIndex] -= operand; break;
            case "*":
                array[currentIndex] *= operand; break;
            case "/":
                array[currentIndex] /= operand; break;
            default:
                break;
        }

        if (array[currentIndex] < 0)
        {
            array[currentIndex] = 0;
        }
    }
}
