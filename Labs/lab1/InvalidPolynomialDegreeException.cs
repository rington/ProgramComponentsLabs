using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class InvalidPolynomialDegreeException : Exception
    {
        public InvalidPolynomialDegreeException(string message) : base(message) { }
    }
    public class InvalidCoefficientsValuesException : Exception
    {
        public InvalidCoefficientsValuesException(string message) : base(message) { }
    }
    public class InvalidCoefficientsSizeException : Exception
    {
        public InvalidCoefficientsSizeException(string message) : base(message) { }
    }
}
