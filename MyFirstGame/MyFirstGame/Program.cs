using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyFirstGame
{
    struct Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    struct Ball
    {
        public int radius;
        public Position start;

        public Ball(int r, Position s)
        {
            this.radius = r;
            this.start = s;
        }

        public void PrintBall()
        {

        }
    }

    class Program
    {
        public static void PrintBall(Ball element)
        {
            int radius = element.radius;
            Position pos = element.start;

            Console.SetCursorPosition(pos.col, pos.row);

            int length = (2 * radius) + 1;
            int center = radius;
            for (int row = 0; row < length; row++)
            {
                for (int col = 0; col < length; col++)
                {
                    if ((row - center) * (row - center) + (col - center) * (col - center) <= radius * radius)
                    {
                        Console.SetCursorPosition(pos.col + col, pos.row + row);
                        if (radius > 3 && (row == center || col == center))
                        {
                            
                            Console.Write(" ");
                        }
                        else
                        {
                            Console.Write("%");
                        }
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            //Random generator za hranata
            Random numberGen = new Random();

            //opravqme bufera na konzolata
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            //zdavame elementite v igrata

            //struktura na klientskiq userBall
            Position start = new Position(0, 0);
            Ball userBall = new Ball(5,start);

            //struktura na hranata koqto shte qde
            Position startMeat = new Position(numberGen.Next(0, Console.WindowHeight-6), numberGen.Next(0,Console.WindowWidth-6));
            Ball meatBall = new Ball(2, startMeat);


            //Syzdavame vyzmojni posoki na dvijenie
            Position[] directions = new Position[]
            {
              new Position(0,1),//right
              new Position(0,-1), //left
              new Position(-1,0), //up
              new Position(1,0) //down
            };

            //posoka na dvijenie
            int direction = 0; // Right -> posoka na dvijenie po podrazbirane

            

            while (true)
            {
                Console.Clear();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;
                    }
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        direction = 2;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        direction = 3;
                    }

                    
                }

                //Promenqme posokata na dvijenie spored parametyra direction procheten ot streklkite na klaviaturata
                userBall.start.col += directions[direction].col;
                userBall.start.row += directions[direction].row;
               
                //printirane na hranata
                PrintBall(meatBall);

                if (Math.Abs((meatBall.start.col + 2) - (userBall.start.col + userBall.radius)) < (userBall.radius + 2+ 1) &&
                    Math.Abs((meatBall.start.row + 2) - (userBall.start.row + userBall.radius)) < (userBall.radius + 2 + 1))
                {
                    startMeat = new Position(numberGen.Next(0, Console.WindowHeight - 6), numberGen.Next(0, Console.WindowWidth - 6));
                    meatBall = new Ball(2, startMeat);
                    userBall.radius++;
                }

                //printvame topkata na klienta
                PrintBall(userBall);



                

                Thread.Sleep(100);

            }
            
        }
    }
}
