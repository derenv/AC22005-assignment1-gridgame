using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* 
 * English Draughts in C#
 * 
 * by Deren Vural - 160009020
 * Gregor Taylor  - 160012442
 * (c) 2018
 * 
 */

namespace english_draughts
{
    //storage for tile data
    public class tile
    {
        bool king;
        int x;
        int y;
        public tile(int x, int y)
        {
            //
            king = false;
            this.x = x;
            this.y = y;
        }

        public int get_x()
        {
            return x;
        }

        public int get_y()
        {
            return y;
        }
    }

    public partial class draughts_frm : Form
    {
        //global variables + objects
        string status;
        int start_x;
        int start_y;
        int finish_x;
        int finish_y;
        Button[,] board = new Button[8,8];

        public draughts_frm()
        {
            InitializeComponent();

            //change game status
            status = "start";

            //button init
            bool dark_tile = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //init button
                    board[i, j] = new Button();

                    //set position
                    board[i,j].SetBounds(75 + (50 * j), 90 + (50 * i), 50, 50);

                    //set text
                    board[i,j].Text = Convert.ToString("");

                    //set data
                    board[i, j].Tag = new tile(j,i);

                    //set colour
                    if (dark_tile)
                    {
                        //colour
                        board[i, j].BackColor = Color.Red;

                        //boolean activator
                        dark_tile = false;
                    }
                    else
                    {
                        //colour
                        board[i, j].BackColor = Color.Blue;

                        //boolean activator
                        dark_tile = true;
                    }

                    //add click event
                    board[i,j].Click += new EventHandler(this.btnEvent_Click);
                }

                //alternating colour per row/column
                if (dark_tile)
                {
                    //boolean activator
                    dark_tile = false;
                }
                else
                {
                    //boolean activator
                    dark_tile = true;
                }
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            Button current = (Button)sender;
            tile current_tag = (tile)current.Tag;
            Console.WriteLine("POSITION : "+ current_tag.get_x() + ","+ current_tag.get_y());
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
            result = MessageBox.Show("English Draughts in C# by Deren Vural & Gregor Taylor (c) 2018", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("how to play", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //change game status
            status = "game";

            //activate buttons
            for(int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //add to form
                    Controls.Add(board[i, j]);
                }
            }
        }
    }
}
