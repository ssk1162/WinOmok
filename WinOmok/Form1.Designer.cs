namespace WinOmok
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            파일ToolStripMenuItem = new ToolStripMenuItem();
            새로만들기ToolStripMenuItem = new ToolStripMenuItem();
            저장ToolStripMenuItem = new ToolStripMenuItem();
            복기ToolStripMenuItem = new ToolStripMenuItem();
            다시시작ToolStripMenuItem = new ToolStripMenuItem();
            종료ToolStripMenuItem = new ToolStripMenuItem();
            보기ToolStripMenuItem = new ToolStripMenuItem();
            이미지ToolStripMenuItem = new ToolStripMenuItem();
            그리기ToolStripMenuItem = new ToolStripMenuItem();
            모드ToolStripMenuItem = new ToolStripMenuItem();
            싱글ToolStripMenuItem = new ToolStripMenuItem();
            네트워크ToolStripMenuItem = new ToolStripMenuItem();
            수순ToolStripMenuItem = new ToolStripMenuItem();
            수순표시ToolStripMenuItem = new ToolStripMenuItem();
            수순표시안함ToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnSend = new Button();
            listChat = new ListBox();
            txtChat = new TextBox();
            label2 = new Label();
            txtNick = new TextBox();
            btnSerGame = new Button();
            btnConn = new Button();
            btnClose = new Button();
            lbSt = new Label();
            btnCh = new Button();
            btn1 = new Button();
            btn2 = new Button();
            button1 = new Button();
            button3 = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { 파일ToolStripMenuItem, 보기ToolStripMenuItem, 모드ToolStripMenuItem, 수순ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1091, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // 파일ToolStripMenuItem
            // 
            파일ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 새로만들기ToolStripMenuItem, 저장ToolStripMenuItem, 복기ToolStripMenuItem, 다시시작ToolStripMenuItem, 종료ToolStripMenuItem });
            파일ToolStripMenuItem.Name = "파일ToolStripMenuItem";
            파일ToolStripMenuItem.Size = new Size(64, 29);
            파일ToolStripMenuItem.Text = "파일";
            // 
            // 새로만들기ToolStripMenuItem
            // 
            새로만들기ToolStripMenuItem.Name = "새로만들기ToolStripMenuItem";
            새로만들기ToolStripMenuItem.Size = new Size(204, 34);
            새로만들기ToolStripMenuItem.Text = "새로만들기";
            새로만들기ToolStripMenuItem.Click += 새로만들기ToolStripMenuItem_Click;
            // 
            // 저장ToolStripMenuItem
            // 
            저장ToolStripMenuItem.Name = "저장ToolStripMenuItem";
            저장ToolStripMenuItem.Size = new Size(204, 34);
            저장ToolStripMenuItem.Text = "저장";
            저장ToolStripMenuItem.Click += 저장ToolStripMenuItem_Click;
            // 
            // 복기ToolStripMenuItem
            // 
            복기ToolStripMenuItem.Name = "복기ToolStripMenuItem";
            복기ToolStripMenuItem.Size = new Size(204, 34);
            복기ToolStripMenuItem.Text = "복기";
            복기ToolStripMenuItem.Click += 복기ToolStripMenuItem_Click;
            // 
            // 다시시작ToolStripMenuItem
            // 
            다시시작ToolStripMenuItem.Name = "다시시작ToolStripMenuItem";
            다시시작ToolStripMenuItem.Size = new Size(204, 34);
            다시시작ToolStripMenuItem.Text = "다시시작";
            다시시작ToolStripMenuItem.Click += 다시시작ToolStripMenuItem_Click;
            // 
            // 종료ToolStripMenuItem
            // 
            종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            종료ToolStripMenuItem.Size = new Size(204, 34);
            종료ToolStripMenuItem.Text = "종료";
            종료ToolStripMenuItem.Click += 종료ToolStripMenuItem_Click;
            // 
            // 보기ToolStripMenuItem
            // 
            보기ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 이미지ToolStripMenuItem, 그리기ToolStripMenuItem });
            보기ToolStripMenuItem.Name = "보기ToolStripMenuItem";
            보기ToolStripMenuItem.Size = new Size(64, 29);
            보기ToolStripMenuItem.Text = "보기";
            // 
            // 이미지ToolStripMenuItem
            // 
            이미지ToolStripMenuItem.Checked = true;
            이미지ToolStripMenuItem.CheckState = CheckState.Checked;
            이미지ToolStripMenuItem.Name = "이미지ToolStripMenuItem";
            이미지ToolStripMenuItem.Size = new Size(168, 34);
            이미지ToolStripMenuItem.Text = "이미지";
            이미지ToolStripMenuItem.Click += 이미지ToolStripMenuItem_Click;
            // 
            // 그리기ToolStripMenuItem
            // 
            그리기ToolStripMenuItem.Name = "그리기ToolStripMenuItem";
            그리기ToolStripMenuItem.Size = new Size(168, 34);
            그리기ToolStripMenuItem.Text = "그리기";
            그리기ToolStripMenuItem.Click += 그리기ToolStripMenuItem_Click;
            // 
            // 모드ToolStripMenuItem
            // 
            모드ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 싱글ToolStripMenuItem, 네트워크ToolStripMenuItem });
            모드ToolStripMenuItem.Name = "모드ToolStripMenuItem";
            모드ToolStripMenuItem.Size = new Size(64, 29);
            모드ToolStripMenuItem.Text = "모드";
            // 
            // 싱글ToolStripMenuItem
            // 
            싱글ToolStripMenuItem.Checked = true;
            싱글ToolStripMenuItem.CheckState = CheckState.Checked;
            싱글ToolStripMenuItem.Name = "싱글ToolStripMenuItem";
            싱글ToolStripMenuItem.Size = new Size(186, 34);
            싱글ToolStripMenuItem.Text = "싱글";
            싱글ToolStripMenuItem.Click += 싱글ToolStripMenuItem_Click;
            // 
            // 네트워크ToolStripMenuItem
            // 
            네트워크ToolStripMenuItem.Name = "네트워크ToolStripMenuItem";
            네트워크ToolStripMenuItem.Size = new Size(186, 34);
            네트워크ToolStripMenuItem.Text = "네트워크";
            네트워크ToolStripMenuItem.Click += 네트워크ToolStripMenuItem_Click;
            // 
            // 수순ToolStripMenuItem
            // 
            수순ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 수순표시ToolStripMenuItem, 수순표시안함ToolStripMenuItem });
            수순ToolStripMenuItem.Name = "수순ToolStripMenuItem";
            수순ToolStripMenuItem.Size = new Size(64, 29);
            수순ToolStripMenuItem.Text = "수순";
            // 
            // 수순표시ToolStripMenuItem
            // 
            수순표시ToolStripMenuItem.Checked = true;
            수순표시ToolStripMenuItem.CheckState = CheckState.Checked;
            수순표시ToolStripMenuItem.Name = "수순표시ToolStripMenuItem";
            수순표시ToolStripMenuItem.Size = new Size(228, 34);
            수순표시ToolStripMenuItem.Text = "수순표시";
            수순표시ToolStripMenuItem.Click += 수순표시ToolStripMenuItem_Click;
            // 
            // 수순표시안함ToolStripMenuItem
            // 
            수순표시안함ToolStripMenuItem.Name = "수순표시안함ToolStripMenuItem";
            수순표시안함ToolStripMenuItem.Size = new Size(228, 34);
            수순표시안함ToolStripMenuItem.Text = "수순표시 안함";
            수순표시안함ToolStripMenuItem.Click += 수순표시안함ToolStripMenuItem_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSend, 6, 2);
            tableLayoutPanel1.Controls.Add(listChat, 4, 1);
            tableLayoutPanel1.Controls.Add(txtChat, 4, 2);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(txtNick, 1, 0);
            tableLayoutPanel1.Controls.Add(btnSerGame, 4, 0);
            tableLayoutPanel1.Controls.Add(btnConn, 5, 0);
            tableLayoutPanel1.Controls.Add(btnClose, 6, 0);
            tableLayoutPanel1.Controls.Add(lbSt, 3, 0);
            tableLayoutPanel1.Controls.Add(btnCh, 2, 0);
            tableLayoutPanel1.Controls.Add(btn1, 0, 2);
            tableLayoutPanel1.Controls.Add(btn2, 1, 2);
            tableLayoutPanel1.Controls.Add(button1, 2, 2);
            tableLayoutPanel1.Controls.Add(button3, 3, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 33);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 620F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1091, 702);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            tableLayoutPanel1.SetColumnSpan(panel1, 4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 43);
            panel1.Name = "panel1";
            panel1.Size = new Size(614, 614);
            panel1.TabIndex = 10;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(933, 663);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(155, 34);
            btnSend.TabIndex = 14;
            btnSend.Text = "전송";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // listChat
            // 
            tableLayoutPanel1.SetColumnSpan(listChat, 3);
            listChat.Dock = DockStyle.Fill;
            listChat.FormattingEnabled = true;
            listChat.ItemHeight = 25;
            listChat.Location = new Point(623, 43);
            listChat.Name = "listChat";
            listChat.Size = new Size(465, 614);
            listChat.TabIndex = 15;
            // 
            // txtChat
            // 
            tableLayoutPanel1.SetColumnSpan(txtChat, 2);
            txtChat.Location = new Point(623, 663);
            txtChat.Multiline = true;
            txtChat.Name = "txtChat";
            txtChat.Size = new Size(304, 34);
            txtChat.TabIndex = 13;
            txtChat.KeyDown += txtChat_KeyDown;
            // 
            // label2
            // 
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(149, 40);
            label2.TabIndex = 9;
            label2.Text = "닉네임";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNick
            // 
            txtNick.Location = new Point(158, 3);
            txtNick.Multiline = true;
            txtNick.Name = "txtNick";
            txtNick.Size = new Size(149, 34);
            txtNick.TabIndex = 7;
            // 
            // btnSerGame
            // 
            btnSerGame.Location = new Point(623, 3);
            btnSerGame.Name = "btnSerGame";
            btnSerGame.Size = new Size(149, 34);
            btnSerGame.TabIndex = 16;
            btnSerGame.Text = "게임 준비";
            btnSerGame.UseVisualStyleBackColor = true;
            btnSerGame.Click += btnGame_Click;
            // 
            // btnConn
            // 
            btnConn.BackColor = Color.White;
            btnConn.Location = new Point(778, 3);
            btnConn.Name = "btnConn";
            btnConn.Size = new Size(149, 34);
            btnConn.TabIndex = 12;
            btnConn.Text = "연결";
            btnConn.UseVisualStyleBackColor = false;
            btnConn.Click += btnConn_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Location = new Point(933, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(149, 34);
            btnClose.TabIndex = 12;
            btnClose.Text = "연결해제";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lbSt
            // 
            lbSt.Location = new Point(468, 0);
            lbSt.Name = "lbSt";
            lbSt.Size = new Size(149, 40);
            lbSt.TabIndex = 9;
            lbSt.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCh
            // 
            btnCh.Location = new Point(313, 3);
            btnCh.Name = "btnCh";
            btnCh.Size = new Size(149, 34);
            btnCh.TabIndex = 16;
            btnCh.Text = "축 연결";
            btnCh.UseVisualStyleBackColor = true;
            btnCh.Click += btnCh_Click;
            // 
            // btn1
            // 
            btn1.Location = new Point(3, 663);
            btn1.Name = "btn1";
            btn1.Size = new Size(149, 36);
            btn1.TabIndex = 17;
            btn1.Text = "원점ON";
            btn1.UseVisualStyleBackColor = true;
            btn1.Click += button1_Click;
            // 
            // btn2
            // 
            btn2.Location = new Point(158, 663);
            btn2.Name = "btn2";
            btn2.Size = new Size(149, 36);
            btn2.TabIndex = 18;
            btn2.Text = "원점 OFF";
            btn2.UseVisualStyleBackColor = true;
            btn2.Click += btn2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(313, 663);
            button1.Name = "button1";
            button1.Size = new Size(149, 36);
            button1.TabIndex = 19;
            button1.Text = "에러리셋";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button3
            // 
            button3.Location = new Point(468, 663);
            button3.Name = "button3";
            button3.Size = new Size(149, 36);
            button3.TabIndex = 20;
            button3.Text = "리셋OFF";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 735);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem 파일ToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private ListBox listChat;
        private TextBox textBox1;
        private Button button2;
        private TextBox textBox3;
        private TextBox txtNick;
        private Label label2;
        private Panel panel1;
        private Button btnConn;
        private ToolStripMenuItem 보기ToolStripMenuItem;
        private ToolStripMenuItem 이미지ToolStripMenuItem;
        private ToolStripMenuItem 그리기ToolStripMenuItem;
        private Button btnSend;
        private TextBox txtChat;
        private ToolStripMenuItem 새로만들기ToolStripMenuItem;
        private ToolStripMenuItem 수순ToolStripMenuItem;
        private ToolStripMenuItem 수순표시ToolStripMenuItem;
        private ToolStripMenuItem 수순표시안함ToolStripMenuItem;
        private ToolStripMenuItem 종료ToolStripMenuItem;
        private ToolStripMenuItem 복기ToolStripMenuItem;
        private ToolStripMenuItem 다시시작ToolStripMenuItem;
        private ToolStripMenuItem 저장ToolStripMenuItem;
        private ToolStripMenuItem 모드ToolStripMenuItem;
        private ToolStripMenuItem 싱글ToolStripMenuItem;
        private ToolStripMenuItem 네트워크ToolStripMenuItem;
        private Button btnSerGame;
        private System.Windows.Forms.Timer timer1;
        private Button btnClose;
        private Label lbSt;
        private Button btnCh;
        private Button btn1;
        private Button btn2;
        private Button button1;
        private Button button3;
    }
}
