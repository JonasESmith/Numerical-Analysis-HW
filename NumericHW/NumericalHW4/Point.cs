namespace NumericalHW4
{
    class Point
    {
        private double x_Value;
        private double y_Value;

        public Point(double x_Input, double y_Input)
        {
            x_Value = x_Input;
            y_Value = y_Input;
        }

        public double X
        {
            get
            {
                return x_Value;
            }
        }

        public double Y
        {
            get
            {
                return y_Value;
            }
        }

    }
}
