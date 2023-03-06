using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        
        public static bool Check_Prompts = false;
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
            if(Check_Prompts == true)
            {
                Show_Pack(pack);

                Console.Write("starting amount of elements " + pack.Count());
            }

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
            //Shuffles the pack based on the type of shuffle choosen in Main
            
            //Fisher-Yates Shuffle 
          
            Random rnd = new Random();
            
            if (typeOfShuffle == 1)
            {
                //Picks a random card object from the list
                //Adds it to a shuffled list
                //Removes the object from the old pack so it can't get picked on again
                //repeats till there are no objects left in the pack list
                
                while (pack.Count() != 0)
                {
                    //Randomly picks a card
                    int Picked_Card = rnd.Next(0, pack.Count() - 1);

                    //testing prompts to show you what's going on
                    if (Check_Prompts == true)
                    {
                        Console.WriteLine("\nhigh range for random number " + (pack.Count() - 1));
                        Console.WriteLine("\nthis is the random int " + Picked_Card);
                        Console.WriteLine("\nthis is the card object " + pack[Picked_Card].getValue() + " " + pack[Picked_Card].getSuit());
                    }
                    //adds card to new shuffled List
                    ShuffledPack.Add(pack[Picked_Card]);
  

                    //remove from list
                    pack.RemoveAt(Picked_Card);
                    if (Check_Prompts == true)
                    {
                        Console.WriteLine("total element amount now " + pack.Count());
                    }
                    //repeat
                }
            }
            //riffle shuffle 
            if (typeOfShuffle == 2)
            {
                //split the deck into two halves
                //26 is when the second half of the deck starts
                //test to show where the cards have gone               
                //adds the objects to the shuffle list 
                //Another prompt to show the pack has been shuffled
                

                //Splints deck into two halves
                //adds all second half objects to another list
                while (pack.Count() != 26)
                {
                    pack2.Add(pack[26]);
                    pack.Remove(pack[26]);
                }

                //Prompts to show where the card objects have gone
                if (Check_Prompts == true)
                {
                    //for reading the first half of the new shuffle 
                    Console.WriteLine("\nthis is what's left in the orginal pack\n");
                    Show_Pack(pack);

                    //for reading the Second half of the new shuffle 
                    Console.WriteLine("\nthis is what's in pack2\n");
                    Show_Pack(pack2);
                }
                //adding the cards to shuffledPack alternating packs for the riffle
                while (ShuffledPack.Count() != 52)
                {

                    ShuffledPack.Add(pack[0]);
                    ShuffledPack.Add(pack2[0]);
                    pack.Remove(pack[0]);
                    pack2.Remove(pack2[0]);
                }
                
            }
            //no Shuffle
            if (typeOfShuffle == 3)
            {
                //adds objects from pack into Shuffled pack
                while (ShuffledPack.Count() != 52)
                {
                    ShuffledPack.Add(pack[0]);
                    pack.RemoveAt(0);
                }            
            }
            if (Check_Prompts == true)
            {
                //to check what's in the shuffled pack
                Console.WriteLine("\nShuffledPack contents \n");
                Show_Pack(ShuffledPack);
            }
            return true;
            
            
        }
        //adds one card from the Shuffled pack to the dealt one 
        public static void deal()
        {
            //deals one card
            Dealt_Hand.Add(ShuffledPack[0]);
            ShuffledPack.Remove(ShuffledPack[0]);
        }
        //deals and displays cards dealt
        public static void dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            while (amount != 0)
            {
                deal();
                amount -= 1;
            }

            if (Check_Prompts == true)
            {
                //another test
                Console.WriteLine("ShuffledPack contents \n");
                Show_Pack(ShuffledPack);

                Console.WriteLine("DealtHand Contents");
                Show_Pack(Dealt_Hand);
            }
            foreach (Card card in Dealt_Hand)
            {
                //changes the suits and values to their correct strings
                String Value_Str;
                String Suit_Str;
                
                if (card.getSuit() == 1)
                {
                    Suit_Str = "Clubs";
                }
                else if (card.getSuit() == 2)
                {
                    Suit_Str = "Spades";
                }
                else if (card.getSuit() == 3)
                {
                    Suit_Str = "Diamonds";
                }
                else
                {
                    Suit_Str = "Hearts";
                }

                if (card.getValue() == 1)
                {
                    Value_Str = "Ace";
                }
                else if (card.getValue() == 11)
                {
                    Value_Str = "Jack";
                }
                else if (card.getValue() == 12)
                {
                    Value_Str = "Queen";
                }
                else if (card.getValue() == 13)
                {
                    Value_Str = "King";
                }
                else
                {
                    Value_Str = card.getValue().ToString();
                }
                
                Console.WriteLine(Value_Str + " of " + Suit_Str);
            }
            if (Check_Prompts == true)
            {
                Console.WriteLine("total of Cards Dealt is " + Dealt_Hand.Count());
            }
        }
        //goes through a list telling you on the console first the value then the suit of the card object
        private static void Show_Pack(List<Card> List)
        {
            foreach (Card card in List)
            {
                Console.WriteLine(card.getValue() + " " + card.getSuit());
            }
            Console.WriteLine("total amount of cards is " + List.Count());
        }
 
        public static void Show_Prompts()
        {
            Check_Prompts = true;
        }
    }
}
