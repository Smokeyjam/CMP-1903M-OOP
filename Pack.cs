using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    public class Pack
    {
        static List<Card> pack = new List<Card>();
        static List<Card> pack2 = new List<Card>();
        static List<Card> ShuffledPack = new List<Card>();
        static List<Card> Dealt_Hand = new List<Card>();

        public Pack()
        {
            int Card_Number = 1; int Suit_Number = 1;

            //Initialise the card pack here
            while(Suit_Number < 5)
            {
                createCard(Card_Number,Suit_Number);
                Card_Number += 1;
                
                if (Card_Number == 14)
                {
                    Card_Number = 1;
                    Suit_Number += 1;
                }

            }            
            //reading the cards in the pack
            foreach (Card card in pack)
            {
                Console.WriteLine(card.getValue() + " " + card.getSuit());
            }

            Console.Write("starting amount of elements " + pack.Count());
        }

        public void createCard(int value,int suit)
        {
            Card card = new Card();

            card.setValue(value);
            card.setSuit(suit);

            pack.Add(card);
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            //Fisher-Yates Shuffle 
          
            Random rnd = new Random();
            
            if (typeOfShuffle == 1)
            {
                while (pack.Count() != 0)
                {
                    //Randomly pick a card
                    int Picked_Card = rnd.Next(0, pack.Count() - 1);
                    Console.WriteLine("\nhigh range for random number " +(pack.Count() - 1 ));
                    Console.WriteLine("\nthis is the random int " + Picked_Card);
                    Console.WriteLine("this is the card object " + pack[Picked_Card].getValue() +" "+ pack[Picked_Card].getSuit());

                    //add to new shuffled list
                    ShuffledPack.Add(pack[Picked_Card]);
  

                    //remove from list
                    pack.RemoveAt(Picked_Card);
                    Console.WriteLine("total element amount now " + pack.Count());
                    //go back to first
                }
            }
            //riffle shuffle 
            if (typeOfShuffle == 2)
            {
                //split the deck into two halves
                // pack.Count()/2 
                // then for card card in pack check if the id is greater than 26 
                // add to the shuffle list 
                // for each card left in the original pack put the current object before it
                int RiffleNum = 26;

                while (pack.Count() != 26)
                { 

                    pack2.Add(pack[RiffleNum]);
                    pack.Remove(pack[RiffleNum]);
                }
                
                while (ShuffledPack.Count() != 52)
                {

                    ShuffledPack.Add(pack[0]);
                    ShuffledPack.Add(pack2[0]);
                    pack.Remove(pack[0]);
                    pack2.Remove(pack2[0]);
                }
                
            }
            //for reading the first half of the new shuffle 
            Console.WriteLine("\nthis is what's left in the orginal pack");
                foreach (Card card in pack)
                {
                     Console.WriteLine(card.getValue() + " " + card.getSuit());
                }
            
            Console.WriteLine("ShuffledPack contents \n");  

            foreach (Card card in ShuffledPack)
            {
                
                Console.WriteLine(card.getValue() + " " + card.getSuit());
            }
            Console.WriteLine(ShuffledPack.Count());
            return true;
            
        }
        public static Card deal()
        {
            //deals one card
            Dealt_Hand.Add(ShuffledPack[0]);
            ShuffledPack.Remove(ShuffledPack[0]);
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            while (amount > 0)
            {
                deal();
            }
            return dealCard.list();
        } 
    }
}
