using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Classes
{
    class SimpleMate //실질적인 계산담당, 설계단계에서 굳이 각매소드를 객체로 생성하지 않게 구현 하겠다 => static
    {
        public static double Add(double n1, double n2)
        {
            return n1 + n2;
        }
        public static double Sub(double n1, double n2)
        {
            return n1 - n2;
        }
        public static double Mul(double n1, double n2)
        {
            return n1 * n2;
        }
        public static double Div(double n1, double n2)
        {
            return n1 / n2;
        }
    }
}
