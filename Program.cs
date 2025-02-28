using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        bool repeat = true;

        while (repeat)
        {
            try
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.Write("Введіть кількість елементів у списку: ");
                int numberOflist = int.Parse(Console.ReadLine());
                if (numberOflist <= 0)
                {
                    Console.WriteLine("\nКількість елементів у списку повинна бути більшою за 0.");
                    continue;
                }

                Console.Write("Введіть кількість елементів у рядку: ");
                int elementsOfline = int.Parse(Console.ReadLine());
                if (elementsOfline <= 0)
                {
                    Console.WriteLine("\nКількість елементів у рядку повинна бути більшою за 0 ");
                    continue;
                }
                else if (elementsOfline >= numberOflist)
                {
                    Console.WriteLine("\nКількість елементів у рядку повинна бути меншою за кількість елементів у списку");
                    continue;
                }
                List<int> numbers = new List<int>();
                for (int i = 1; i <= numberOflist; i++)
                {
                    numbers.Add(i);
                }
                PrintSpiral(numbers, elementsOfline);

                bool validResponse = false;
                while (!validResponse)
                {
                    Console.Write("\nБажаєте спробувати ще раз? (y/n): ");
                    string response = Console.ReadLine().ToLower();

                    if (response == "y" || response == "yes")
                    {
                        validResponse = true;
                    }
                    else if (response == "n" || response == "no")
                    {
                        repeat = false;
                        validResponse = true;
                    }
                    else
                    {
                        Console.WriteLine("\nПомилка: введіть 'y' або 'yes' для продовження, або 'n' або 'no' для виходу.");
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\nПомилка. Спробуйте ще раз.");
            }
        }
    }

    static void PrintSpiral(List<int> list, int elementsRow)
    {
        int totalRows = (int)Math.Ceiling((double)list.Count / elementsRow);

        for (int row = 0; row < totalRows; row++)
        {
            int start = row * elementsRow;
            int end = Math.Min(start + elementsRow, list.Count);

            List<int> rowElements = list.GetRange(start, end - start);

            if (row % 2 == 0)
            {
                foreach (var item in rowElements)
                {
                    Console.Write(item.ToString().PadLeft(4));
                }
            }
            else
            {
                rowElements.Reverse();
                foreach (var item in rowElements)
                {
                    Console.Write(item.ToString().PadLeft(4));
                }
            }
            Console.WriteLine();
        }
    }
}