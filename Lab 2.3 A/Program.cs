using System;

namespace Lab2_Task3A
{
    
    class ArrayProcessor
    {
       
        private int[] array;

        // Конструктор класу, який приймає масив цілих чисел
        public ArrayProcessor(int[] inputArray)
        {
            this.array = inputArray;
        }

        // Метод 1: Пошук номера (індексу) максимального за модулем елемента
        public int GetMaxAbsIndex()
        {
            if (array == null || array.Length == 0) return -1;

            int maxAbsIndex = 0; // Початковий індекс максимуму

            for (int i = 1; i < array.Length; i++)
            {
                // Порівнюємо модулі чисел за допомогою Math.Abs
                if (Math.Abs(array[i]) > Math.Abs(array[maxAbsIndex]))
                {
                    maxAbsIndex = i; // Оновлюємо індекс
                }
            }
            return maxAbsIndex;
        }

        // Метод 2: Добуток елементів масиву, розташованих після першого додатного елемента
        public long GetProductAfterFirstPositive()
        {
            int firstPosIndex = -1; // Індекс першого додатного елемента

            // Шукаємо перший додатний елемент (> 0)
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    firstPosIndex = i;
                    break; // Перериваємо цикл після першого знайденого додатного
                }
            }

            // Якщо додатного елемента немає або він є останнім
            if (firstPosIndex == -1 || firstPosIndex == array.Length - 1)
            {
                return 0; // Наступних елементів немає
            }

            long product = 1; // Початковий добуток

            // Перемножуємо всі елементи після першого додатного
            for (int i = firstPosIndex + 1; i < array.Length; i++)
            {
                product *= array[i];
            }

            return product;
        }
    }

    // Головний клас програми (розміщується у тому самому файлі)
    class Program
    {
        // Метод Main знаходиться в самому кінці
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                
                Console.Write("Введіть кількість елементів n (або 0 для виходу): ");

                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine("\nПомилка! Введіть ціле число.");
                    continue;
                }

                if (n == 0)
                {
                    Console.WriteLine("\nЗавершення роботи програми.");
                    break;
                }

                if (n < 0)
                {
                    Console.WriteLine("\nРозмірність масиву має бути додатною!");
                    continue;
                }

                int[] inputArray = new int[n];
                Console.WriteLine($"\nВведіть {n} цілих чисел:");

                // Введення елементів із захистом від некоректного вводу
                for (int i = 0; i < n; i++)
                {
                    while (true)
                    {
                        Console.Write($"array[{i}] = ");
                        if (int.TryParse(Console.ReadLine(), out inputArray[i]))
                        {
                            break;
                        }
                        Console.WriteLine("\nПомилка введення! Спробуйте ще раз.");
                    }
                }

                // Створення об'єкта класу ArrayProcessor (ООП)
                ArrayProcessor processor = new ArrayProcessor(inputArray);

                // Виклик методів об'єкта
                int maxAbsIdx = processor.GetMaxAbsIndex();
                long product = processor.GetProductAfterFirstPositive();

                Console.WriteLine($"\n1) Номер (індекс) max за модулем елемента: {maxAbsIdx} (значення: {inputArray[maxAbsIdx]})");
                Console.WriteLine($"2) Добуток елементів після першого додатного: {product}");
            }
        }
    }
}