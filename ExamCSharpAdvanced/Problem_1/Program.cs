using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Numerics;

namespace Problem_1
{
    class Program
    {


        //return 26system to dec
        public static int ReturnDecDigit(char digit)
        {
            int result = digit - 'a';
            return result;
        }

        public static int ReturnDecDigit2(char digit)
        {
            int result = digit - '0';
            return result;
        }

        //prevryshta 26 systema kym decimal
        public static BigInteger Sys26ToDec(string input)
        {
            BigInteger dec = 0;

            int length = input.Length;

            int startDigit = 0;
            bool sign = false;
            if (input[0] == '-')
            {
                startDigit = 1;
                sign = true;
            }


            int currNum = ReturnDecDigit(input[length - 1]);
            dec += currNum;


            BigInteger pow = 26;

            if (length > 1)
            {
                for (int i = length-2; i >= startDigit; i--)
                {
                    currNum = ReturnDecDigit(input[i]);

                    dec += currNum * pow;
                    pow *= 26;
                }
            }
            

            if (sign)
            {
                dec *= -1;
                //Console.WriteLine(dec);
            }

            return dec;
        }


        //prevryshta daden tip kym decimal
        public static BigInteger TypeToDec(int type, string input)
        {
            BigInteger dec = 0;

            int length = input.Length;

            int startDigit = 0;
            
            bool sign = false;
            if (input[0] == '-')
            {
                startDigit = 1;
                sign = true;
            }

            int currNum = ReturnDecDigit2(input[length-1]);
            
            dec += currNum;

            //Console.WriteLine(dec);

            BigInteger pow = type;

            if (length > 1)
            {
                for (int i = length - 2; i >= startDigit; i--)
                {
                    currNum = ReturnDecDigit2(input[i]);

                    dec += currNum * pow;
                    pow *= 7;


                }
            }
           

            if (sign)
            {
                dec *= -1;
                //Console.WriteLine(dec);
            }

            return dec;
        }

        //Prevryshta decimal vyv daden tip
        public static string DecToType(int type, BigInteger dec)
        {
            bool sign = false;

            if (dec < 0)
            {
                dec *= -1;
                sign = true;

            }

            string typeNum = string.Empty;
            if (dec == 0)
            {
                return "0";
            }
            while (dec > 0)
            {

                BigInteger rest = dec % type;
                string restString = rest.ToString();

                typeNum = restString + typeNum;

                dec = dec / type;
            }

            if (sign)
            {
                typeNum = "-" + typeNum;
            }
            return typeNum;
        }

        static void Main(string[] args)
        {
            //name Task 1: CryptoCS


            //input

            string system26 = Console.ReadLine();

            string operation = Console.ReadLine();

            string system7 = Console.ReadLine();

            //long system9 = long.Parse(Console.ReadLine());



            //logic


            BigInteger firstNum = Sys26ToDec(system26);
            //Console.WriteLine(firstNum);
            BigInteger secondNum = TypeToDec(7, system7);
            //Console.WriteLine(secondNum);
            BigInteger decResult = 0;

            


            if (operation.Equals("+"))
            {
                decResult = firstNum + secondNum;
                
            }
            else
            {
                decResult = firstNum - secondNum;
                
            }


            string result = DecToType(9, decResult);


            //output
            //WriteLine(firstNum);
            //Console.WriteLine(secondNum);

            Console.WriteLine(result);




        }
    }
}
