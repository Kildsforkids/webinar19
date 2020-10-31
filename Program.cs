// Библиотека, которая позволяет нам
// использовать функции класса Console, Random и Array
using System;
// Библиотека для работы со списками вроде List<>
using System.Collections.Generic;

// Пространство имен
// Позволяет отделять код в зависимости от целей
namespace Webinar19 {
    // Класс, с которого начинается выполнение данной консольной программы
    class Program {
        // Главная функция, с которой начинается выполнение программы
        static void Main(string[] args) {
            // Сравнение чисел
            Comparison();

            // Калькулятор
            //Calc();

            // Чат-бот
            //Bot();

            // Вывод массива в прямом и обратном порядках
            //InvertedArray();

            // Вывод отдельных подстрок заданной строки в алфавитном порядке
            //Alphabet();

            // Рассчет факториала числа
            //GetFactorial();

            // Ожидаем нажатие клавиши со стороны пользователя,
            // чтобы консоль не закрывалась сразу после выполнения кода
            Console.ReadKey();
        }

        // static мы рассмотрим позже, здесь его следует писать перед
        // объявлением функции, чтобы можно было вызвать ее внутри Main.
        // void указывает на то, что функция отработает как процедура,
        // то есть не будет возвращать никаких значений
        static void GetFactorial() {
            // Вывод строки на консоль без перехода на новую строчку
            Console.Write("Введите число: ");
            // Пользователь вводит строку, преобразуем ее в тип int
            // и передаем переменной x, которая теперь тоже будет типа int
            var x = int.Parse(Console.ReadLine());
            // Выводим на консоль значение переменной x
            // и результат выполнения функции Factorial(x)
            Console.WriteLine($"{x}! = {Factorial(x)}");
            // Здесь используется интерполяция строки.
            // При помощи символа $ мы указываем, что все, что попадает
            // между { } относится к программному коду, а не к строке
        }

        // Функция Factorial возвращает значение типа int (целое число)
        static int Factorial(int x) {
            // Если x равен 1, то функция вернет число 1
            if (x == 1) return 1;
            // Здесь работает рекурсия
            // Например, при x равном 3 работу функции Factorial (F) можно представить
            // в следующем виде
            // F(3) = F(2) * 3 = F(1) * 2 * 3 = 1 * 2 * 3
            return Factorial(x - 1) * x;
        }

        static void Alphabet() {
            // Здесь пользователь вводит строку,
            // которую мы разбиваем на подстроки, разделенные пробелом (' '),
            // и записываем все в массив input, который теперь хранит эти подстроки
            string[] input = Console.ReadLine().Split(' ');

            // Сортируем массив подстрок в алфавитном порядке
            Array.Sort(input);

            // Выводим каждую отдельную подстроку на новой строчке в консоли
            foreach (var str in input)
                Console.WriteLine(str);
        }

        static void InvertedArray() {
            // Создаем генератор случайных чисел
            Random rand = new Random();
            // Создаем массив целых чисел (int) размерностью 10 элементов
            int[] array = new int[10];

            // Заполняем массив случайными значениями
            for (int i = 0; i < array.Length; i++)
                // rand.Next(n, m) возвращает случайное число в диапазоне [n, m)
                array[i] = rand.Next(-100, 101);

            PrintArray(array);
            //Array.Sort(array);
            PrintArray(array, true);
        }

        static void PrintArray(int[] x, bool isInverted = false) {
            // Если isInverted - true, то выведем массив x в обратном порядке
            if (isInverted) {
                for (int i = x.Length - 1; i >= 0; i--) {
                    Console.Write($"{x[i]} ");
                }
            } else {
                foreach (var element in x)
                    Console.Write($"{element} ");
            }
            Console.WriteLine();
        }

        static void Bot() {
            // Массив для int по умолчанию инициализируется 0
            int[] x = new int[10];

            // Можем менять значение конкретного элемента массива
            // по индексу от 0 до Размер_массива - 1 (x.Length - 1)
            x[0] = 10;

            // Массивы имеют строго заданную длину (количество элементов)
            // при инициализации и не могут ее менять, в отличие от списков
            string[] phrases = { "Привет", "Hello", "Bonjour" };

            // Создаем список строк
            List<string> wordsList = new List<string>();

            // Добавляем новые элементы в список
            wordsList.Add("Нормально");
            wordsList.Add("Хорошо");
            wordsList.Add("Ужасно");

            Random rand = new Random();
            string input;
            // Бесконечный цикл, поскольку условие всегда выполняется (равно true)
            while (true) {
                Console.Write("Я: ");
                // Пользователь вводит строку,
                // убираем пробелы с начала и конца строки - Trim(),
                // приводим строку к нижнему регистру - ToLower()
                input = Console.ReadLine().Trim().ToLower();

                Console.Write("П: ");
                // Конструкция switch, в которой сработает код в зависимости
                // от значения input.
                // Если нет совпавших значений, то сработает default:
                switch (input) {
                    case "привет": Console.WriteLine(phrases[rand.Next(0, phrases.Length)]); break;
                    case "как дела?": Console.WriteLine(wordsList[rand.Next(0, wordsList.Count)]); break;
                    case "пока": Console.WriteLine("Всего доброго"); break;
                    default: Console.WriteLine("Я тебя не понимаю"); break;
                }
                // Если input совпадет со строкой "пока", то мы выйдем из цикла (break)
                if (input == "пока") break;
            }
        }

        static void Calc() {
            int a, b;
            char op;
            Console.WriteLine("Введите строку формата \"a + b\"");
            // Разбиваем введенную строку на подстроки, разделенные пробелом
            string[] input = Console.ReadLine().Split(' ');
            while (input.Length > 2) {
                a = int.Parse(input[0]);
                b = int.Parse(input[2]);
                op = char.Parse(input[1]);

                switch (op) {
                    case '+': Console.WriteLine($"= {a + b}"); break;
                    case '-': Console.WriteLine($"= {a - b}"); break;
                    case '*': Console.WriteLine($"= {a * b}"); break;
                    case '/':
                        if (b != 0)
                            Console.WriteLine($"= {a / b}");
                        else
                            Console.WriteLine("На ноль делить нельзя");
                        break;
                }
                input = Console.ReadLine().Split(' ');
            }
        }

        static void Comparison() {
            int a, b;
            var input = Console.ReadLine();
            // int.TryParse(input, out a) проверяет, можно ли
            // строку input преобразовать в число типа int,
            // если можно, то вернется true, а в переменную "a"
            // запишется полученное значение
            while (int.TryParse(input, out a)) {
                input = Console.ReadLine();
                if (int.TryParse(input, out b)) {

                    if (a > b) Console.WriteLine($"{a} > {b} на {a - b}");
                    else if (a < b) Console.WriteLine($"{b} > {a} на {b - a}");
                    else Console.WriteLine("Числа равны");

                    input = Console.ReadLine();
                } else break;

                // Тернарный оператор (условие) ? Если true : Если false;
                //string s = (a > b) ? $"{a} > {b}" : (a < b) ? $"{a} < {b}" : "Числа равны";
            }
        }
    }
}
