using System;
using lab1;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var pol1 = new Polynomial(6, new[] {-1, 2, 5, 0, -4, 7, 5});
            var pol2 = new Polynomial(5, new[] {2, 5, 8, 4, -2, 0});
            var pol3 = new Polynomial(5, new[] {2, 5, 8, 4, -2, 0});

            var rationalExpression1 = new RationalExpression(pol1, pol2);
            var rationalExpression2 = new RationalExpression(pol2, pol3);
            Console.Write($"First rational expression is :\t");
            RationalExpressionPrint.PrintExpression(rationalExpression1);
            Console.Write($"\nThe result of ToString method working:\t");
            rationalExpression1.ToString();
            Console.WriteLine();


            Console.Write($"\nSecond rational expression is :\t");
            RationalExpressionPrint.PrintExpression(rationalExpression2);
            Console.Write($"\nThe result of ToString method working:\t");
            rationalExpression2.ToString();
            Console.WriteLine();

            Polynomial.ReflectionFieldsInfo();
            RationalExpression.ReflectionFieldsInfo();

            Console.ReadKey();
        }
    }
}

