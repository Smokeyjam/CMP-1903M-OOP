using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        //static List<Card> pack = new List<Card>();

        static void Main(string[] args)
        {
            
            bool Check = false;
            int Shuffle;

            //Actives all the checks
            Console.WriteLine("do you want checks on? (Y or N) ");
            string Checks = Console.ReadLine();
            if (Checks == "Y")
            {
                Pack.Show_Prompts();
                Console.WriteLine("\nShowing Prompts\n ");
            }
            
            //Choosing which shuffle you want and makes sure you are within the bounds
            Console.WriteLine("1 = Fisher Shuffle, 2 = Riffle Shuffle, 3 = no shuffle ");
            Shuffle = Convert.ToInt32(Console.ReadLine());
            while (Check != true)
            {
                if(Shuffle >= 1)
                {
                    if(Shuffle <=3)
                    {
                        break;
                    }
                }
                
                Console.WriteLine("Please Try Again");
                Shuffle = Convert.ToInt32(Console.ReadLine());

            }
            
            Pack P = new Pack();
            Pack.shuffleCardPack(Shuffle); // 1 is Fisher-Yates Shuffle, 2 is the riffle shuffle and 3 is no Shuffle

            
            //for choosing the amount of dealt cards you want and making sure your within the index bounds
            Console.WriteLine("How many cards do you want to deal? ");
            int amount = Convert.ToInt32(Console.ReadLine());
            while (Check != true)
            {
                if (amount >= 1)
                {
                    if (amount <= 52)
                    {
                        break;
                    }
                }

                Console.WriteLine("Please Try Again ");
                amount = Convert.ToInt32(Console.ReadLine());
            }

            Pack.dealCard(amount);
            Console.WriteLine("this is the end of the program");
            
            Console.ReadLine();
        }
    }
}
