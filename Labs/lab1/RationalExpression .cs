using System;
using System.Reflection;

namespace lab1
{
    public class RationalExpression : Polynomial
    {
        public Polynomial FirstPolynomial { get; }
        public Polynomial SecondPolynomial { get; }

        public RationalExpression()
        {
        }

        public RationalExpression(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            FirstPolynomial = firstPolynomial;
            SecondPolynomial = secondPolynomial;
            if(firstPolynomial == null || secondPolynomial == null)
                throw new NullReferenceException();
        }

        public override void ToString()
        {
            RationalExpressionPrint.PrintExpression(this);
        }
        public new static void ReflectionFieldsInfo()
        {
            Type myType = Type.GetType("lab1.RationalExpression", false, true);
            Console.WriteLine("\nСвойства класса RationalExpression :");
            if (myType != null)
                foreach (PropertyInfo prop in myType.GetProperties())
                {
                    Console.WriteLine("Name : {0}, type: {1}, public", prop.Name, prop.PropertyType);
                }

            Console.WriteLine();
        }
    }
}
