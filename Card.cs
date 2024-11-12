namespace Deck_Builder
{
    /// <summary>
    /// Represents a playing card with a suit and rank.
    /// </summary>
    public class Card
    {
        public string Suit { get; set; } // Card suit (e.g., Hearts, Spades)
        public string Rank { get; set; } // Card rank (e.g., Ace, King, 10)

        /// <summary>
        /// Initializes a new card with a specific suit and rank.
        /// </summary>
        public Card(string suit, string rank)
        {
            Suit = suit;
            Rank = rank;
        }

        /// <summary>
        /// Returns a string in the format "Rank of Suit" for easy display.
        /// </summary>
        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }
    }
}

