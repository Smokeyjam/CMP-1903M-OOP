using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //1 = Clubs, 2 = Spades, 3 = Diamonds and 4 = Hearts
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public void setValue(int Value)
        {
            this.Value = Value;
        }

        public void setSuit(int Suit)
        {
            this.Suit = Suit;
        }

        public int getValue()
        {
            return Value;
        }

        public int getSuit()
        {
            return Suit;
        }
    }
}
