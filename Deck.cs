using Deck_Builder;
using System;
using System.Collections.Generic;

namespace Deck_Builder
{
    /// <summary>
    /// Represents a deck of cards with basic functionalities such as adding,
    /// shuffling, dealing, and resetting.
    /// </summary>
    public class Deck
    {
        protected List<Card> cards; // List to hold the cards in the deck

        public Deck()
        {
            cards = new List<Card>();
        }

        /// <summary>
        /// Adds a card to the deck.
        /// </summary>
        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        /// <summary>
        /// Shuffles the deck using the Fisher-Yates shuffle algorithm.
        /// </summary>
        public void Shuffle()
        {
            Random rng = new Random();
            int n = cards.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }

        /// <summary>
        /// Deals a specified number of cards from the deck.
        /// </summary>
        public List<Card> Deal(int count)
        {
            if (count > cards.Count)
            {
                count = cards.Count;
            }
            var dealtCards = cards.GetRange(0, count);
            cards.RemoveRange(0, count);
            return dealtCards;
        }

        /// <summary>
        /// Returns a copy of the current cards in the deck.
        /// </summary>
        public List<Card> GetCards()
        {
            return new List<Card>(cards);
        }

        /// <summary>
        /// Clears all cards from the deck, resetting it.
        /// </summary>
        public void Reset()
        {
            cards.Clear();
        }
    }
}


