using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        public static int FindDigit(string equation)
        {
            string[] splitOnEquals = equation.Split('=');
            string stringAnswer = splitOnEquals[1];
            string[] splitOnMultiply = splitOnEquals[0].Split('*');
            string stringFirstOperand = splitOnMultiply[0];
            string stringSecondOperand = splitOnMultiply[1];

            if (stringAnswer.Contains('?'))
            {
                return CalculateCorrectAnswer(stringFirstOperand, stringSecondOperand, stringAnswer);
            }
            else if (stringFirstOperand.Contains('?'))
            {
                return CalculateCorrectFirstOperand(stringFirstOperand, stringSecondOperand, stringAnswer);
            }
            else
            {
                return CalculateCorrectSecondOperand(stringFirstOperand, stringSecondOperand, stringAnswer);
            }
        }

        private static int CalculateCorrectAnswer(string stringFirstOperand, string stringSecondOperand, string stringAnswer)
        {
            float firstOperand, secondOperand, answer;

            firstOperand = float.Parse(stringFirstOperand);
            secondOperand = float.Parse(stringSecondOperand);
            answer = firstOperand * secondOperand;
            return FindMissingDigit(answer.ToString(), stringAnswer);
        }

        private static int CalculateCorrectFirstOperand(string stringFirstOperand, string stringSecondOperand, string stringAnswer)
        {
            float firstOperand, secondOperand, answer;

            secondOperand = float.Parse(stringSecondOperand);
            answer = float.Parse(stringAnswer);
            firstOperand = answer / secondOperand;
            return FindMissingDigit(firstOperand.ToString(), stringFirstOperand);
        }

        private static int CalculateCorrectSecondOperand(string stringFirstOperand, string stringSecondOperand, string stringAnswer)
        {
            float firstOperand, secondOperand, answer;

            firstOperand = float.Parse(stringFirstOperand);
            answer = float.Parse(stringAnswer);
            secondOperand = answer / firstOperand;
            return FindMissingDigit(secondOperand.ToString(), stringSecondOperand);
        }

        private static int FindMissingDigit(string correctValue, string valueWithQuestionMark)
        {
            if (correctValue.Length == valueWithQuestionMark.Length)
            {
                return int.Parse(correctValue[valueWithQuestionMark.IndexOf('?')].ToString());
            }
            else
            {
                return -1;
            }
        }
    }
}
