using Deck_Builder;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Deck_Builder
{
    /// <summary>
    /// MainWindow class represents the main interface for the deck builder application.
    /// </summary>
    public partial class MainWindow : Window
    {
        private StandardDeck standardDeck;
        private CustomDeck customDeck;
        private List<Card> dealtCards;

        public MainWindow()
        {
            InitializeComponent();
            standardDeck = new StandardDeck();
            customDeck = new CustomDeck();
            UpdateDeckDisplay();
        }
        /// <summary>
        /// Updates the deck display to show the current state of both decks.
        /// </summary>
        private void UpdateDeckDisplay()
        {
            // Display cards from standardDeck and customDeck together
            var allCards = new List<Card>(standardDeck.GetCards());
            allCards.AddRange(customDeck.GetCards());

            DeckListView.ItemsSource = null;
            DeckListView.ItemsSource = allCards;
        }
        /// <summary>
        /// Adds a custom card to the custom deck when the "Add Custom Card" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCustomButtonClick(object sender, RoutedEventArgs e)
        {
            // Get the custom card suit and rank from the TextBoxes
            string suit = SuitTextBox.Text.Trim();
            string rank = RankTextBox.Text.Trim();

            if (ValidateCardInput(suit, rank))
            {
                // Add custom card to the custom deck
                customDeck.AddCustomCard(suit, rank);
                UpdateDeckDisplay();

                // Clear input fields
                SuitTextBox.Clear();
                RankTextBox.Clear();
            }
        }
        /// <summary>
        /// Validates the user input for custom card suit and rank.
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="rank"></param>
        /// <returns></returns>
        private bool ValidateCardInput(string suit, string rank)
        {
            if (string.IsNullOrWhiteSpace(suit))
            {
                MessageBox.Show("Suit cannot be blank.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(rank))
            {
                MessageBox.Show("Rank cannot be blank.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Deals a specified number of cards from the standard deck and displays them in the CardsDealtListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DealButtonClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(DrawTextBox.Text, out int drawCount) && drawCount > 0)
            {
                // Deal cards from the standard deck
                dealtCards = standardDeck.Deal(drawCount);

                // Update the CardsDealtListView with the dealt cards
                CardsDealtListView.ItemsSource = null;
                CardsDealtListView.ItemsSource = dealtCards;

                UpdateDeckDisplay();
                DrawTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid draw amount. Please enter a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        /// <summary>
        /// Displays all the cards from both the standard and custom decks in the DeckListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDeckButtonClick(object sender, RoutedEventArgs e)
        {
            // Display all cards in the deck in the DeckListView
            UpdateDeckDisplay();

        }
        /// <summary>
        /// Shuffles both the standard and custom decks and updates the display to reflect the new order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShuffleButtonClick(object sender, RoutedEventArgs e)
        {
            // Shuffle both the standard and custom decks
            standardDeck.Shuffle();
            customDeck.Shuffle();

            // Update the display to reflect the shuffled order
            UpdateDeckDisplay();
        }
        /// <summary>
        /// Resets the decks to their default state, clears any dealt cards, and updates the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButtonClick(object sender, RoutedEventArgs e)
        {
            // Reset to the default state: create new decks, clear dealt cards, and update display
            standardDeck = new StandardDeck();
            customDeck.Reset();
            dealtCards = new List<Card>();

            UpdateDeckDisplay();

            // Clear UI components
            CardsDealtListView.ItemsSource = null;
            SuitTextBox.Clear();
            RankTextBox.Clear();
            DrawTextBox.Clear();
        }
        /// <summary>
        /// Exits the application when the "Exit" button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            // Exit the application
            Application.Current.Shutdown();
        }
        /// <summary>
        /// Handles keyboard shortcuts within the main window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Handle keyboard shortcuts for Reset and Add Custom actions
            if (e.Key == Key.Escape)
            {
                ResetButtonClick(sender, e);
            }
            else if (e.Key == Key.Enter && RankTextBox.IsFocused)
            {
                AddCustomButtonClick(sender, e);
            }
        }
    }
}