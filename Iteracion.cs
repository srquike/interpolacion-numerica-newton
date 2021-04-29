using System;
using System.Collections.Generic;
using System.Text;

namespace InterpolacionNumericaNewton
{
    public class Iteracion
    {
        private double error;

        public int I { get; set; }
        public double Xi { get; set; }
        public double FPXi { get; set; }
        public double FPPXi { get; set; }
        public double XiMa1 { get; set; }
        public double Error { get => Math.Round(error, 3); set => error = value; }
    }
}
