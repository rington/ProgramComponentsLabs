using System;
using System.Reflection;

namespace lab1
{
    public class Polynomial : Attribute
    {
        public int Degree { get; set; }
        public int[] Coefficients { get; set; }
        public string[] NumberSign { get; set; }

        public Polynomial()
        {
            Degree = 0;
            Coefficients = null;
            NumberSign = null;
        }
        public int this[int i]
        {
            get => Coefficients[i];
            set => Coefficients[i] = value;
        }

        /// <summary>
        /// Throws InvalidPolynomialDegreeException if degree is negative or 0
        /// Throws InvalidCoefficientsValuesException if all values in coefficients are 0
        /// </summary>
        /// <param name="degree"></param>
        /// <param name="coefficients"></param>
        public Polynomial(int degree, int[] coefficients)
        {
            Degree = degree;
            if (Degree <= 0)
                throw new InvalidPolynomialDegreeException("\nInvalid polynomial degree!");
            if (coefficients.Length != (degree + 1))
                throw new InvalidCoefficientsSizeException($"\nInvalid size of coefficients array!");
            Coefficients = new int[Degree + 1];
            for (int i = 0; i < Coefficients.Length; i++)
            {
                Coefficients[i] = coefficients[i];
            }
            NumberSign = new string[degree + 1];
            GetNumberSign(this);
            int log = 0;
            foreach (var value in Coefficients)
            {
                if (value == 0)
                    log++;
            }
            if (log == Coefficients.Length)
                throw new InvalidCoefficientsValuesException("\nInvalid coefficients values in polynomial!");
        }
        /// <summary>
        /// Stores the sign of each value in Coefficients
        /// </summary>
        /// <param name="polynomial"></param>
        public void GetNumberSign(Polynomial polynomial)
        {
            for (int i = 0; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] >= 0)
                    NumberSign[i] = "+";
            }
        }
        /// <summary>
        /// Throws NullReferenceException if p1 or p2 is null
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new NullReferenceException();
            Polynomial result = new Polynomial { Degree = Math.Max(p1.Degree, p2.Degree) };
            result.Coefficients = new int[result.Degree + 1];
            result.NumberSign = new string[result.Degree + 1];
            for (int i = 0; i < p1.Coefficients.Length; i++)
            {
                result.Coefficients[result.Coefficients.Length - 1 - i] +=
                    p1.Coefficients[p1.Coefficients.Length - 1 - i];
            }

            for (int i = 0; i < p2.Coefficients.Length; i++)
            {
                result.Coefficients[result.Coefficients.Length - 1 - i] +=
                    p2.Coefficients[p2.Coefficients.Length - 1 - i];
            }
            result.GetNumberSign(result);

            return result;
        }
        /// <summary>
        /// Throws NullReferenceException if p1 or p2 is null
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new NullReferenceException();
            Polynomial result = new Polynomial { Degree = Math.Max(p1.Degree, p2.Degree) };
            result.Coefficients = new int[result.Degree + 1];
            result.NumberSign = new string[result.Degree + 1];

            for (int i = 0; i < p1.Coefficients.Length; i++)
            {
                result.Coefficients[result.Coefficients.Length - 1 - i] += p1.Coefficients[p1.Coefficients.Length - 1 - i];
            }
            for (int i = 0; i < p2.Coefficients.Length; i++)
            {
                result.Coefficients[result.Coefficients.Length - 1 - i] -=
                    p2.Coefficients[p2.Coefficients.Length - 1 - i];
            }
            result.GetNumberSign(result);

            return result;
        }
        /// <summary>
        /// Throws NullReferenceException if p1 or p2 is null
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            if (p1 == null || p2 == null)
                throw new NullReferenceException();
            Polynomial result = new Polynomial { Degree = p1.Degree + p2.Degree };
            result.Coefficients = new int[result.Degree + 1];
            result.NumberSign = new string[result.Degree + 1];
            for (int i = 0; i <= p1.Degree; i++)
            {
                for (int j = 0; j <= p2.Degree; j++)
                {
                    result.Coefficients[i + j] += (p1.Coefficients[i] * p2.Coefficients[j]);
                }
            }

            return result;
        }
        public override bool Equals(object obj)
        {
            // Returns null if the object cannot be cast to a Polynomial type.
            var pol = obj as Polynomial;
            if (pol == null)
                return false;

            return pol.Degree == Degree;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public new virtual void ToString()
        {
            Print.PrintPolynomial(this);
        }

        public static void ReflectionFieldsInfo()
        {
            Type myType = Type.GetType("lab1.Polynomial", false, true);
            Console.WriteLine("\nСвойства класса Polynomial : ");
            if (myType != null)
                foreach (PropertyInfo prop in myType.GetProperties())
                {
                    Console.WriteLine("Name : {0}, type: {1}, public", prop.Name, prop.PropertyType);
                }

            Console.WriteLine();
        }
    }
}
