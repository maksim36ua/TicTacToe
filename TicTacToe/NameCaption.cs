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
    public partial class NameCaption : Form
    {
        public NameCaption()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicTacToe.setPlayersNames(name1: p1.Text, name2: p2.Text);
            this.Close();
        }

        private void p1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
        }

        private void p2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "\r")
                button1.PerformClick();
        }
    }
}
