using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancodeTDDLab1
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
                return 0;

            var delimiters = new List<char> { ',', '\n' };

            string numberString = numbers;

            if (numberString.StartsWith("//"))
            {
                var input = numberString.Split('\n');
                var newmiter = input.First().Trim('/');

               
                

                numberString = String.Join('\n', input.Skip(1));
                delimiters.Add(Convert.ToChar(newmiter));
            }


            var numberList = numberString.Split(delimiters.ToArray()).Select(str => int.Parse(str));

            var negatives = numberList.Where(n => n < 0);

            if (negatives.Any())
            {
                string Negativstring = String.Join(',', negatives.Select(n => n.ToString()));

                throw new Exception($"Negatives not allowed {Negativstring}");
            }

            var result = numberList.Where(n => n <= 1000).Sum();


            


            return result;
        }
    }
}