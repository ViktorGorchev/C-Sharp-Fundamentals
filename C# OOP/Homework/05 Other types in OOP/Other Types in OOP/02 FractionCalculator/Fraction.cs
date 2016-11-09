using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _02_FractionCalculator
{
    class Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction()
        {
            
        }
        
        public Fraction(long numerator, long denominator) : this() 
            
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }
        
        public long Numerator
        {
            get { return this.numerator; }
            set
            {this.numerator = value;}
        }

        public long Denominator
        {
            get { return this.denominator; }
            set
            {
                if (value == 0)
                {
                    throw new DivideByZeroException("Denominator can't be 0!");
                }
                this.denominator = value;
            }
        }
        public static Fraction operator +(Fraction a, Fraction b)
        {
            BigInteger numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            BigInteger denominator = a.Denominator * b.Denominator;

            if (numerator > long.MaxValue || numerator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("numerator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            if (denominator > long.MaxValue || denominator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("denominator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            return new Fraction((long)numerator, (long)denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            BigInteger numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            BigInteger denominator = a.Denominator * b.Denominator;

            if (numerator > long.MaxValue || numerator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("numerator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            if (denominator > long.MaxValue || denominator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("denominator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            return new Fraction((long)numerator, (long)denominator);
        }

        public override string ToString()
        {
            return string.Format("{0}", (decimal)this.Numerator / this.Denominator);
        }
    }
}
    

