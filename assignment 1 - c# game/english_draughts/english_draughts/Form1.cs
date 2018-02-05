using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace english_draughts
{
    public partial class draughts_frm : Form
    {
        string status;
        public draughts_frm()
        {
            InitializeComponent();
            status = "start";
        }

        /* 
         * change text of title label with appropriate message
         * on loss/win of game
         */
        private void win_text()
        {
            switch (status){
                case "start":
                case "game":
                    //modify title label with standard title
                    title_lbl.Text = "Draughts";

                    //add 'new game' button
                    //

                    break;
                case "win":
                    //modify title label with win message
                    title_lbl.Text = "You Win!!";

                    break;
                case "lose":
                    //modify title label with loss message
                    title_lbl.Text = "You Lose!!";

                    //add 'new game' button
                    //

                    break;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Pocket Calculator in C# by Deren Vural & Gregor Taylor (c) 2018", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("how to play", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
