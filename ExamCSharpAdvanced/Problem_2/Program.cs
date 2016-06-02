using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{


    class Program
    {


        


        static void Main(string[] args)
        {
            //name Task 2: Kitty

            //input

            char[] input = Console.ReadLine().ToCharArray();

            string[] path = Console.ReadLine().Split();

            //logic

            bool dead = false;

            int length = path.Length;//dyljinata na stringa ot skokove


            int inputLength = input.Length;

            // output vars
            int souls = 0;
            int deadlocks = 0;
            int food = 0;
            int countJumps = 0;



            int indexer = 0;//iterator na vhodniq string ot elementi


            //nachalna poziciq
            if(input[indexer] == '@')
            {
                souls++;
                input[indexer] = '0';
            }
            else if (input[indexer] == '*')
            {
                food++;
                input[indexer] = '0';
            }
            else if (input[indexer] == 'x')
            {                
              dead = true;                  
            }

        
            //ako pri nachalnata poziciq kotkata ujivee
            if (!dead)
            {
                for (int i = 0; i < length; i++)
                {
                    countJumps++;//prebroqva stypkite

                    int direction = int.Parse(path[i]);
                    
                    int nextPossition = indexer;

                    nextPossition += direction;

                    //opredelqne na poziciq
                    if (nextPossition < 0)
                    {
                        
                        while (nextPossition < 0)
                        {
                            nextPossition +=  inputLength;
                        }
                        indexer = nextPossition;

                    }
                    else if (nextPossition > inputLength - 1)
                    {
                        while (nextPossition > inputLength - 1)
                        {
                            nextPossition -= inputLength;
                        }
                        indexer = nextPossition;
                    }
                    else
                    {
                        indexer += direction;
                    }

                    //Console.WriteLine(indexer);

                    
                    if (input[indexer] == '@')
                    {
                        souls++;
                        input[indexer] = '0';

                    }
                    else if (input[indexer] == '*')
                    {
                        food++;
                        input[indexer] = '0';
                    }
                    else if (input[indexer] == 'x')
                    {
                        if (indexer % 2 == 0)
                        {
                            if (souls > 0)
                            {
                                deadlocks++;
                                souls--;
                                input[indexer]='@';
                            }
                            else
                            {
                                dead = true;
                                break;
                            }
                        }
                        else
                        {
                            if (food > 0)
                            {
                                deadlocks++;
                                food--;
                                input[indexer]='*';

                            }
                            else
                            {
                                dead = true;
                                break;
                            }
                        }
                    }

                }
            }
            

            //output

            if (dead)
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: " + countJumps);
     
            }
            else
            {
                Console.WriteLine("Coder souls collected: " + souls);
                Console.WriteLine("Food collected: " + food);
                Console.WriteLine("Deadlocks: " + deadlocks);
            }

            /*
            foreach (char item in input)
            {
                Console.Write(item);
            }
            */
        }
    }
}
