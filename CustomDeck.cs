using Deck_Builder;

namespace Deck_Builder
{
    /// <summary>
    /// Represents a customizable deck that allows adding custom cards.
    /// </summary>
    public class CustomDeck : Deck
    {
        /// <summary>
        /// Adds a custom card with a specified suit and rank to the deck.
        /// </summary>
        public void AddCustomCard(string suit, string rank)
        {
            AddCard(new Card(suit, rank));
        }
    }
}


