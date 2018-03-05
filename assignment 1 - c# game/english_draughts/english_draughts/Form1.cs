using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Media;

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
        //game status
        private string status;
        private int current_player;
        private bool moving;
        //move coordinates
        private int start_x;
        private int start_y;
        private int finish_x;
        private int finish_y;
        //game pieces
        private int board_size;
        private Button[][] board;
        //user data
        private string player1_name;
        private string player2_name;
        //music+sounds
        private SoundPlayer sp;

        public draughts_frm()
        {
            InitializeComponent();

            //change game status
            status = "start";
            moving = false;
            current_player = 0;

            //set up board
            board_size = 8;
            board = new Button[board_size][];
            board = set_game(board);

            //play background music
            //from https://freesound.org/people/FoolBoyMedia/sounds/275673/
            sp = new SoundPlayer();
            sp.SoundLocation = "Resources//melody.wav";
            sp.PlayLooping();
        }

        private void execute_take()
        {
            if (finish_x == (start_x - 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1][start_x - 1].Tag;
                tile second = (tile)board[start_y - 3][start_x - 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y - 1][start_x - 1].Tag = first;
                board[start_y - 3][start_x - 3].Tag = second;

                //change colour
                board[start_y - 1][start_x - 1].BackColor = Color.White;
                board[start_y - 3][start_x - 3].BackColor = Color.White;
                board[start_y - 1][start_x - 1].BackgroundImage = null;
                board[start_y - 3][start_x - 3].BackgroundImage = null;
            }
            else if (finish_x == (start_x - 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1][start_x - 1].Tag;
                tile second = (tile)board[start_y + 3][start_x - 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y + 1][start_x - 1].Tag = first;
                board[start_y + 3][start_x - 3].Tag = second;

                //change colour
                board[start_y + 1][start_x - 1].BackColor = Color.White;
                board[start_y + 3][start_x - 3].BackColor = Color.White;
                board[start_y + 1][start_x - 1].BackgroundImage = null;
                board[start_y + 3][start_x - 3].BackgroundImage = null;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1][start_x + 1].Tag;
                tile second = (tile)board[start_y + 3][start_x + 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y + 1][start_x + 1].Tag = first;
                board[start_y + 3][start_x + 3].Tag = second;

                //change colour
                board[start_y + 1][start_x + 1].BackColor = Color.White;
                board[start_y + 3][start_x + 3].BackColor = Color.White;
                board[start_y + 1][start_x + 1].BackgroundImage = null;
                board[start_y + 3][start_x + 3].BackgroundImage = null;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1][start_x + 1].Tag;
                tile second = (tile)board[start_y - 3][start_x + 3].Tag;

                //empty tiles
                first.empty();
                second.empty();

                //replace tiles
                board[start_y - 1][start_x + 1].Tag = first;
                board[start_y - 3][start_x + 3].Tag = second;

                //change colour
                board[start_y - 1][start_x + 1].BackColor = Color.White;
                board[start_y - 3][start_x + 3].BackColor = Color.White;
                board[start_y - 1][start_x + 1].BackgroundImage = null;
                board[start_y - 3][start_x + 3].BackgroundImage = null;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1][start_x - 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y - 1][start_x - 1].Tag = first;

                //change colour
                board[start_y - 1][start_x - 1].BackColor = Color.White;
                board[start_y - 1][start_x - 1].BackgroundImage = null;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1][start_x - 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y + 1][start_x - 1].Tag = first;

                //change colour
                board[start_y + 1][start_x - 1].BackColor = Color.White;
                board[start_y + 1][start_x - 1].BackgroundImage = null;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1][start_x + 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y + 1][start_x + 1].Tag = first;

                //change colour
                board[start_y + 1][start_x + 1].BackColor = Color.White;
                board[start_y + 1][start_x + 1].BackgroundImage = null;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1][start_x + 1].Tag;

                //empty tiles
                first.empty();

                //replace tiles
                board[start_y - 1][start_x + 1].Tag = first;

                //change colour
                board[start_y - 1][start_x + 1].BackColor = Color.White;
                board[start_y - 1][start_x + 1].BackgroundImage = null;
            }
        }

        private bool valid_move(tile start_tag)
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
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
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
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
        }

        private bool valid_take(tile finish_tag, tile start_tag)
        {
            //get finish x and y
            finish_x = finish_tag.get_x();
            finish_y = finish_tag.get_y();

            if (finish_x == (start_x - 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1][start_x - 1].Tag;
                tile second = (tile)board[start_y - 3][start_x - 3].Tag;

                //check valid intermediate tile
                tile intermediate = (tile)board[start_y - 2][start_x - 2].Tag;
                if(intermediate.get_player() != 0)
                {
                    return false;
                }

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if(!(start_tag.get_king()) && current_player == 1)
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x - 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1][start_x - 1].Tag;
                tile second = (tile)board[start_y + 3][start_x - 3].Tag;

                //check valid intermediate tile
                tile intermediate = (tile)board[start_y + 2][start_x - 2].Tag;
                if (intermediate.get_player() != 0)
                {
                    return false;
                }

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(start_tag.get_king()) && current_player == 1)
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y + 4))
            {
                //get tiles
                tile first = (tile)board[start_y + 1][start_x + 1].Tag;
                tile second = (tile)board[start_y + 3][start_x + 3].Tag;

                //check valid intermediate tile
                tile intermediate = (tile)board[start_y + 2][start_x + 2].Tag;
                if (intermediate.get_player() != 0)
                {
                    return false;
                }

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(start_tag.get_king()) && current_player == 2)
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 4) && finish_y == (start_y - 4))
            {
                //get tiles
                tile first = (tile)board[start_y - 1][start_x + 1].Tag;
                tile second = (tile)board[start_y - 3][start_x + 3].Tag;

                //check valid intermediate tile
                tile intermediate = (tile)board[start_y - 2][start_x + 2].Tag;
                if (intermediate.get_player() != 0)
                {
                    return false;
                }

                //check if actual take
                if (first.get_player() == 0 || second.get_player() == 0)
                {
                    return false;
                }

                //check if king
                if (!(start_tag.get_king()) && current_player == 2)
                {
                    return false;
                }

                return true;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1][start_x + 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if(!(current_player == 1))
                {
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                }

                return true;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1][start_x - 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 2))
                {
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                }

                return true;
            }
            else if (finish_x == (start_x + 2) && finish_y == (start_y - 2))
            {
                //get tile
                tile first = (tile)board[start_y - 1][start_x + 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 1))
                {
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                }

                return true;
            }
            else if (finish_x == (start_x - 2) && finish_y == (start_y + 2))
            {
                //get tile
                tile first = (tile)board[start_y + 1][ start_x - 1].Tag;

                //check if actual take
                if (first.get_player() == 0)
                {
                    return false;
                }

                //if standard forward take
                if (!(current_player == 2))
                {
                    //check if king
                    if (!(start_tag.get_king()))
                    {
                        return false;
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        private int[] count_tiles()
        {

            //count number of tiles of each player
            int[] teams = new int[6] {0,0,0,0,0,0};
            for(int i=0;i< board_size; i++)
            {
                for(int j=0;j< board_size; j++)
                {
                    //get tile
                    tile current_tile = (tile)board[i][j].Tag;
                    
                    //get player
                    int player = current_tile.get_player();
                    switch(player)
                    {
                        case 1:
                            //if player 1
                            teams[0]++;

                            //check if king
                            if (current_tile.get_king())
                            {
                                //
                                teams[2]++;
                            }

                            //check can move
                            if (current_tile.can_move(board,board_size))
                            {
                                teams[4]++;
                            }
                            break;
                        case 2:
                            //if player 2
                            teams[1]++;

                            //check if king
                            if (current_tile.get_king())
                            {
                                //
                                teams[3]++;
                            }

                            //check can move
                            if (current_tile.can_move(board, board_size))
                            {
                                teams[5]++;
                            }

                            break;
                    }
                }
            }

            //return number checkers on teams
            return teams;
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
                        Button start = board[start_y][start_x];
                        tile start_tag = (tile)start.Tag;

                        //check move or take
                        bool take = false;
                        if(valid_take(finish_tag, start_tag))
                        {
                            take = true;
                        }
                        bool move = false;
                        if (valid_move(start_tag))
                        {
                            move = true;
                        }

                        //execute if valid/move else cancel operation
                        if (take)
                        {
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
                            board[start_y][start_x].BackColor = Color.White;
                            board[start_y][start_x].BackgroundImage = null;

                            //change finish tile colour
                            if (current_player == 2)
                            {
                                //set tile colours
                                board[finish_y][finish_x].BackColor = Color.Black;
                                board[finish_y][finish_x].BackgroundImage = Image.FromFile("Resources//black checker.png");
                                board[finish_y][finish_x].BackgroundImageLayout = ImageLayout.Stretch;

                                //king check
                                if (finish_x == 0)
                                {
                                    //change to king
                                    finish_tag.set_king(true);
                                }
                            }
                            else
                            {
                                //set tile colours
                                board[finish_y][finish_x].BackColor = Color.Red;
                                board[finish_y][finish_x].BackgroundImage = Image.FromFile("Resources//red checker.png");
                                board[finish_y][finish_x].BackgroundImageLayout = ImageLayout.Stretch;

                                //king check
                                if (finish_x == (board_size - 1))
                                {
                                    //change to king
                                    finish_tag.set_king(true);
                                }
                            }

                            //replace tiles
                            board[finish_y][finish_x].Tag = finish_tag;
                            board[start_y][start_x].Tag = start_tag;
                        }
                        else if (move)
                        {
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
                            board[start_y][start_x].BackColor = Color.White;
                            board[start_y][start_x].BackgroundImage = null;

                            //change turn
                            if (current_player == 2)
                            {
                                //change finish tile colour
                                board[finish_y][finish_x].BackColor = Color.Black;
                                board[finish_y][finish_x].BackgroundImage = Image.FromFile("Resources//black checker.png");
                                board[finish_y][finish_x].BackgroundImageLayout = ImageLayout.Stretch;

                                //king check
                                if (finish_x == 0)
                                {
                                    //change to king
                                    finish_tag.set_king(true);
                                }

                                //change turn
                                current_player = 1;
                                player1_lbl.ForeColor = Color.Blue;
                                player2_lbl.ForeColor = Color.Black;
                            }
                            else
                            {
                                //change finish tile colour
                                board[finish_y][finish_x].BackColor = Color.Red;
                                board[finish_y][finish_x].BackgroundImage = Image.FromFile("Resources//red checker.png");
                                board[finish_y][finish_x].BackgroundImageLayout = ImageLayout.Stretch;

                                //king check
                                if (finish_x == (board_size - 1))
                                {
                                    //change to king
                                    finish_tag.set_king(true);
                                }

                                //change turn
                                current_player = 2;
                                player2_lbl.ForeColor = Color.Blue;
                                player1_lbl.ForeColor = Color.Black;
                            }

                            //replace tiles
                            board[finish_y][ finish_x].Tag = finish_tag;
                            board[start_y][ start_x].Tag = start_tag;
                        }
                        else
                        {
                            //cancel move
                            moving = false;
                        }

                        //win check
                        int[] tile_data = count_tiles();
                        if(tile_data[4] == 0)
                        {
                            //player 1 cannot move
                            status = "win";
                            win_text(2);
                        }
                        else if(tile_data[5] == 0)
                        {
                            //player 2 cannot move
                            status = "win";
                            win_text(1);
                        }
                    }
                    else
                    {
                        //cancel move
                        moving = false;
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
                    }
                }
            }
        }

        private void add_highscore(int winner)
        {
            //get tiles 
            int[] tile_data = count_tiles();

            //add high score to text file in resources directory
            try
            {
                //get local dir
                string path = Directory.GetCurrentDirectory();

                //check file exists
                if (!File.Exists(path + "//highscores.txt"))
                {
                    using (StreamWriter sw = File.CreateText(path + "//highscores.txt"))
                    {
                        sw.WriteLine("");
                    }
                }

                //add highscore to file file
                using (StreamWriter sw = File.AppendText(path + "//highscores.txt"))
                {
                    string line = "";

                    if (winner == 1)
                    {
                        line = player1_name + " beat " + player2_name + " on " + DateTime.Now + " with "+tile_data[0]+" tiles left on ("+board_size+"x"+board_size+") board";
                    }
                    else
                    {
                        line = player2_name + " beat " + player1_name + " on " + DateTime.Now + " with " + tile_data[1] + " tiles left on (" + board_size + "x" + board_size + ") board";
                    }

                    sw.WriteLine(line);
                }

                view_highscores();
            }
            catch (Exception e)
            {
                //error
            }
        }

        private void view_highscores()
        {
            //
            try
            {
                //get local dir
                string path = Directory.GetCurrentDirectory();
                DialogResult result;


                //check file exists
                if (!File.Exists(path + "//highscores.txt"))
                {
                    using (StreamWriter sw = File.CreateText(path + "//highscores.txt"))
                    {
                        sw.WriteLine("");
                    }
                    
                    result = MessageBox.Show("No highscores!", "HighScores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    using (StreamReader sr = new StreamReader(path + "//highscores.txt"))
                    {
                        string line = "";
                        string message = "";

                        while ((line = sr.ReadLine()) != null)
                        {
                            message = message + line + "\n";
                        }

                        result = MessageBox.Show(message, "HighScores", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                //error
            }
        }

        /* 
         * change text of title label with appropriate message
         * on loss/win of game
         */
        private void win_text(int winner)
        {
            switch (status){
                case "start":
                case "game":
                    //modify title label with standard title
                    title_lbl.Text = "Draughts";

                    //reset turn labels
                    player1_lbl.ForeColor = Color.Blue;
                    player2_lbl.ForeColor = Color.Black;

                    break;
                case "win":
                    //play win sound
                    sp.Stop();
                    string path = Directory.GetCurrentDirectory();
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(path+"//Resources//win.wav");
                    player.Play();
                    //sound from https://freesound.org/people/fins/sounds/171670/

                    //modify title label with win message
                    if (winner == 1)
                    {
                        title_lbl.Text = player1_name + " Wins!!";
                    }
                    else
                    {
                        title_lbl.Text = player2_name + " Wins!!";
                    }

                    //add highscore
                    add_highscore(winner);

                    //reset turn labels
                    player2_lbl.ForeColor = Color.Black;
                    player1_lbl.ForeColor = Color.Black;

                    break;
            }
        }

        private Button[][] set_game(Button[][] in_board)
        {
            //resize array if international draughts size
            if (board_size == 10)
            {
                //change form size
                this.Width = 700;
                this.Height = 700;

                //change label positions
                player1_lbl.Location = new Point(10,600);
                player2_lbl.Location = new Point(550, 600);
            }
            else
            {
                //change form size
                this.Width = 600;
                this.Height = 600;

                //change label positions
                player1_lbl.Location = new Point(10,500);
                player2_lbl.Location = new Point(450, 500);
            }

            //button init
            bool dark_tile = false;
            in_board = new Button[board_size][];
            for (int i = 0; i < board_size; i++)
            {
                in_board[i] = new Button[board_size];
                for (int j = 0; j < board_size; j++)
                {
                    //init button
                    in_board[i][j] = new Button();

                    //set position
                    in_board[i][j].SetBounds(75 + (50 * j), 90 + (50 * i), 50, 50);

                    //set data
                    tile current_tag = new tile(j, i);

                    //set colour
                    if (dark_tile)
                    {
                        if (j == 0 || j == 1 || j == 2 || j == 3)
                        {
                            if (j == 3 && board_size == 10)
                            {
                                //PLAYER 1
                                //colour
                                in_board[i][j].BackColor = Color.Red;
                                in_board[i][j].BackgroundImage = Image.FromFile("Resources//red checker.png");
                                in_board[i][j].BackgroundImageLayout = ImageLayout.Stretch;

                                //player
                                current_tag.set_player(1);
                            }
                            else if (j == 3 && board_size != 10)
                            {
                                //colour
                                in_board[i][j].BackColor = Color.White;
                                in_board[i][j].BackgroundImage = null;
                            }
                            else
                            {
                                //PLAYER 1
                                //colour
                                in_board[i][j].BackColor = Color.Red;
                                in_board[i][j].BackgroundImage = Image.FromFile("Resources//red checker.png");
                                in_board[i][j].BackgroundImageLayout = ImageLayout.Stretch;

                                //player
                                current_tag.set_player(1);
                            }
                        }
                        else if (j == 5 || j == 6 || j == 7 || j == 8 || j == 9)
                        {
                            if (j == 6 && board_size == 10)
                            {
                                //PLAYER 2
                                //colour
                                in_board[i][j].BackColor = Color.Black;
                                in_board[i][j].BackgroundImage = Image.FromFile("Resources//black checker.png");
                                in_board[i][j].BackgroundImageLayout = ImageLayout.Stretch;

                                //player
                                current_tag.set_player(2);
                            }
                            else if (j == 5 && board_size == 10)
                            {
                                //colour
                                in_board[i][j].BackColor = Color.White;
                                in_board[i][j].BackgroundImage = null;
                            }
                            else
                            {
                                //PLAYER 2
                                //colour
                                in_board[i][j].BackColor = Color.Black;
                                in_board[i][j].BackgroundImage = Image.FromFile("Resources//black checker.png");
                                in_board[i][j].BackgroundImageLayout = ImageLayout.Stretch;

                                //player
                                current_tag.set_player(2);
                            }
                        }
                        else
                        {
                            //colour
                            in_board[i][j].BackColor = Color.White;
                            in_board[i][j].BackgroundImage = null;
                        }
                        //boolean activator
                        dark_tile = false;
                    }
                    else
                    {
                        //colour
                        in_board[i][j].BackColor = Color.Blue;

                        //boolean activator
                        dark_tile = true;
                    }

                    //add tile
                    in_board[i][j].Tag = current_tag;

                    //add click event
                    in_board[i][j].Click += new EventHandler(this.btnEvent_Click);
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

            return in_board;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("English & International Draughts in C# by Deren Vural & Gregor Taylor (c) 2018", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Game Rules: "+ Environment.NewLine + Environment.NewLine +
            "A move: A simple move consist of a player moving one of their pieces diagonally onto an adjacent unoccupied white tile.Once a piece becomes a Crown it can not only move forward but backwards as well." +Environment.NewLine+ Environment.NewLine +
            "A jump: A jump consists of moving a piece which is diagonally adjacent to an opponent’s piece, to an empty tile directly beyond it in the same direction.When a tile has been jumped over, it is then removed from the game." + Environment.NewLine + Environment.NewLine +
            "Multiple Jumps: A multiple jump is possible if after jumping an opponent’s piece, another piece is able to be jumped even if it is in a different diagonal direction." + Environment.NewLine + Environment.NewLine +
            "Crowns: If a piece reaches the other end of the board it becomes a Crown, this gives the piece the ability to move both forward and backward." + Environment.NewLine + Environment.NewLine +
            "End Game: A player can win the game by leaving your opponent with no legal next move or by having jumped and removed all of their pieces.The game will end as a draw if neither player can play a legal move.",
            "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //change game status
            status = "game";
            current_player = 1;

            //play background music
            //from https://freesound.org/people/FoolBoyMedia/sounds/275673/
            sp.Stop();
            sp.SoundLocation = "Resources//melody.wav";
            sp.PlayLooping();

            //reset buttons
            Controls.OfType<Button>().ToList().ForEach(btn => btn.Dispose());
            //from https://stackoverflow.com/questions/27910364/remove-all-buttons-from-panel
            board = set_game(board);

            //reset turn & title
            win_text(0);

            //get names of players & set labels
            //get player 1 name
            player1_name = Microsoft.VisualBasic.Interaction.InputBox("Enter player 1 name:", "Player 1", "Default", -1, -1);
            if (player1_name.Equals(""))
            {
                player1_lbl.Text = "Player 1";
                player1_name = "Player 1";
            }
            else
            {
                player1_lbl.Text = player1_name;
            }

            //get loser name
            player2_name = Microsoft.VisualBasic.Interaction.InputBox("Enter player 2 name:", "Player 2", "Default", -1, -1);
            if (player2_name.Equals(""))
            {
                player2_lbl.Text = "Player 2";
                player2_name = "Player 2";
            }
            else
            {
                player2_lbl.Text = player2_name;
            }

            //activate buttons
            for (int i=0;i< board_size; i++)
            {
                for (int j = 0; j < board_size; j++)
                {
                    //add to form
                    Controls.Add(board[i][j]);
                }
            }
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            view_highscores();
        }

        private void draughts_frm_Load(object sender, EventArgs e)
        {
            //
        }

        private void english8x8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get sender
            var current_item = sender as ToolStripMenuItem;

            //if valid
            if (current_item != null)
            {
                //uncheck all other options
                ((ToolStripMenuItem)current_item.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach(item =>
                {
                    item.Checked = false;
                });

                //Check the current item
                current_item.Checked = true;
                board_size = 8;
            }
        }

        private void international10x10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //get sender
            var current_item = sender as ToolStripMenuItem;

            //if valid
            if (current_item != null)
            {
                //uncheck all other options
                ((ToolStripMenuItem)current_item.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>().ToList().ForEach(item =>
                {
                    item.Checked = false;
                });

                //Check the current item
                current_item.Checked = true;
                board_size = 10;
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

        //check if can move to surrounding tiles/take
        public bool can_move(Button[][] board, int board_size)
        {
            //can move/take/long-take up left
            if (x > 0 && y > 0)
            {
                //move
                tile current_tag = (tile)board[x - 1][y - 1].Tag;
                if (current_tag.get_player() == 0)
                {
                    if (player == 1 && king)
                    {
                        return true;
                    }
                    else if (player == 2)
                    {
                        return true;
                    }
                }
                //take
                if (x > 1 && y > 1)
                {
                    current_tag = (tile)board[x - 2][y - 2].Tag;
                    tile current_middle_tag = (tile)board[x - 1][y - 1].Tag;
                    if (current_tag.get_player() == 0 && (current_middle_tag.get_player() != player || current_middle_tag.get_player() != 0))
                    {
                        if (player == 1 && king)
                        {
                            return true;
                        }
                        else if (player == 2)
                        {
                            return true;
                        }
                    }
                }
            }

            //can move/take/long-take up right
            if (x < (board_size - 1) && y > 0)
            {
                //move
                tile current_tag = (tile)board[x + 1][y - 1].Tag;
                if (current_tag.get_player() != 0)
                {
                    if (player == 2 && king)
                    {
                        return true;
                    }
                    else if (player == 1)
                    {
                        return true;
                    }
                }
                //take
                if (x < 6 && y > 1)
                {
                    current_tag = (tile)board[x + 2][y - 2].Tag;
                    tile current_middle_tag = (tile)board[x + 1][y - 1].Tag;
                    if (current_tag.get_player() == 0 && (current_middle_tag.get_player() != player || current_middle_tag.get_player() != 0))
                    {
                        if (player == 2 && king)
                        {
                            return true;
                        }
                        else if (player == 1)
                        {
                            return true;
                        }
                    }
                }
            }

            //can move/take/long-take down left
            if (x > 0 && y < (board_size - 1))
            {
                //move
                tile current_tag = (tile)board[x - 1][y + 1].Tag;
                if (current_tag.get_player() == 0)
                {
                    if (player == 1 && king)
                    {
                        return true;
                    }
                    else if (player == 2)
                    {
                        return true;
                    }
                }
                //take
                if (x > 1 && y < (board_size - 2))
                {
                    current_tag = (tile)board[x - 2][y + 2].Tag;
                    tile current_middle_tag = (tile)board[x - 1][y + 1].Tag;
                    if (current_tag.get_player() == 0 && (current_middle_tag.get_player() != player || current_middle_tag.get_player() != 0))
                    {
                        if (player == 1 && king)
                        {
                            return true;
                        }
                        else if (player == 2)
                        {
                            return true;
                        }
                    }
                }
            }

            //can move/take/long-take down right
            if (x < (board_size - 1) && y < (board_size - 1))
            {
                //move
                tile current_tag = (tile)board[x + 1][y + 1].Tag;
                if (current_tag.get_player() == 0)
                {
                    if (player == 2 && king)
                    {
                        return true;
                    }
                    else if (player == 1)
                    {
                        return true;
                    }
                }
                //take
                if (x < (board_size - 2) && y < (board_size - 2))
                {
                    current_tag = (tile)board[x + 2][y + 2].Tag;
                    tile current_middle_tag = (tile)board[x + 1][y + 1].Tag;
                    if (current_tag.get_player() == 0 && (current_middle_tag.get_player() != player || current_middle_tag.get_player() != 0))
                    {
                        if (player == 2 && king)
                        {
                            return true;
                        }
                        else if (player == 1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
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