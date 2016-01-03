using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        bool turn = true; // true = X turn, false = O turn
        int turnCount = 0; 

        public TicTacToe()
        {
            InitializeComponent();
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            try
            {
                foreach (var cont in Controls)
                {
                    Button b = (Button)cont;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender; // cast sender object, that contains 1 of 9 buttons to Button and store in b
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            b.Enabled = false;
            turnCount++;
            CheckForWinner();
            turn = !turn;
        }

        private void CheckForWinner()
        {
            bool thereIsAWinner = false;

            // horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                thereIsAWinner = true;

            // vertical
            if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                thereIsAWinner = true;

            // diagonal
            if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                thereIsAWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                thereIsAWinner = true;

            var winner = turn ? "X" : "O";

            if (thereIsAWinner)
            {
                DisableAll();
                MessageBox.Show($"{winner} wins");
            }
            else
                if (turnCount == 9)
                MessageBox.Show("Draw!");
        }

        private void DisableAll() // disable all buttons on form so the game stops
        {
            foreach (var comp in Controls)
            {
                try // menu strip can`t be casted to Button
                {
                    Button b = (Button)comp;
                    b.Enabled = false;
                }
                catch { }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Max Khamrovskyi", "Tic Tac Toe About");
        }
    }
}
