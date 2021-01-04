using System; //стандартна бібліотека з набором функцій тіпа Mаth і так далі
using System.Collections.Generic; //бібліотека щоб юзати списки List

namespace MyFunctions
{
    public class Func
    {
        public static int GetNumber(string label)  //отримання числа введенного з клавіатури
        {
            Console.Write(label + " : ");
            int number = Convert.ToInt32(Console.ReadLine());  //власне число
            Console.WriteLine();
            return number;  //повертаємо значення числа введеного з клавіатури
        }

        public static void CreateMatrix(ref int [,] matrix) //створення матриці заповненої рандомними числами
        {
            Random rand = new Random();  //рандом
            int size = (int)Math.Sqrt(matrix.Length);  //визначаємо розмір квадратної матриці

            for (int i = 0; i < size; i++) //і - індекс рядка матриці
            {
                for (int j = 0; j < size; j++)  //j - індекс стовпчика матриці
                    matrix[i, j] = rand.Next(10, 100);  //генеруємо елемент матриці
            }
        }

        public static void PrintMatrix(int [,] matrix)  //виведення матриці в консоль
        {
            int size = (int)Math.Sqrt(matrix.Length);  //визначаємо розмір квадратної матриці
            Console.WriteLine("Матриця :\n");

            for (int i = 0; i < size; i++)  //і - індекс рядка матриці
            {
                for (int j = 0; j < size; j++) //j - індекс стовпчика матриці
                    Console.Write(String.Format("{0,3}", matrix[i, j]));  //виводимо елемент
                Console.WriteLine("\n");
            }
        }

        public static void DiamondMatrix(int[,] matrix, ref int sum, ref int max) //робота з ромбом матриці
        {
            int space;  //кількість елементів яка відтинається в кожному рядку для формування з квадрата ромба
            int size = (int)Math.Sqrt(matrix.Length);  //визначаємо розмір квадратної матриці

            if (size % 2 == 1)  //для матриці з стороною рівною непарному числу
                space = (size - 1) / 2;
            else  //для матриці з стороною рівною парному числу
                space = (size / 2) - 1;

            max = matrix[0, space]; //ініціалізуємо максимальний елемент

            for (int i = 0; i < size; i++)  //і - індекс рядка матриці
            {
                for (int j = space; j < size - space; j++)  //j - індекс стовпчика матриці
                {
                    sum += matrix[i, j];             //елемент з верхньої частини ромба
                    sum += matrix[size - i - 1, j];  //елемент з нижньої частини ромба
                    if (matrix[i, j] > max)   //якщо максимальний елемент у верхній частині ромба
                        max = matrix[i, j];
                    if (matrix[size - 1 - i, j] > max)  //якщо максимальний елемент у нижній частині ромба
                        max = matrix[size - 1 - i, j]; 
                }

                if (space == 0)  //якщо досягли середини ромба, виходимо з циклу
                    break;

                space -= 1;  //зменшуємо кількість елементів з кожним рядком для формування з квадрата ромба
            }

            if (size % 2 == 1)  //якщо сторона матриці непарна - видаляємо зайву суму (сума елементів посередині порахуєтся двічі, тому одну віднімемо)
            {
                for (int i = 0; i < size; i++)
                    sum -= matrix[(size - 1) / 2, i];
            }
        }

        public static void ArrayNumbers(ref int [] array)  //ініціалізація масиву чисел
        {
            for(int i = 0; i<array.Length; i++)  //і - індекс масиву
            {
                Console.Write("Число " + (i+1) + " : ");
                array[i] = Convert.ToInt32(Console.ReadLine());   //введення числа з консолі
            }
            Console.WriteLine();
        }

        public static string Formula(int number)  //формування формули
        {
            int rez = number;   //зберігаємо дане число
            List<int> list = new List<int>();   //список з діями

            while (number != 1)  //поки дане число не стане одиницею
            {
                //якщо число ділиться націло на 3 ми ділимо на 3, інакше віднімаємо 5. Для числа 6 є фігня, коли воно ділиться на 3, но 6/3=2. А 6-5=1. Для решти чисел вроді всьо ок

                if (number % 3 == 0 && number != 6) 
                {
                    list.Add(3);  //додаємо дію множення на 3
                    number /= 3;
                }
                else
                {
                    list.Add(5);  //додаємо дію додавання 5
                    number -= 5;
                }
                if (number <= 0)  //якщо число не повертається до 1
                    break;

            }
            if (number <= 0)  //якщо число не можна представити вказаним шляхом формування формули
                return "! Число " + rez + " не може бути представлено заданою формулою.";

            string str = "1";  //строка в яку записується формула

            for (int i = list.Count - 1; i >= 0; i--)  //і - індекс списку. Формуємо формулу, на основі записаних дій
            {
                if (list[i] == 3)
                {
                    str = "(" + str + " * 3)";
                }
                else
                {
                    str = "(" + str + " + 5)";
                }

            }

            str = str + " = " + rez;  

            return str;  //повертаємо формулу
        }

        public static void PrintArray(string [] array)  //виведення масиву в консоль
        {
            for (int i = 0; i < array.Length; i++)  //і-індекс масиву строк
                Console.WriteLine(array[i]);
        }

        public static void CountSymbols(ref string [] array, ref int count_plus, ref int count_star)  //підрахунок локальної кількості та загальної + і *
        {            
            int temp_plus = 0;  //локальне значення кількості +
            int temp_star = 0;  //локальне значення кількості *

            for (int i = 0; i < array.Length; i++)  //і - індекс 
            {
                temp_plus = 0;  //обнулили значення перед проходженням нової строки
                temp_star = 0;  //обнулили значення перед проходженням нової строки
                string temp = array[i];  //поточна строка
                if (temp[0] != '!')  //якщо формула є
                {
                    for (int j = 0; j < temp.Length; j++)  //j - індекс символа строки
                    {
                        if (temp[j] == '+')
                            temp_plus += 1;  //підрахунок локальної кількості +
                        if (temp[j] == '*')
                            temp_star += 1;  //підрахунок локальної кількості *
                    }

                    array[i] += (" | К-сть '+' = " + temp_plus + " | К-сть '*' = " + temp_star);  //дописуємо до формули кількість + і *
                    count_plus += temp_plus;  //змінюємо значення загальної кількості +
                    count_star += temp_star;  //змінюємо значення загальної кількості *
                }
            }
        }


        public static void Connection(int sum, int max)  //щоб дві задачі між собою хоть якось були пов'язані
        {
            Console.WriteLine("\n Для знайдених суми та найбiльшого числа : \n");

            int[] numbers = { sum, max };  //масив чисел

            string[] numbersFormulas = new string[2];  //масив строк - де кожна строка - формула для числа            

            for (int i = 0; i < 2; i++)
                numbersFormulas[i] = Func.Formula(numbers[i]);   //формуємо формули для чисел

            Func.PrintArray(numbersFormulas);  //виводимо формули
            Console.WriteLine();

            int count_plus = 0;   //Загальнa кiлькiсть '+'
            int count_star = 0;   //Загальнa кiлькiсть '*'

            Func.CountSymbols(ref numbersFormulas, ref count_plus, ref count_star);   //підрахунок локальної та загальної кількості + і *
            Func.PrintArray(numbersFormulas);  //виводимо формули

            Console.WriteLine("\nЗагальнa кiлькiсть '+' : " + count_plus);   //виводимо загальну кількість +
            Console.WriteLine("Загальнa кiлькiсть '*' : " + count_star + "\n");     //виводимо загальну кількість *
        } 

    }
}
