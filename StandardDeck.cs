using Deck_Builder;

namespace Deck_Builder
{
    /// <summary>
    /// Represents a standard deck of 52 playing cards with 4 suits and 13 ranks.
    /// </summary>
    public class StandardDeck : Deck
    {
        public StandardDeck()
        {
            InitializeStandardDeck();
        }

        /// <summary>
        /// Populates the deck with 52 cards: each combination of the 4 suits and 13 ranks.
        /// </summary>
        private void InitializeStandardDeck()
        {
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    AddCard(new Card(suit, rank));
                }
            }
        }
    }
}


