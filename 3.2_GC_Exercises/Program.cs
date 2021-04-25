using System;
using System.Text;

namespace _3._2_GC_Exercises
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] exercises = { 37, 38 };
            string exerciseString = " ";
            foreach (int exercise in exercises)
            {
                exerciseString += exercise + " / ";
            }
            exerciseString = exerciseString.Remove(exerciseString.Length - 2);

            bool tryAgain = true;
            while (tryAgain)
            {
                tryAgain = false;
                switch (GetInt($"Which exercise would you like to run ({exerciseString})? "))
                {
                    case 37:
                        SumInputs();
                        tryAgain = Continue();
                        break;
                    case 38:
                        AverageInputs();
                        tryAgain = Continue();
                        break;
                    default:
                        Console.Write("That's not a valid input. Try again. ");
                        tryAgain = true;
                        break;
                }
            }
        }

        public static void SumInputs()
        {
            double[] inputArray = GetArray("Enter a number: ", 5);
            StringBuilder outputString = new StringBuilder();
            foreach(double addend in inputArray)
            {
                outputString.Append(addend + " + ");
            }
            outputString.Remove(outputString.Length - 2, 2).Append("= " + SumArray(inputArray));
            Console.WriteLine(outputString);
        }

        public static void AverageInputs()
        {
            double[] inputArray = GetArray("Enter a number: ", 5);
            StringBuilder outputString = new StringBuilder("(");
            foreach(double element in inputArray)
            {
                outputString.Append(element + " + ");
            }
            double avg = SumArray(inputArray) / inputArray.Length;
            outputString.Remove(outputString.Length - 3, 3).Append($")/{inputArray.Length} = {avg}");
            Console.WriteLine(outputString);

        }

        public static double SumArray(double[] inputArray)
        {
            double sum = 0;
            foreach(double addend in inputArray)
            {
                sum += addend;
            }
            return sum;
        }

        public static double[] GetArray(string message, int size)
        {
            double[] inputArray = new double[size];
            for(int i = 0; i<size; i++)
            {
                inputArray[i] = GetDouble(message);
            }
            return inputArray;
        }

        public static double GetDouble(string message)
        {
            double returnVal;
            while (!double.TryParse(PromptUser(message), out returnVal))
            {
                Console.Write("Not a valid input. ");
            }
            return returnVal;
        }

        //IO methods required for Main switch to function
        public static bool Continue()
        {
            return (GetYN("Would you like to continue? (y/n) ") == "y");
        }

        public static string GetYN(string message)
        {
            while (true)
            {
                string input = PromptUser(message).ToLower();
                if (input == "y" || input == "yes" || input == "n" || input == "no")
                {
                    return input.Substring(0, 1);
                }
            }
        }

        public static string PromptUser(string message)
        {
            Console.Write(message);
            return Console.ReadLine();
        }

        public static int GetInt(string message)
        {
            return GetInt(message, "Not a valid input. ", int.MinValue, int.MaxValue);
        }

        public static int GetInt(string message, string errorMessage, int lowerBound, int upperBound)
        {
            int returnVal;
            while (!int.TryParse(PromptUser(message), out returnVal) || returnVal >= upperBound || returnVal < lowerBound)
            {
                Console.Write(errorMessage);
            }
            return returnVal;
        }
    }
}
