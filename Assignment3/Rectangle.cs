namespace shapeCreate
{
    public class Rectangle : Shape
    {
        private int length1;
        private int length2;
        private int width1;
        private int width2;

        public Rectangle(int l1, int l2, int w1, int w2)
        {
            length1 = l1;
            length2 = l2;
            width1 = w1;
            width2 = w2;
        }

        public bool Islegal()
        {
            if (length1 < width1)
            {
                return false;
            }

            if (length1 != length2)
            {
                return false;
            }

            if (width1 != width2)
            {
                return false;
            }

            return true;
        }

        public int Getarea()
        {
            return length1 * width1;
        }
    }
}