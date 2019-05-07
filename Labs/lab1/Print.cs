using System;

namespace lab1
{
    public class Print
    {
        public static void PrintPolynomial(Polynomial polynomial)
        {
            for (int i = 0; i < polynomial.Coefficients.Length; i++)
            {
                if (polynomial.Coefficients[i] == 0)
                {
                    continue;
                }

                if (polynomial.Coefficients.Length - i - 1 == 0)
                {
                    Console.Write($"{polynomial.NumberSign[i]}{polynomial.Coefficients[i]} ");
                    break;
                }

                if (polynomial.Coefficients.Length - i - 1 == 1)
                {
                    Console.Write($"{polynomial.NumberSign[i]}{polynomial.Coefficients[i]}x ");
                    continue;
                }

                Console.Write(
                    $"{polynomial.NumberSign[i]}{polynomial.Coefficients[i]}x^{polynomial.Coefficients.Length - i - 1} ");
            }
        }
    }
}
