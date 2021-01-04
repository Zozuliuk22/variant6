using System; //стандартна бібліотека з набором функцій тіпа Mаth і так далі
using MyFunctions; //наша бібліотека з функціями (в с# це методи)

namespace Variant6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Format("{0,25}", "Part1\n"));

            int size = Func.GetNumber("Введiть розмiр квадратної матрицi");  //ініціалізуємо розмір квадратної матриці
            int[,] matrix = new int[size, size];  //створюємо матрицю

            Func.CreateMatrix(ref matrix); //ініціалізуємо матрицю
            Func.PrintMatrix(matrix);  //виводимо матрицю на екран
            
            int sum = 0, max = 0;  //ініціалізуємо суму елементів ромба матриці та найбільший елемент даного сектора
            Func.DiamondMatrix(matrix, ref sum, ref max);  //знаходимо цих два параметри
            
            Console.WriteLine("Сума елементiв ромба матрицi : " + sum);  //виводимо суму
            Console.WriteLine("Максимальний елемент ромба матрицi : " + max);  //виводимо максимальний елемент
            
            Console.WriteLine("\n" + String.Format("{0,25}", "Part2\n"));

            Func.Connection(sum, max); //щоб дві задачі хоть якийсь зв'язок мали

            int count_numbers = Func.GetNumber("Введiть кiлькiсть чисел, якi Ви хочете опрацювати");   //кількість чисел, які хоче ввести користувач

            int [] numbers = new int [count_numbers];  //масив чисел

            Func.ArrayNumbers(ref numbers);  //ініціалізація масиву чисел
             
            string [] numbersFormulas = new string[count_numbers];  //масив строк - де кожна строка - формула для числа

            for (int i = 0; i < count_numbers; i++) 
                numbersFormulas[i] = Func.Formula(numbers[i]);   //формуємо формули для чисел

            Func.PrintArray(numbersFormulas);  //виводимо формули
            Console.WriteLine();

            int count_plus = 0;   //Загальнa кiлькiсть '+'
            int count_star = 0;   //Загальнa кiлькiсть '*'
           
            Func.CountSymbols(ref numbersFormulas, ref count_plus, ref count_star);   //підрахунок локальної та загальної кількості + і *
            Func.PrintArray(numbersFormulas);  //виводимо формули

            Console.WriteLine("\nЗагальнa кiлькiсть '+' : " + count_plus);   //виводимо загальну кількість +
            Console.WriteLine("Загальнa кiлькiсть '*' : " + count_star);     //виводимо загальну кількість *

            Console.ReadKey(); //щоб консольне вікно не закривалось зразу
        }
    }
}
