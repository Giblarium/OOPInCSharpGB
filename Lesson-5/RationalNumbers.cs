using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    internal class RationalNumbers

    {
        private int numerator; //числитель
        private int denominator; //знаменатель

        public RationalNumbers()
        {
        }

        public RationalNumbers(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }

        public int Numerator { get => numerator; set => numerator = value; }
        public int Denominator { get => denominator; set => denominator = value; }

        #region Преобразование типов
        public static explicit operator float(RationalNumbers rational)
        {
            float num = rational.Numerator;
            float denom = rational.Denominator;

            return num / denom;
        }

        #endregion

        #region Операторы
        /// <summary>
        /// Сравнение дробей Больше или равно
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator >=(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);
            if (fraction1.Numerator >= fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сравнение дробей Меньше или равно
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator <=(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);
            if (fraction1.Numerator <= fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сравнение дробей Больше
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator >(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);
            if (fraction1.Numerator > fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сравнение дробей Меньше
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator <(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);
            if (fraction1.Numerator < fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Равенство двух дробей
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator ==(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);

            if (fraction1.Numerator == fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Неравенство двух дробей
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static bool operator !=(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers fraction1, fraction2;
            FractionCommonDenominator(rationalNumbers1, rationalNumbers2, out fraction1, out fraction2);

            if (fraction1.Numerator != fraction2.Numerator)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сложение дробей
        /// </summary>
        /// <param name="rationalNumbers1">Первая дробь</param>
        /// <param name="rationalNumbers2">Вторая дробь</param>
        /// <returns></returns>
        public static RationalNumbers operator +(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            int leastCommonMultiple = GetLeastCommonMultiple(rationalNumbers1.Denominator, rationalNumbers2.Denominator);
            int additionalMultiplier1 = leastCommonMultiple / rationalNumbers1.Denominator;
            int additionalMultiplier2 = leastCommonMultiple / rationalNumbers2.Denominator;

            RationalNumbers result = new RationalNumbers(rationalNumbers1.Numerator * additionalMultiplier1 + rationalNumbers2.Numerator * additionalMultiplier2, leastCommonMultiple);
            result = FractionReduction(result);
            return result;
        }

        /// <summary>
        /// Вычитание дробей
        /// </summary>
        /// <param name="rationalNumbers1">Первая дробь</param>
        /// <param name="rationalNumbers2">Вторая дробь</param>
        /// <returns></returns>
        public static RationalNumbers operator -(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            int leastCommonMultiple = GetLeastCommonMultiple(rationalNumbers1.Denominator, rationalNumbers2.Denominator);
            int additionalMultiplier1 = leastCommonMultiple / rationalNumbers1.Denominator;
            int additionalMultiplier2 = leastCommonMultiple / rationalNumbers2.Denominator;

            RationalNumbers result = new RationalNumbers(rationalNumbers1.Numerator * additionalMultiplier1 - rationalNumbers2.Numerator * additionalMultiplier2, leastCommonMultiple);
            result = FractionReduction(result);
            return result;
        }

        /// <summary>
        /// Добавление целой дроби
        /// </summary>
        /// <param name="rationalNumbers"></param>
        /// <returns></returns>
        public static RationalNumbers operator ++(RationalNumbers rationalNumbers)
        {
            return new RationalNumbers(rationalNumbers.Numerator + rationalNumbers.Denominator, rationalNumbers.Denominator);
        }

        /// <summary>
        /// Вычитание целой дроби
        /// </summary>
        /// <param name="rationalNumbers"></param>
        /// <returns></returns>
        public static RationalNumbers operator --(RationalNumbers rationalNumbers)
        {
            return new RationalNumbers(rationalNumbers.Numerator - rationalNumbers.Denominator, rationalNumbers.Denominator);
        }
        
        /// <summary>
        /// Произведение дробей
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static RationalNumbers operator *(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers result = new RationalNumbers(rationalNumbers1.Numerator * rationalNumbers2.Numerator, rationalNumbers1.Denominator * rationalNumbers2.Denominator);
            result = FractionReduction(result);
            return result;
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <returns></returns>
        public static RationalNumbers operator /(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2)
        {
            RationalNumbers result = rationalNumbers1 * new RationalNumbers(rationalNumbers2.Denominator, rationalNumbers2.Numerator);
            
            return FractionReduction(result);
        }


        #endregion

        #region Методы
        /// <summary>
        /// Приведение дробей к общему знаменателю
        /// </summary>
        /// <param name="rationalNumbers1"></param>
        /// <param name="rationalNumbers2"></param>
        /// <param name="fraction1"></param>
        /// <param name="fraction2"></param>
        private static void FractionCommonDenominator(RationalNumbers rationalNumbers1, RationalNumbers rationalNumbers2, out RationalNumbers fraction1, out RationalNumbers fraction2)
        {
            int leastCommonMultiple = GetLeastCommonMultiple(rationalNumbers1.Denominator, rationalNumbers2.Denominator);
            int additionalMultiplier1 = leastCommonMultiple / rationalNumbers1.Denominator;
            int additionalMultiplier2 = leastCommonMultiple / rationalNumbers2.Denominator;

            fraction1 = new RationalNumbers(rationalNumbers1.Numerator * additionalMultiplier1, leastCommonMultiple);
            fraction2 = new RationalNumbers(rationalNumbers2.Numerator * additionalMultiplier2, leastCommonMultiple);
        }

        /// <summary>
        /// Сокращение дроби на наибольший общий делитель
        /// </summary>
        /// <param name="fractionReduction">Дробь для сокращения</param>
        /// <returns></returns>
        private static RationalNumbers FractionReduction(RationalNumbers fractionReduction)
        {
            int greatestCommonDivisor = GetGreatestCommonDivisor(fractionReduction.Numerator, fractionReduction.Denominator);
            if (greatestCommonDivisor == 1)
            {
                return fractionReduction;
            }
            else
            {
                fractionReduction.Numerator = (fractionReduction.Numerator / greatestCommonDivisor);
                fractionReduction.Denominator = fractionReduction.Denominator / greatestCommonDivisor;
                return fractionReduction;
            }
        }

        /// <summary>
        /// Расчет наименьшего общего кратного
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns></returns>
        private static int GetLeastCommonMultiple(int a, int b)
        {
            int greatestCommonDivisor = GetGreatestCommonDivisor(a, b);
            return a * b / greatestCommonDivisor;

        }
        
        /// <summary>
        /// Расчет наибольшего общего делителя
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <returns></returns>
        private static int GetGreatestCommonDivisor(int a, int b)
        {
            int max = a;
            int min = b;
            if (max == min)
            {
                return a;
            }
            else if (min > max)
            {
                max = b;
                min = a;
            }
            int c = max % min;
            a = min;
            b = c;
            if (c != 0)
            {
                return GetGreatestCommonDivisor(a, b);
            }
            return min;
        }
        public override string ToString()
        {
            return Numerator.ToString() + " / " + Denominator.ToString();
        }
        #endregion
    }
}


/* 1. Создать класс рациональных чисел. В классе два поля – числитель и знаменатель. Предусмотреть конструктор. 
 * Определить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --. 
 * Переопределить метод ToString() для вывода дроби. 
 * Определить операторы преобразования типов между типом дробь, float, int. 
 * Определить операторы *, /, %.*/