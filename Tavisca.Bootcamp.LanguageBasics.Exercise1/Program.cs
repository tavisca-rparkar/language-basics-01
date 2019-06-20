using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            // Add your code here.
            float val1, val2, answer;
            string str_val1, str_val2, str_answer, temp1=null, temp2=null;
            string[] split_on_equals = equation.Split('=');
            str_answer = split_on_equals[1];
            string[] split_on_multiply = split_on_equals[0].Split('*');
            str_val1 = split_on_multiply[0];
            str_val2 = split_on_multiply[1];
            if(str_answer.Contains('?'))
            {
                val1 = float.Parse(split_on_multiply[0]);
                val2 = float.Parse(split_on_multiply[1]);
                answer = val1 * val2;
                temp1 = answer.ToString();
                temp2 = str_answer;
            }
            else if(str_val1.Contains('?'))
            {
                val2 = float.Parse(split_on_multiply[1]);
                answer = float.Parse(split_on_equals[1]);
                val1 = answer / val2;
                temp1 = val1.ToString();
                temp2 = str_val1;
            }
            else if(str_val2.Contains('?'))
            {
                val1 = float.Parse(split_on_multiply[0]);
                answer = float.Parse(split_on_equals[1]);
                val2 = answer / val1;
                temp1 = val2.ToString();
                temp2 = str_val2;
            }

            if(temp1.Length == temp2.Length)
            {
                for (int i = 0; i < temp1.Length; i++)
                {
                    if (temp1[i] != temp2[i])
                    {
                        return int.Parse(temp1[i].ToString());
                    }
                }
            }
            else
            {
                return -1;
            }
            throw new NotImplementedException();
        }
    }
}
