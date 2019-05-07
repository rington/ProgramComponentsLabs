using System;

namespace lab1
{
    public class RationalExpressionPrint
    {
        public static void PrintExpression(RationalExpression rationalExpression)
        {
            if (rationalExpression.FirstPolynomial.Equals(rationalExpression.SecondPolynomial))
            {
                Print.PrintPolynomial(rationalExpression.FirstPolynomial);
                Console.Write($" / ");
                Print.PrintPolynomial(rationalExpression.SecondPolynomial);
                Console.Write($" = 1");
            }
            else
            {
                Print.PrintPolynomial(rationalExpression.FirstPolynomial);
                Console.Write($" / ");
                Print.PrintPolynomial(rationalExpression.SecondPolynomial);
            }
        }
    }
}
