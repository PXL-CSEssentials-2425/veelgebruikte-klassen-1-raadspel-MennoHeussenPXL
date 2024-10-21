using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace raadspel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int targetNumber;
        private int guessCount;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            GenerateNewNumber();
        }

        private void GenerateNewNumber()
        {
            targetNumber = random.Next(1, 101); // Willekeurig getal tussen 1 en 100
            guessCount = 0;
            output1TextBox.Text = ""; // Reset de output messages
            output2TextBox.Text = "Aantal keren geraden: 0"; // Reset aantal pogingen
        }

        // Event handler voor de evaluateButton (beoordelen van de gok).
        private void evaluateButton_Click(object sender, RoutedEventArgs e)
        {
            int userGuess;
            if (int.TryParse(numberTextBox.Text, out userGuess))
            {
                guessCount++;
                output2TextBox.Text = $"Aantal keren geraden: {guessCount}";

                if (userGuess == targetNumber)
                {
                    output1TextBox.Text = "Proficiat! U hebt het getal geraden!";
                }
                else if (userGuess < targetNumber)
                {
                    output1TextBox.Text = "Raad hoger!";
                }
                else
                {
                    output1TextBox.Text = "Raad lager!";
                }
            }
            else
            {
                MessageBox.Show("Voer een geldig getal in tussen 1 en 100.", "Ongeldige invoer", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Event handler voor de newButton (nieuw getal genereren).
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            GenerateNewNumber();
        }

        // Event handler voor de endButton (applicatie sluiten).
        private void endButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}