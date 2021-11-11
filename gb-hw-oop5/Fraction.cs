using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gb_hw_oop5
{
    public class Fraction
    {
        public int Up { get; set; }
        public int Down { get; set; }
        private bool isNull = false;

        public Fraction(int up, int down)
        {
            if (down == 0)
            {
                throw new ArgumentException();
            }
            if (up == 0) isNull = true;
            Up = up;
            Down = down;

        }

        public  static bool operator ==(Fraction first, Fraction second)
        {
            return first.Up / second.Up == first.Down/second.Down;
        }

        public static bool operator !=(Fraction first, Fraction second)
        {
            return first.Up / second.Up != first.Down / second.Down;
        }

        public static Fraction operator *(Fraction first, int second)
        {
            return new Fraction(first.Up * second, first.Down * second);
        }

        public static Fraction operator +(Fraction first, Fraction second)
        {
            if (first.Down!=second.Down)
            {
                CommonDenominator(ref first, ref second);
            }
            return new Fraction(first.Up + second.Up, first.Down);
        }

        public static Fraction operator -(Fraction first, Fraction second)
        {
            CommonDenominator(ref first, ref second);
            return new Fraction(first.Up - second.Up, first.Down);
        }

        public static Fraction operator ++(Fraction first)
        {
            var second = new Fraction(first.Down, first.Down);

            return new Fraction(first.Up + second.Up, first.Down);
        }

        public static Fraction operator --(Fraction first)
        {
            var second = new Fraction(first.Down, first.Down);

            return new Fraction(first.Up - second.Up, first.Down);
        }

        public static bool operator <(Fraction first, Fraction second)
        {
            CommonDenominator(ref first, ref second);
            return first.Up < second.Up;
        }

        private static void CommonDenominator(ref Fraction first, ref Fraction second)
        {
            if(first.Down!=second.Down)
            {
                int buffer = first.Down;
                first *= second.Down;
                second *= buffer;
            }

        }

        public static bool operator >(Fraction first, Fraction second)
        {
            CommonDenominator(ref first, ref second);
            return first.Up > second.Up;
        }

        public static bool operator >=(Fraction first, Fraction second)
        {
            CommonDenominator(ref first, ref second);
            return first.Up >= second.Up;
        }
        public static bool operator <=(Fraction first, Fraction second)
        {
            CommonDenominator(ref first, ref second);
            return first.Up <= second.Up;
        }

        public static implicit operator float(Fraction fraction)
        {
            return (float)fraction.Up /fraction.Down;
        }
        public static explicit operator int(Fraction fraction)
        {
            return fraction.Up / fraction.Down;
        }

        public static Fraction operator *(Fraction first, Fraction second)
        {
            return new Fraction(first.Up * second.Up, first.Down * second.Down);
        }

        public static Fraction operator /(Fraction first, Fraction second)
        {
            return new Fraction(first.Up * second.Down , first.Down * second.Up);
        }

        public static Fraction operator %(Fraction first, Fraction second)
        {
            first.Up = Math.Abs(first.Up);
            second.Up = Math.Abs(second.Up);
            first.Down = Math.Abs(first.Down);
            second.Down = Math.Abs(second.Down);

            var divider = (int)(first / second);
            var incompliteResult = second * divider;
            if (incompliteResult==first)
            {
                return new Fraction(0, first.Down);
            } 
            else
            {
                return first - incompliteResult;
            }
           
        }


        public override bool Equals(object obj)
        {
            return this == (Fraction)obj;
        }

        public override int GetHashCode()
        {
            return Up.GetHashCode() * 31 + Down.GetHashCode();
        }

        public override string ToString()
        {
            if (!isNull)
            {
                return $"{Up}/{Down}";
            } else
            {
                return 0.ToString();
            }
            
        }

    }
}
