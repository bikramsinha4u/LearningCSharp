namespace LearningCSharp
{
    class Calculator
    {
        public int number, number1, number2;

        public Calculator(int n)
        {
            number = n;
        }

        public Calculator(int num1, int num2)
        {
            number1 = num1;
            number2 = num2;
        }

        // Unary operator overload
        public static Calculator operator -(Calculator c1)
        {
            c1.number1 = -c1.number1;
            c1.number2 = -c1.number2;
            return c1;
        }

        // Binary operator overload
        public static Calculator operator +(Calculator Calc1,
                                         Calculator Calc2)
        {
            Calculator Calc3 = new Calculator(0);
            Calc3.number = Calc2.number + Calc1.number;
            return Calc3;
        }
    }
}

/*Call to unary operator overload
 * Calculator calc = new Calculator(15, -25);
 * calc = -calc;
 * 
 * Call to binary operator overload
 * Calculator num1 = new Calculator(200);
 * Calculator num2 = new Calculator(40);
 * Calculator num3 = new Calculator();
 * num3 = num1 + num2;
 */
