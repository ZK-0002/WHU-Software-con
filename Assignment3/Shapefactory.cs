using System;
using System.Diagnostics;
using System.IO;

namespace shapeCreate
{
    public class Shapefactory
    {
        private static Triangle Createtriangle(int f, int s, int t)
        {
            Triangle tri = new Triangle(f, s, t);
            return tri;
        }
        
        private static Square Createsquare(int side)
        {
            Square s = new Square(side, side, side, side);
            return s;
        }
        private static Rectangle createreRectangle(int l, int w)
        {
            Rectangle r = new Rectangle(l, l, w, w);
            return r;
        }
        
        
        public static Shape Createshape(Shapetype shape, params int []list)
        {
            Shape s;
            switch (shape)
            {
                case Shapetype.triangle:
                    if (list.Length != 3)
                    {
                        throw new IOException("The length of array should be 3");
                    }
                    s = Createtriangle(list[0], list[1], list[2]);
                    break;
                case Shapetype.rectangle:
                    if (list.Length != 2)
                    {
                        throw new IOException("The length of array should be 2");
                    }
                    s = createreRectangle(list[0], list[1]);
                    break;
                case Shapetype.square:
                    if (list.Length != 1)
                    {
                        throw new IOException("The length of array should be 1");
                    }
                    s = Createsquare(list[0]);
                    break;
                default:
                    throw new InvalidDataException("The shape should be 'triangle', 'rectangle' or 'square'");
            }

            if (!s.Islegal())
            {
                throw new InvalidDataException("The shape created is invalid");
            }

            return s;
        }
    }
}