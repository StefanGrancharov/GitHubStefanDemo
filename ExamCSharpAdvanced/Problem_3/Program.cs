using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_3
{
    class Program
    {

        //printira karata
        public static void PrintMap(int[,] arr)
        {
            int rows = arr.GetLength(0);
            int cols = arr.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(arr[i,j] + " ");
                }
                Console.WriteLine();
            }
        }


        //return direction
        public static int[] ReturnDirection(char ch)
        {
            int[] direction = new int[2];

            switch (ch)
            {
                case 'T':
                    direction[0] = -1;
                    direction[1] = 0;
                    break;
                case 'R':
                    direction[0] = 0;
                    direction[1] = 1;
                    break;
                case 'B':
                    direction[0] = 1;
                    direction[1] = 0;
                    break;
                case 'L':
                    direction[0] = 0;
                    direction[1] = -1;
                    break;
                default:
                    break;
            }
            return direction;
        }

        static void Main(string[] args)
        {

            //name Task 3: Animal planet

            


            //input

            int baseColumnsCount = int.Parse(Console.ReadLine());

            int rows = int.Parse(Console.ReadLine());


            //initial coordinates of the units
            string[] porStart = Console.ReadLine().Split();
            string[] rabStart = Console.ReadLine().Split();

         
            int[] por = new int[] { int.Parse(porStart[0]), int.Parse(porStart[1]) };
            int[] rab = new int[] { int.Parse(rabStart[0]), int.Parse(rabStart[1]) };

            //Console.WriteLine(rab[0] +" " + rab[1]);
            
            //logic


            //coubters
            int rabCount = 0;
            int porCount = 0;


            //generate Map
            
            int mid = rows / 2;

            int cols = 0;

            cols = mid * baseColumnsCount;

            int[,] map = new int[rows,cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = -1;
                }
                
            }

            int row = 0;

            while (row < mid)
            {
                int startNum = row + 1;

                int col = 0;

                int length = (row + 1) * baseColumnsCount;

                while(col < length)
                {
                    map[row, col] = startNum * (col + 1);

                    col++;
                }
                row++;
            }

            while (row < rows)
            {
                int startNum = row + 1;

                int col = 0;

                int length = (rows - row) * baseColumnsCount;

                while (col < length)
                {
                    map[row, col] = startNum * (col + 1);

                    col++;
                }
                row++;
            }


            //PrintMap(map);

           

            //collecting points

            //startCollection

            

            rabCount += map[rab[0], rab[1]];
            map[rab[0], rab[1]] = 0;

            porCount += map[por[0], por[1]];
            map[por[0], por[1]] = 0;

            string input="";

            int[] direction = new int[2];

            //Console.WriteLine(porCount);
            //Console.WriteLine(rabCount);

            ///*

           do
           {

               input = Console.ReadLine();


               if (input.Equals("END"))
               {
                   break;
               }


               //input commands
               string[] commands = input.Split();       
               string type = commands[0];
               string direct = commands[1];
               int steps = int.Parse(commands[2]);

               //make direction
               direction = ReturnDirection(direct[0]);

               if (type.Equals("R"))
               {
                   int step = 0;

                   while (step < steps)
                   {
                       if (rab[0] + direction[0] == por[0] && rab[1] + direction[1]== por[1])
                       {
                           break;
                       }

                       rab[0] += direction[0];
                       rab[1] += direction[1];

                       if (rab[0] > rows - 1)
                       {
                           rab[0] = 0;
                       }
                       else if (rab[1] > cols - 1)
                       {
                           rab[1] = 0;
                       }
                       else if (rab[0] < 0)
                       {
                           rab[0] = rows - 1;
                       }
                       else if (rab[1] < 0)
                       {
                           rab[1] = cols - 1;
                       }

                       while (map[rab[0], rab[1]] < 0)
                       {

                           rab[0] += direction[0];
                           rab[1] += direction[1];

                           if (rab[0] > rows - 1)
                           {
                               rab[0] = 0;
                           }
                           else if (rab[1] > cols - 1)
                           {
                               rab[1] = 0;
                           }
                           else if (rab[0] < 0)
                           {
                               rab[0] = rows - 1;
                           }
                           else if (rab[1] < 0)
                           {
                               rab[1] = cols - 1;
                           }
                       }


                       step++;
                   }

                   rabCount += map[rab[0], rab[1]];
                   map[rab[0], rab[1]] = 0;
               }
               else
               {
                   int step = 0;

                   while (step < steps)
                   {
                       if (por[0] + direction[0] == rab[0] && por[1] + direction[1] == rab[1])
                       {
                           break;
                       }

                       por[0] += direction[0];
                       por[1] += direction[1];



                       if (por[0] > rows - 1)
                       {
                           por[0] = 0;
                       }
                       else if (por[1] > cols - 1)
                       {
                           por[1] = 0;
                       }
                       else if (por[0] < 0)
                       {
                           por[0] = rows - 1;
                       }
                       else if (por[1] < 0)
                       {
                           por[1] = cols - 1;
                       }



                       while (map[por[0], por[1]] < 0)
                       {

                           por[0] += direction[0];
                           por[1] += direction[1];

                           if (por[0] > rows - 1)
                           {
                               por[0] = 0;
                           }
                           else if (por[1] > cols - 1)
                           {
                               por[1] = 0;
                           }
                           else if (por[0] < 0)
                           {
                               por[0] = rows - 1;
                           }
                           else if (por[1] < 0)
                           {
                               por[1] = cols - 1;
                           }
                       }

                       porCount += map[por[0], por[1]];
                       map[por[0], por[1]] = 0;

                       step++;
                   }



               }

           }
           while (!input.Equals("END"));

           //output

           if (rabCount > porCount)
           {
               Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.",rabCount,porCount);
           } else if(rabCount < porCount)
           {
               Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.", porCount,rabCount);
           }
           else
           {
               Console.WriteLine("Both units scored {0} points. Maybe we should play again?",rabCount);
           }

           //*/

        }
    }
}
