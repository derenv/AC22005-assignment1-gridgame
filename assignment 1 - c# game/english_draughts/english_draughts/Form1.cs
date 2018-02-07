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
    public partial class draughts_frm : Form
    {
        //global variables + objects
        string status;
        int start_x;
        int start_y;
        int finish_x;
        int finish_y;
        int current_player;
        bool moving;
        Button[,] board = new Button[8,8];
        tile[,] tiles = new tile[2,12];

        public draughts_frm()
        {
            InitializeComponent();

            //change game status
            status = "start";
            moving = false;
            current_player = 0;

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
                    tile current_tag = new tile(j, i);
                    board[i, j].Tag = current_tag;

                    //set colour
                    if (dark_tile)
                    {
                        if (j == 0 || j == 1 || j == 2)
                        {
                            //PLAYER 1
                            //colour
                            board[i, j].BackColor = Color.White;

                            //player
                            current_tag.set_player(1);
                        }
                        else if (j == 5 || j == 6 || j == 7)
                        {
                            //PLAYER 2
                            //colour
                            board[i, j].BackColor = Color.Black;

                            //player
                            current_tag.set_player(2);
                        }
                        else
                        {
                            //colour
                            board[i, j].BackColor = Color.Red;
                        }
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

        private void execute_take()
        {
            if (finish_x == (start_x - 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1, start_x - 1].Tag;
                tile second = (tile)board[start_y - 3, start_x - 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y - 1, start_x - 1].Tag = first;
                board[start_y - 3, start_x - 3].Tag = second;

                //change colour
                board[start_y - 1, start_x - 1].BackColor = Color.Red;
                board[start_y - 3, start_x - 3].BackColor = Color.Red;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1, start_x + 1].Tag;
                tile second = (tile)board[start_y + 3, start_x + 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y + 1, start_x + 1].Tag = first;
                board[start_y + 3, start_x + 3].Tag = second;

                //change colour
                board[start_y + 1, start_x + 1].BackColor = Color.Red;
                board[start_y + 3, start_x + 3].BackColor = Color.Red;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1, start_x - 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y - 1, start_x - 1].Tag = first;

                //change colour
                board[start_y - 1, start_x - 1].BackColor = Color.Red;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1, start_x + 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y + 1, start_x + 1].Tag = first;

                //change colour
                board[start_y + 1, start_x + 1].BackColor = Color.Red;
            }
        }

        private bool valid_move()
        {
            if (finish_x == (start_x + 1) && (finish_y == (start_y + 1) || finish_y == (start_y - 1)))
            {
                //if standard forward take
                if (current_player == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (finish_x == (start_x - 1) && (finish_y == (start_y + 1) || finish_y == (start_y - 1)))
            {
                //if standard forward take
                if (current_player == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool valid_take(tile finish_tag)
        {
            //get finish x and y
            finish_x = finish_tag.get_x();
            finish_y = finish_tag.get_y();

            if (finish_x == (start_x - 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1, start_x - 1].Tag;
                tile second = (tile)board[start_y - 3, start_x - 3].Tag;

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if(!(finish_tag.get_king()))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x - 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1, start_x - 1].Tag;
                tile second = (tile)board[start_y + 3, start_x - 3].Tag;

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(finish_tag.get_king()))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1, start_x + 1].Tag;
                tile second = (tile)board[start_y + 3, start_x + 3].Tag;

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(finish_tag.get_king()))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1, start_x + 1].Tag;
                tile second = (tile)board[start_y - 3, start_x + 3].Tag;

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(finish_tag.get_king()))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1, start_x + 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if(!(current_player == 1))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1, start_x - 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 2))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1, start_x + 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 1))
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1, start_x - 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 1))
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            //check game begun & not over
            if (status.Equals("game"))
            {
                //check if second tile selected
                if (moving)
                {
                    //get if clicked button
                    Button finish = (Button)sender;
                    tile finish_tag = (tile)finish.Tag;

                    //check if clicked button is occupied
                    if (finish_tag.get_player() == 0)
                    {
                        //change game status
                        moving = false;

                        //get finish x and y
                        finish_x = finish_tag.get_x();
                        finish_y = finish_tag.get_y();

                        //get moving tile from starting pos
                        Button start = board[start_x, start_y];
                        tile start_tag = (tile)start.Tag;

                        //check move or take
                        bool take = false;
                        if(valid_take(finish_tag))
                        {
                            //TEST
                            Console.WriteLine("VALID MOVE/TAKE");
                            take = true;
                        }
                        bool move = false;
                        if (valid_move())
                        {
                            //TEST
                            Console.WriteLine("VALID MOVE/TAKE");
                            move = true;
                        }

                        //execute if valid/move else cancel operation
                        if (take)
                        {
                            //TEST
                            Console.WriteLine("TO POSITION : X - " + finish_x + " Y - " + finish_y);

                            //delete taken pieces from game
                            execute_take();

                            //check if king
                            if (start_tag.get_king())
                            {
                                //move king bools
                                start_tag.set_king(false);
                                finish_tag.set_king(true);
                            }

                            //assign/unassign tiles to player
                            start_tag.empty();
                            finish_tag.set_player(current_player);

                            //change start tile colour & empty
                            board[start_y, start_x].BackColor = Color.Red;

                            //change finish tile colour
                            if (current_player == 2)
                            {
                                board[finish_y, finish_x].BackColor = Color.Black;
                                current_player = 1;
                            }
                            else
                            {
                                board[finish_y, finish_x].BackColor = Color.White;
                                current_player = 2;
                            }

                            //replace tiles
                            board[finish_y, finish_x].Tag = finish_tag;
                            board[start_y, start_x].Tag = start_tag;

                            //TEST
                            Console.WriteLine("PLAYER " + current_player + " MOVE");
                        }
                        else if (move)
                        {
                            //TEST
                            Console.WriteLine("TO POSITION : X - " + finish_x + " Y - " + finish_y);

                            //check if king
                            if (start_tag.get_king())
                            {
                                //move king bools
                                start_tag.set_king(false);
                                finish_tag.set_king(true);
                            }

                            //assign/unassign tiles to player
                            start_tag.empty();
                            finish_tag.set_player(current_player);

                            //change start tile colour
                            board[start_y, start_x].BackColor = Color.Red;

                            //change finish tile colour
                            if (current_player == 2)
                            {
                                board[finish_y, finish_x].BackColor = Color.Black;
                                current_player = 1;
                            }
                            else
                            {
                                board[finish_y, finish_x].BackColor = Color.White;
                                current_player = 2;
                            }

                            //replace tiles
                            board[finish_y, finish_x].Tag = finish_tag;
                            board[start_y, start_x].Tag = start_tag;

                            //TEST
                            Console.WriteLine("PLAYER " + current_player + " MOVE");
                        }
                        else
                        {
                            //cancel move
                            moving = false;

                            //TEST
                            Console.WriteLine("..invalid tile to move to..");
                        }

                        //(win check)
                        //NEXT PLAYER CANNOT MOVE CHECK
                        //(TO BE ADDED)
                    }
                    else
                    {
                        //cancel move
                        moving = false;

                        //TEST
                        Console.WriteLine("..invalid tile to move to..");
                    }
                }
                else
                {
                    //get clicked tile
                    Button current = (Button)sender;
                    tile current_tag = (tile)current.Tag;

                    //check if clicked button is occupied
                    if(current_player == current_tag.get_player())
                    {
                        //change game status
                        moving = true;

                        //get clicked tile position
                        start_x = current_tag.get_x();
                        start_y = current_tag.get_y();

                        //TESTING PURPOSES
                        Console.WriteLine("FROM POSITION : X -" + start_x + " Y - " + start_y);
                    }
                    else
                    {
                        //TEST
                        Console.WriteLine("..invalid tile to move..");
                    }
                }
            }
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
            current_player = 1;
            Console.WriteLine("PLAYER " + current_player + " MOVE");

            //activate buttons
            for (int i=0;i<8;i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //add to form
                    Controls.Add(board[i, j]);
                }
            }
        }
    }

    //storage for tile data
    public class tile
    {
        bool king;
        int x;
        int y;
        int player;
        public tile(int x, int y)
        {
            //init blank tile
            king = false;
            this.x = x;
            this.y = y;
            player = 0;
        }

        //delete piece when taken
        public void empty()
        {
            player = 0;
            king = false;
        }

        //SET & GET METHODS
        public int get_x()
        {
            return x;
        }

        public int get_y()
        {
            return y;
        }

        public int get_player()
        {
            return player;
        }
        public void set_player(int player)
        {
            this.player = player;
        }

        public bool get_king()
        {
            return king;
        }
        public void set_king(bool king)
        {
            this.king = king;
        }
    }
}