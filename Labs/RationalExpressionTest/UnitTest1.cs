using System;
using lab1;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private Polynomial _pol1, _pol2, _pol3;
        [SetUp]
        public void Setup()
        {
            _pol1 = new Polynomial(3, new []{ 1, 2, -5, 9 });
            _pol2 = _pol1;
            _pol3 = null;
        }

        [Test]
        public void PolynomialConstructorTestShouldThrowInvalidPolynomialDegreeException()
        {
            //Assert
            Assert.Throws<InvalidPolynomialDegreeException>(() => new Polynomial(-6, new[] {-1, 2, 5, 0, -4, 7, 5}));
        }
        [Test]
        public void PolynomialConstructorTestShouldThrowInvalidCoefficientsSizeException()
        {
            //Assert
            Assert.Throws<InvalidCoefficientsSizeException>(() => new Polynomial(3, new[] { -1, 2, 5, 0, -4 }));
        }

        [Test]
        public void PolynomialConstructorTestShouldThrowInvalidCoefficientsValuesException()
        {
            //Assert
            Assert.Throws<InvalidCoefficientsValuesException>(() => new Polynomial(3, new[] { 0, 0, 0, 0 }));
        }

        [Test]
        public void GetNumberSignOfPolynomialReturnSignOfEachCoefficient()
        {
            //Arrange
            var expected ="+";

            //Act
            _pol1.GetNumberSign(_pol1);
            
            //Assert
            Assert.AreEqual(expected, _pol1.NumberSign[0]);
        }

        [Test]
        public void EqualsPolynomialTesting()
        {
            //Assert
            Assert.AreEqual(true,_pol1.Equals(_pol2));
        }

        [Test]
        public void EqualsRationalExpressionTesting()
        {
            //Assert
            Assert.Throws<NullReferenceException>(() => new RationalExpression(_pol1, _pol3));
        }
    }
}