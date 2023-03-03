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
            Pack P = new Pack();
            Pack.shuffleCardPack(2); // 1 is Fisher-Yates Shuffle and 2 is the riffle shuffle
            Console.ReadLine();

        }
    }
}
