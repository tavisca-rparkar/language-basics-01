using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        private static float value1, value2, answer;
        private static string temp1 = null, temp2 = null;

        public static int FindDigit(string equation)
        {
            string[] splitOnEquals = equation.Split('=');
            string stringAnswer = splitOnEquals[1];
            string[] splitOnMultiply = splitOnEquals[0].Split('*');
            string stringValue1 = splitOnMultiply[0];
            string stringValue2 = splitOnMultiply[1];

            if (stringAnswer.Contains('?'))
            {
                CalculateCorrectAnswer(stringValue1, stringValue2, stringAnswer);
            }
            else if (stringValue1.Contains('?'))
            {
                CalculateCorrectValue1(stringValue1, stringValue2, stringAnswer);
            }
            else if (stringValue2.Contains('?'))
            {
                CalculateCorrectValue2(stringValue1, stringValue2, stringAnswer);
            }

            return FindMissingDigit();
        }

        private static void CalculateCorrectAnswer(string stringValue1, string stringValue2, string stringAnswer)
        {
            value1 = float.Parse(stringValue1);
            value2 = float.Parse(stringValue2);
            answer = value1 * value2;
            temp1 = answer.ToString();
            temp2 = stringAnswer;
        }

        private static void CalculateCorrectValue1(string stringValue1, string stringValue2, string stringAnswer)
        {
            value2 = float.Parse(stringValue2);
            answer = float.Parse(stringAnswer);
            value1 = answer / value2;
            temp1 = value1.ToString();
            temp2 = stringValue1;
        }

        private static void CalculateCorrectValue2(string stringValue1, string stringValue2, string stringAnswer)
        {
            value1 = float.Parse(stringValue1);
            answer = float.Parse(stringAnswer);
            value2 = answer / value1;
            temp1 = value2.ToString();
            temp2 = stringValue2;
        }

        private static int FindMissingDigit()
        {
            if (temp1.Length == temp2.Length)
            {
                return int.Parse(temp1[temp2.IndexOf('?')].ToString());
            }
            else
            {
                return -1;
            }
        }
    }
}
