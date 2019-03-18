using System;

namespace Calculator
{
    class Program
    {
        /// <summary>
        /// Adds two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The sum of the two integers.</returns>
        static int Add (int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The difference of the two integers.</returns>
        static int Subtract (int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The product of the two integers.</returns>
        static int Multiply (int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides two integers.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The quotient of the two integers.</returns>
        static double Divide (int a, int b)
        {
            if (b == 0) throw new DivideByZeroException("You can't divide by Zero!");
            return Math.Round((double)a / b, 2);
        }

        /// <summary>
        /// Retrieves two numbers and an operator from user input.
        /// </summary>
        /// <returns>Two integers and a string containing a mathematical operator.</returns>
        static (int, int, string) GetInput()
        {
            int a=0, b=0;
            string @operator = "", input;
            bool success = false;
            do
            {
                Console.Write("> ");
                input = Console.ReadLine();
                if (input.ToLower() == "exit")
                {
                    success = true;
                    @operator = "exit";
                }
                else { 
                    string[] split = input.Split(' ');
                    if (split.Length == 3)
                    {
                        success = Int32.TryParse(split[0], out a);
                        if (success) success = Int32.TryParse(split[2], out b);
                        if (success) @operator = split[1];
                        else Console.WriteLine("Invalid Input. Please enter a mathematical expression in the form of two numbers separated by an operator.");
                    }
                    else Console.WriteLine("Invalid Input. Make sure that your numbers and your operator are separated by spaces.");
                }
            } while (!success);

            return (a, b, @operator);
        }

        static void Main(string[] args)
        {
            int a, b;
            string @operator;
            bool run = true;

            Console.WriteLine("Welcome to the Calculator App. Input Syntax: a [+, -, *, /] b. Enter 'exit' to quit.");
            
            //Main program loop
            do
            {
                Console.WriteLine();
                (a, b, @operator) = GetInput();
                switch (@operator)
                {
                    case "+":
                        Console.WriteLine(Add(a, b));
                        break;
                    case "-":
                        Console.WriteLine(Subtract(a, b));
                        break;
                    case "*":
                        Console.WriteLine(Multiply(a, b));
                        break;
                    case "/":
                        try
                        {
                            Console.WriteLine(Divide(a, b));
                        } catch (DivideByZeroException err)
                        {
                            Console.WriteLine(err.Message);
                        }
                        break;
                    case "exit":
                        run = false;
                        break;
                    default:
                        Console.WriteLine($"Invalid mathematical operator '{@operator}'. Accepted operators include +, -, *, and /.");
                        break;
                }
            } while (run);
        }
    }
}
