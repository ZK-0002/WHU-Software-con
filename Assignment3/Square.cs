namespace shapeCreate
{
    public class Square : Rectangle
    {
        private int side1;
        private int side2;
        private int side3;
        private int side4;

        public Square(int l1, int l2, int w1, int w2) : base(l1, l2, w1, w2)
        {
            side1 = l1;
            side2 = l2;
            side3 = w1;
            side4 = w2;
        }

        public bool Islegal()
        {
            if (side1 != side2)
            {
                return false;
            }

            if (side2 != side3)
            {
                return false;
            }

            if (side3 != side4)
            {
                return false;
            }

            return true;
        }

        public int Getarea()
        {
            return base.Getarea();
        }
    }
}