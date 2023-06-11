using System;

namespace shapeCreate
{
    public class Triangle : Shape
    {
        private int firstSide;
        private int secondSide;
        private int thirdSide;

        public Triangle(int f, int s, int t)
        {
            f = firstSide;
            s = secondSide;
            t = thirdSide;
        }

        public bool Islegal()
        {
            if (firstSide + secondSide <= thirdSide)
            {
                return false;
            }

            if (Math.Abs(firstSide - secondSide) >= thirdSide)
            {
                return false;
            }

            return true;

        }

        public int Getarea()
        {
            double s = (firstSide + secondSide + thirdSide) / 2;
            double area = Math.Sqrt(s * (s - firstSide) * (s - secondSide) * (s - thirdSide));
            return (int)area;
        }
    }
}