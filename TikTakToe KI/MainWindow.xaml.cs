﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TikTakToe_KI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Attribute
        public char Player = 'X';
        public char Computer = 'O';
        public bool YourTurn;

        public int ScoreX = 0;
        public int ScoreO = 0;

        public List<Button> Buttons = new List<Button>();
        public int[] board = new int[9];
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();

            //Läde alle Buttons in eine Liste
            foreach (Button btn in GameGrid.Children)
            {
                Buttons.Add(btn);
            }

            XScore.Text = ScoreX.ToString();
            OScore.Text = ScoreO.ToString();

            NewGame();
            YourTurn = WhoBeginns();
        }

        //Random auswahl wer beginnt
        public bool WhoBeginns()
        { 
            return (random.Next(0, 3) < 2);
        }

        //Platziere deine Form
        private void b_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content == "")
            {
                if (YourTurn)
                {
                    btn.Content = Player;
                    CheckWin(1);
                    YourTurn = false;
                }
                else
                {
                    btn.Content = Computer;
                    CheckWin(2);
                    YourTurn = true;
                }
                
            }
        }

        //Button Reset Funktion 
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        //Starte ein neues Spiel
        public void NewGame()
        {
            foreach (Button btn in Buttons)
            {
                btn.Content = "";
            }

            board = new int[9];
        }

        //Startet Partie
        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }

        //Stopt Partie
        private void Stop_Click(object sender, RoutedEventArgs e)
        {

        }

        //überprüfung ob jemand gewonnen hat
        private void CheckWin(int p)
        {
            //Horizontal
            for (int i = 0; i <9; i+=3)
            {
                if (board[i] == p && board[i+1] == p && board[i+2] == p)
                {
                    AddScore(p);
                    NewGame();
                    return;
                }
            }

            //Vertikal
        }

        private void AddScore(int Player)
        {

        }
    }
}