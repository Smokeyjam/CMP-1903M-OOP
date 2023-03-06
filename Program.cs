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

        static void Main(string[] args)//
        {
          
            Console.WriteLine("1 = Fisher Shuffle, 2 = Riffle Shuffle, 3 = no shuffle ");
            int Shuffle = Console.Read();
            Console.WriteLine(Shuffle);
            
            Pack P = new Pack();
            Pack.shuffleCardPack(2); // 1 is Fisher-Yates Shuffle and 2 is the riffle shuffle
            //Console.ReadLine();

            Console.WriteLine("How many cards do you want to deal? ");
            int amount = Console.Read();
            Pack.dealCard(amount);
        }
    }
}
