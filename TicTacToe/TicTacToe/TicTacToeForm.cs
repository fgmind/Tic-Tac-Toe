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
    public partial class TicTacToeForm : Form
    {
        bool turn = true;   // when true it is X's turn, if false O's turn
        int turnCount = 0;  // maximum of turns is 9 before end of game
        public TicTacToeForm()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)     // this closes the game
        {
            Close();
        }

        private void btnClick(object sender, EventArgs e)   // adds X or O, and increments count. For all buttons
        {
            Button b = (Button)sender;  // temp object to represent button

            if (turn == true)   // X's turn
            {
                b.Text = "X";
            }
            else                // O's turn
            {
                b.Text = "O";
            }

            turn = !turn;       // changes player turn
            b.Enabled = false;  // so that player cannot click on used button

            turnCount++;        // increments count
            checkIfWin();       // then checks for a win or draw

        }

        private void checkIfWin()   // checks whether player wins
        {
            bool gameWon = false;

            foreach(Control c in Controls)  // checks all 8  winning combinations
            {
                if ((a1.Text == b1.Text) && (a1.Text == c1.Text) && !a1.Enabled)
                {
                    gameWon = true;
                }
                else if ((a2.Text == b2.Text) && (a2.Text == c2.Text) && !a2.Enabled)
                {
                    gameWon = true;
                }
                else if ((a3.Text == b3.Text) && (a3.Text == c3.Text) && !a3.Enabled)
                {
                    gameWon = true;
                }
                else if ((a1.Text == a2.Text) && (a1.Text == a3.Text) && !a1.Enabled)
                {
                    gameWon = true;
                }
                else if ((b1.Text == b2.Text) && (b1.Text == b3.Text) && !b1.Enabled)
                {
                    gameWon = true;
                }
                else if ((c1.Text == c2.Text) && (c1.Text == c3.Text) && !c1.Enabled)
                {
                    gameWon = true;
                }
                else if ((a1.Text == b2.Text) && (a1.Text == c3.Text) && !a1.Enabled)
                {
                    gameWon = true;
                }
                else if ((a3.Text == b2.Text) && (a3.Text == c1.Text) && !a3.Enabled)
                {
                    gameWon = true;
                }
            }
            if (gameWon == true)
            {
                disableButtons();   // since game over player can't click on buttons anymore

                String winner = "";

                if (turn == true)
                {
                    winner = "O";
                }
                else
                {
                    winner = "X";
                }

                MessageBox.Show(winner +" is the winner!");
            }

            if (turnCount == 9)                     // if no-one wins by the end of count, Draw
            {
                MessageBox.Show("It's a draw!!!");
                disableButtons();
            }
        }

        private void disableButtons()
        {
            foreach (Control c in Controls)
            {
                Button b = (Button)c;
                b.Enabled = false;          // all buttons are disabled!
            }
            newGame.Enabled = true;         // re-activating 'New Game' and 'exit'
            exit.Enabled = true;
        }

        private void newGame_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                Button b = (Button)c;
                b.Enabled = true;       // re-activating buttons for new game
                b.Text = "";            // to clear Xs and Os    
            }
            turn = true;                // go back to X's turn
            turnCount = 0;              // reset counter
            newGame.Text = "New Game";
            exit.Text = "Exit";
        }
    }
}
