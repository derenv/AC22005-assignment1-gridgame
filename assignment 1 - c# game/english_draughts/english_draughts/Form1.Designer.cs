namespace english_draughts
{
    partial class draughts_frm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(draughts_frm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.english8x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.international10x10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.title_lbl = new System.Windows.Forms.Label();
            this.player1_lbl = new System.Windows.Forms.Label();
            this.player2_lbl = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(737, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.boardSizeToolStripMenuItem,
            this.highScoresToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // boardSizeToolStripMenuItem
            // 
            this.boardSizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.english8x8ToolStripMenuItem,
            this.international10x10ToolStripMenuItem});
            this.boardSizeToolStripMenuItem.Name = "boardSizeToolStripMenuItem";
            this.boardSizeToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.boardSizeToolStripMenuItem.Text = "Board Size";
            // 
            // english8x8ToolStripMenuItem
            // 
            this.english8x8ToolStripMenuItem.Checked = true;
            this.english8x8ToolStripMenuItem.CheckOnClick = true;
            this.english8x8ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.english8x8ToolStripMenuItem.Name = "english8x8ToolStripMenuItem";
            this.english8x8ToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.english8x8ToolStripMenuItem.Text = "English (8x8)";
            this.english8x8ToolStripMenuItem.Click += new System.EventHandler(this.english8x8ToolStripMenuItem_Click);
            // 
            // international10x10ToolStripMenuItem
            // 
            this.international10x10ToolStripMenuItem.CheckOnClick = true;
            this.international10x10ToolStripMenuItem.Name = "international10x10ToolStripMenuItem";
            this.international10x10ToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.international10x10ToolStripMenuItem.Text = "International (10x10)";
            this.international10x10ToolStripMenuItem.Click += new System.EventHandler(this.international10x10ToolStripMenuItem_Click);
            // 
            // highScoresToolStripMenuItem
            // 
            this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
            this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(163, 26);
            this.highScoresToolStripMenuItem.Text = "High Scores";
            this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // title_lbl
            // 
            this.title_lbl.AutoSize = true;
            this.title_lbl.Font = new System.Drawing.Font("Bernard MT Condensed", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title_lbl.Location = new System.Drawing.Point(227, 28);
            this.title_lbl.Name = "title_lbl";
            this.title_lbl.Size = new System.Drawing.Size(199, 57);
            this.title_lbl.TabIndex = 1;
            this.title_lbl.Text = "Draughts";
            // 
            // player1_lbl
            // 
            this.player1_lbl.AutoSize = true;
            this.player1_lbl.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1_lbl.Location = new System.Drawing.Point(12, 597);
            this.player1_lbl.Name = "player1_lbl";
            this.player1_lbl.Size = new System.Drawing.Size(161, 38);
            this.player1_lbl.TabIndex = 2;
            this.player1_lbl.Text = "Player 1";
            // 
            // player2_lbl
            // 
            this.player2_lbl.AutoSize = true;
            this.player2_lbl.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2_lbl.Location = new System.Drawing.Point(564, 597);
            this.player2_lbl.Name = "player2_lbl";
            this.player2_lbl.Size = new System.Drawing.Size(161, 38);
            this.player2_lbl.TabIndex = 3;
            this.player2_lbl.Text = "Player 2";
            // 
            // draughts_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 653);
            this.Controls.Add(this.player2_lbl);
            this.Controls.Add(this.player1_lbl);
            this.Controls.Add(this.title_lbl);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "draughts_frm";
            this.Text = "Draughts";
            this.Load += new System.EventHandler(this.draughts_frm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label title_lbl;
        private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
        private System.Windows.Forms.Label player1_lbl;
        private System.Windows.Forms.Label player2_lbl;
        private System.Windows.Forms.ToolStripMenuItem boardSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem english8x8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem international10x10ToolStripMenuItem;
    }
}

