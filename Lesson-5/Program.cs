using System;

namespace Lesson_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            RationalNumbers rationalNumbers = new RationalNumbers(12, 4);
            RationalNumbers rationalNumbers1 = new RationalNumbers(5, 9);

            RationalNumbers sum = rationalNumbers + rationalNumbers1;
            RationalNumbers diff = rationalNumbers - rationalNumbers1;
            RationalNumbers mutple = rationalNumbers * rationalNumbers1;
            RationalNumbers degree = rationalNumbers / rationalNumbers1;
            RationalNumbers oneMore = ++rationalNumbers;
            RationalNumbers oneLess = --rationalNumbers;

            Console.WriteLine(sum.ToString());
            Console.WriteLine(diff.ToString());
            Console.WriteLine(oneMore.ToString());
            Console.WriteLine(oneLess.ToString());
            Console.WriteLine(rationalNumbers == rationalNumbers1);
            Console.WriteLine(rationalNumbers != rationalNumbers1);
            Console.WriteLine(rationalNumbers > rationalNumbers1);
            Console.WriteLine(rationalNumbers < rationalNumbers1);
            Console.WriteLine(mutple.ToString());
            Console.WriteLine(degree.ToString());
            Console.WriteLine((float)rationalNumbers);
            Console.WriteLine((float)rationalNumbers1);

        }
    }
}
/*
 1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель. Предусмотреть конструктор. Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. Переопределить метод ToString() для вывода дроби. Определить операторы преобразования типов между типом дробь,float, int. Определить операторы *, /, %.
2. * На перегрузку операторов. Описать класс комплексных чисел. Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел. Переопределить метод ToString() для комплексного числа. Протестировать на простом примере.
*/