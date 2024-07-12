using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml.Linq;
using ChatLlb.Models;
using ACTMULTILib;

namespace WinOmok
{
    public enum STONE { none, black, white };

    public partial class Form1 : Form
    {
        ActEasyIF plc1 = new ActEasyIF();

        int margin = 40;
        int ��Size = 30;
        int ��Size = 28;
        int ȭ��size = 10;

        private Graphics g;
        private Pen pen;
        private Brush wBrush, bBrush;

        private TcpListener listener;
        private TcpClient client;
        private NetworkStream ns;

        private TcpListener _listener;
        private TcpClient _client;
        private NetworkStream _ns;

        STONE[,] �ٵ��� = new STONE[19, 19];

        // ���� ����
        bool btnFlag = false;

        bool flag = false;
        bool imgFlag = true;

        bool sequenceFlag = true;
        bool reviceFlag = false;
        bool gameMode = false;

        bool gameFlag = false;

        bool checkFlag = true;

        bool PlayerFlag = true;

        bool singleFlag = false;

        int stoneCnt = 1;

        int sequence = 0;

        Font font = new Font("���� ���", 6);

        List<Revive> lstRevive = new List<Revive>();
        private string dirName;

        DateTime dateTime;

        public Form1()
        {
            InitializeComponent();

            panel1.BackColor = Color.Orange;
            pen = new Pen(Color.Black);
            bBrush = new SolidBrush(Color.Black);
            wBrush = new SolidBrush(Color.White);

            this.ClientSize = new Size(2 * margin + 18 * ��Size + 465, 2 * margin + 18 * ��Size + menuStrip1.Height + 100);

            txtChat.Enabled = false;
            txtNick.Enabled = false;
            btnConn.Enabled = false;
            btnSend.Enabled = false;
            btnSerGame.Enabled = false;
            btnClose.Enabled = false;

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBoard();
            DrawStones();
        }

        // ���� ����
        private async void btnConn_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnFlag == false)
                {
                    btnConn.BackColor = Color.Green;
                    btnConn.Text = "���� �����ߴ�";
                    txtNick.Enabled = false;

                    listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 60000);
                    listener.Start();

                    client = await listener.AcceptTcpClientAsync();

                    _ = GameClient(client);

                    if (gameMode == true)
                    {
                        _listener = new TcpListener(IPAddress.Parse("172.31.6.25"), 8080);
                        _listener.Start();

                        _client = await _listener.AcceptTcpClientAsync();

                        _ = GameSERClient(_client);

                    }
                    btnFlag = true;

                }
                else if (btnFlag == true)
                {
                    MessageBox.Show("�̹� ����Ǿ�����");
                }
            }
            catch
            {

            }


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            btnConn.BackColor = Color.White;
            btnConn.Text = "����";
            btnSerGame.Text = "���� �غ�";
            btnSerGame.Enabled = false;
            txtNick.Enabled = true;
            
            panel1.Refresh();
            DrawBoard();
        }

        private async Task GameClient(TcpClient client)
        {
            ns = client.GetStream();
            byte[] sizeBuffer = new byte[4];
            int read;

            while (true)
            {
                read = await ns.ReadAsync(sizeBuffer, 0, sizeBuffer.Length);
                if (read == 0) break;

                int size = BitConverter.ToInt32(sizeBuffer);
                byte[] buffer = new byte[size];

                read = await ns.ReadAsync(buffer, 0, buffer.Length);
                if (read == 0) break;

                string message = Encoding.UTF8.GetString(buffer, 0, read);

                var hub = ChatHub.Parse(message);

                if (hub.Result == true)
                {
                    btnSerGame.Enabled = true;
                }
                listChat.Items.Add($"{hub.UserName} : {hub.Message}");
            }

        }

        // �޽��� ����
        private void btnSend_Click(object sender, EventArgs e)
        {
            ns = client.GetStream();

            ChatHub hub = new ChatHub
            {
                UserName = txtNick.Text,
                Message = txtChat.Text
            };

            var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());

            var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

            ns.Write(messageLengthBuffer);
            ns.Write(messageBuffer);
            listChat.Items.Add($"{hub.UserName} : {hub.Message}");
            txtChat.Clear();
        }

        // ���� ����
        private void btnGame_Click(object sender, EventArgs e)
        {
            ns = client.GetStream();

            if (gameFlag == false)
            {
                gameFlag = true;

                btnSerGame.Text = "���� ��";
                btnSerGame.Enabled = false;

                ChatHub hub = new ChatHub
                {
                    UserName = txtNick.Text,
                    Result = gameFlag
                };
                var messageBuffer = Encoding.UTF8.GetBytes(hub.ToJsonString());

                var messageLengthBuffer = BitConverter.GetBytes(messageBuffer.Length);

                ns.Write(messageLengthBuffer);
                ns.Write(messageBuffer);
            }

            if (gameFlag == true)
            {
                panel1.MouseDown += panel1_MouseDown;
            }

        }

        private void btnCh_Click(object sender, EventArgs e)
        {
            if (singleFlag == false)
            {
                singleFlag = true;
                plc1.ActLogicalStationNumber = 1;
                int conErr = 0;
                conErr = plc1.Open();
                if (conErr == 0) lbSt.Text = "plc����";
                else lbSt.Text = "����" + conErr;

                plc1.SetDevice("M1", 1);
                btnCh.BackColor = Color.Green;

            }
            else
            {
                lbSt.Text = "plc���� ����";
                singleFlag = false;
                plc1.SetDevice("M1", 0);
                plc1.Close();
                btnCh.BackColor = Color.White;
                lbSt.Text = "";

            }
        }

        // �� ��ġ ����
        private void DrawStones()
        {
            for (int x = 0; x < 19; x++)
                for (int y = 0; y < 19; y++)
                    if (�ٵ���[x, y] == STONE.white)
                    {
                        if (imgFlag == false)
                        {
                            g.FillEllipse(wBrush, margin + x * ��Size - ��Size / 2,
                                margin + y * ��Size - ��Size / 2, ��Size, ��Size);
                        }
                        else
                        {
                            Bitmap bmp = new Bitmap("../../../image/white.png");
                            g.DrawImage(bmp, margin + x * ��Size - ��Size / 2,
                                margin + y * ��Size - ��Size / 2, ��Size, ��Size);
                        }
                    }
                    else if (�ٵ���[x, y] == STONE.black)
                    {
                        if (imgFlag == false)
                        {
                            g.FillEllipse(bBrush, margin + x * ��Size - ��Size / 2,
                                margin + y * ��Size - ��Size / 2, ��Size, ��Size);
                        }
                        else
                        {
                            Bitmap bmp = new Bitmap("../../../image/black.png");
                            g.DrawImage(bmp, margin + x * ��Size - ��Size / 2,
                                margin + y * ��Size - ��Size / 2, ��Size, ��Size);
                        }
                    }
        }

        // ���� �׸���
        private void DrawBoard()
        {
            g = panel1.CreateGraphics();

            for (int i = 0; i < 19; i++)
            {
                g.DrawLine(pen, new Point(margin + i * ��Size, margin),
                    new Point(margin + i * ��Size, margin + 18 * ��Size));
                g.DrawLine(pen, new Point(margin, margin + i * ��Size),
                    new Point(margin + 18 * ��Size, margin + i * ��Size));
            }

            for (int x = 3; x <= 15; x += 6)
                for (int y = 3; y <= 15; y += 6)
                {
                    g.FillEllipse(bBrush,
                        margin + ��Size * x - ȭ��size / 2,
                        margin + ��Size * y - ȭ��size / 2,
                        ȭ��size, ȭ��size);
                }
        }

        // panel ���콺 �ٿ�
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gameMode == false)
            {
                singChangeResult(sender, e);
            }
            else
            {
                netChangeResult(sender, e);
            }
        }

        private async Task GameSERClient(TcpClient client)
        {
            _ns = client.GetStream();

            while (true)
            {
                byte[] buffer = new byte[1024];
                //TimeSeconds();
                int read = await _ns.ReadAsync(buffer, 0, buffer.Length);
                string data = Encoding.UTF8.GetString(buffer, 0, read);

                string[] coor = data.Split(',');

                int x = int.Parse(coor[0]);
                int y = int.Parse(coor[1]);
                bool checkF = bool.Parse(coor[2]);
                bool PlayerF = bool.Parse(coor[3]);

                Rectangle r = new Rectangle(margin + ��Size * x - ��Size / 2,
                margin + ��Size * y - ��Size / 2, ��Size, ��Size);
                if (PlayerF == true)
                {
                    if (checkF == false)
                    {
                        Bitmap bmp = new Bitmap("../../../image/black.png");
                        g.DrawImage(bmp, r);
                        DrawStoneSequence(stoneCnt, Brushes.White, r);
                        lstRevive.Add(new Revive(x, y, STONE.black, stoneCnt++));
                        flag = true;

                        �ٵ���[x, y] = STONE.black;

                    }
                    PlayerFlag = true;
                }
                CheckOmok(x, y);

            }

        }

        // �̱� ���
        private void singChangeResult(object sender, MouseEventArgs e)
        {
            if (reviceFlag == true)
            {
                ReviveGame();
                return;
            }

            int x = (e.X - margin + ��Size / 2) / ��Size;
            int y = (e.Y - margin + ��Size / 2) / ��Size;

            if (x < 0 || x > 18) return;
            if (y < 0 || y > 18) return;

            if (�ٵ���[x, y] != STONE.none) return;

            Rectangle r = new Rectangle(margin + ��Size * x - ��Size / 2,
                margin + ��Size * y - ��Size / 2, ��Size, ��Size);

            if (flag == false)
            {
                if (imgFlag == false)
                {
                    g.FillEllipse(bBrush, r);
                }
                else
                {
                    Bitmap bmp = new Bitmap("../../../image/black.png");
                    g.DrawImage(bmp, r);
                }
                DrawStoneSequence(stoneCnt, Brushes.White, r);
                lstRevive.Add(new Revive(x, y, STONE.black, stoneCnt++));
                flag = true;
                �ٵ���[x, y] = STONE.black;

                plc1.SetDevice("D0", x);
                plc1.SetDevice("D8", y);
                plc1.SetDevice("M3", 1);
                plc1.SetDevice("M30", 1);
                plc1.SetDevice("M31", 0);
                plc1.SetDevice("M300", 0);
                plc1.SetDevice("M400", 1);

                Thread.Sleep(500);
                plc1.SetDevice("M3", 0);
                plc1.SetDevice("M400", 0);
            }
            else
            {
                if (imgFlag == false)
                {
                    g.FillEllipse(wBrush, r);
                }
                else
                {
                    Bitmap bmp = new Bitmap("../../../image/white.png");
                    g.DrawImage(bmp, r);
                }
                DrawStoneSequence(stoneCnt, Brushes.Black, r);
                lstRevive.Add(new Revive(x, y, STONE.white, stoneCnt++));
                flag = false;
                �ٵ���[x, y] = STONE.white;

                plc1.SetDevice("D0", x);
                plc1.SetDevice("D8", y);
                plc1.SetDevice("M3", 1);
                plc1.SetDevice("M31", 1);
                plc1.SetDevice("M30", 0);
                plc1.SetDevice("M300", 1);
                plc1.SetDevice("M400", 1);

                Thread.Sleep(500);
                plc1.SetDevice("M3", 0);
                plc1.SetDevice("M400", 0);
            }

            CheckOmok(x, y);
        }

        // ��Ʈ��ũ ���
        private async void netChangeResult(object sender, MouseEventArgs e)
        {
            if (reviceFlag == true)
            {
                ReviveGame();
                return;
            }

            if (PlayerFlag == true)
            {
                int x = (e.X - margin + ��Size / 2) / ��Size;
                int y = (e.Y - margin + ��Size / 2) / ��Size;

                if (x < 0 || x > 18) return;
                if (y < 0 || y > 18) return;

                if (�ٵ���[x, y] != STONE.none) return;

                Rectangle r = new Rectangle(margin + ��Size * x - ��Size / 2,
                    margin + ��Size * y - ��Size / 2, ��Size, ��Size);

                if (checkFlag == true)
                {
                    Bitmap bmp = new Bitmap("../../../image/white.png");
                    g.DrawImage(bmp, r);
                    DrawStoneSequence(stoneCnt, Brushes.Black, r);
                    lstRevive.Add(new Revive(x, y, STONE.white, stoneCnt++));
                    flag = false;
                    �ٵ���[x, y] = STONE.white;
                }
                PlayerFlag = false;
                checkFlag = true;

                string point = $"{x},{y},{checkFlag},{PlayerFlag}";
                var data = Encoding.UTF8.GetBytes(point);
                await _ns.WriteAsync(data, 0, data.Length);

                CheckOmok(x, y);
                //dateTime = DateTime.Now;

            }
        }

        //private void TimeSeconds()
        //{
        //    TimeSpan ditme = DateTime.Now - dateTime;
        //    double dsec = (double)(ditme.Ticks / 10000000.0);
        //    if (dsec > 5.0)
        //    {
        //        MessageBox.Show("test");
        //    }

        //}

        // ���� ����
        private void DrawStoneSequence(int v, Brush color, Rectangle r)
        {
            if (sequenceFlag == true)
            {
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
                g.DrawString(v.ToString(), font, color, r, stringFormat);
            }
        }

        // ��� üũ
        private void CheckOmok(int x, int y)
        {
            CheckOm chEckOmok = new CheckOm();
            chEckOmok.check(�ٵ���, x, y);

            if (chEckOmok.cnt >= 5 || chEckOmok.vcnt >= 5 || chEckOmok.dcnt >= 5 || chEckOmok.ddcnt >= 5)
            {
                OmokComplete(x, y);
            }

        }

        // ���
        private void OmokComplete(int x, int y)
        {
            DialogResult res = MessageBox.Show(�ٵ���[x, y].ToString().ToUpper()
                + " Wins!\n���ο� ������ �����ұ��", "��������", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                DialogResult dr = MessageBox.Show("������ �����ұ��", "��������", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    SaveGame();
                }

                NewGame();

                gameFlag = false;
                //if (gameFlag == false) panel1.MouseDown -= panel1_MouseDown;
                btnSerGame.Text = "���� �غ�";

            }
            else if (res == DialogResult.No)
            {   
                this.Close();
            }

        }

        // ���� ����
        private void SaveGame()
        {
            if (reviceFlag == true)
                return;

            string documentPath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents").ToString();
            dirName = documentPath + "/Omok/";

            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);

            string fileName = dirName + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.Hour + DateTime.Now.Minute + ".omk";
            FileStream fs = new FileStream(fileName, FileMode.Create);
            Encoding encoding = Encoding.Default;
            StreamWriter sw = new StreamWriter(fs, encoding);

            foreach (Revive item in lstRevive)
            {
                sw.WriteLine($"{item.x} {item.y} {item.Stone} {item.Seq}");
            }
            sw.Close();
            fs.Close();

        }

        // �� ����
        private void NewGame()
        {
            Clear�ٵ���();
            lstRevive.Clear();

            flag = false;
            imgFlag = true;
            sequenceFlag = true;
            reviceFlag = false;
            gameMode = false;
            gameFlag = false;
            checkFlag = true;
            PlayerFlag = true;
            singleFlag = false;
            stoneCnt = 1;
            sequence = 0;

            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    �ٵ���[i, j] = STONE.none;

            int num = plc1.GetDevice("Y40", out int Y40);
            if (num == 0)
            {
                plc1.SetDevice("M100", 1);
            }

            panel1.Refresh();
            DrawBoard();

        }

        // panel ���콺 �ٿ�� ������ ���� �ش���ġ�� ����Ǿ��� ����ġ�� �ϳ��� ��Ÿ��
        private void ReviveGame()
        {
            if (sequence < lstRevive.Count)
                DrawAStone(lstRevive[sequence++]);
        }

        private void DrawAStone(Revive item)
        {
            int x = item.x;
            int y = item.y;
            STONE s = item.Stone;
            int seq = item.Seq;

            Rectangle r = new Rectangle(margin + ��Size * x - ��Size / 2,
                margin + ��Size * y - ��Size / 2, ��Size, ��Size);

            if (s == STONE.black)
            {
                if (imgFlag == false)
                    g.FillEllipse(bBrush, r);
                else
                {
                    Bitmap bmp = new Bitmap("../../../image/black.png");
                    g.DrawImage(bmp, r);
                }
                DrawStoneSequence(seq, Brushes.White, r);
                �ٵ���[x, y] = STONE.black;

            }
            else
            {
                if (imgFlag == false)
                    g.FillEllipse(wBrush, r);
                else
                {
                    Bitmap bmp = new Bitmap("../../../image/white.png");
                    g.DrawImage(bmp, r);
                }
                DrawStoneSequence(seq, Brushes.Black, r);
                �ٵ���[x, y] = STONE.white;
            }
            CheckOmok(x, y);
        }

        // �ٽ� ����
        private void InitializeOmok()
        {
            Clear�ٵ���();
            lstRevive.Clear();
            panel1.Refresh();
            DrawBoard();

            flag = false;
            imgFlag = true;
            sequenceFlag = true;
            reviceFlag = false;
            gameMode = false;
            gameFlag = false;
            checkFlag = true;
            PlayerFlag = true;
            singleFlag = false;
            stoneCnt = 1;
            sequence = 0;

            int num = plc1.GetDevice("Y40", out int Y40);
            if (num == 0)
            {
                plc1.SetDevice("M100", 1);
            }

        }

        private void Clear�ٵ���()
        {
            for (int i = 0; i < 19; i++)
                for (int j = 0; j < 19; j++)
                    �ٵ���[i, j] = STONE.none;
        }

        private void �̹���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �̹���ToolStripMenuItem.Checked = true;
            �׸���ToolStripMenuItem.Checked = false;
            imgFlag = true;
        }

        private void �׸���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            �̹���ToolStripMenuItem.Checked = false;
            �׸���ToolStripMenuItem.Checked = true;
            imgFlag = false;
        }

        private void ���θ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("���� �����", "�� ����", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                NewGame();
            }
        }

        private void ����ǥ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����ǥ��ToolStripMenuItem.Checked = true;
            ����ǥ�þ���ToolStripMenuItem.Checked = false;
            sequenceFlag = true;
        }

        private void ����ǥ�þ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ����ǥ�þ���ToolStripMenuItem.Checked = true;
            ����ǥ��ToolStripMenuItem.Checked = false;
            sequenceFlag = false;
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void �ٽý���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeOmok();
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = dirName;
            ofd.Filter = "Omok files(*.omk)|*.omk";
            ofd.ShowDialog();
            string fileName = ofd.FileName;
            sequenceFlag = true;

            InitializeOmok();

            try
            {
                StreamReader r = File.OpenText(fileName);
                string line = "";

                while ((line = r.ReadLine()) != null)
                {
                    string[] items = line.Split(' ');
                    Revive rev = new Revive(
                        int.Parse(items[0]), int.Parse(items[1]),
                        items[2] == "black" ? STONE.black : STONE.white,
                        int.Parse(items[3]));
                    lstRevive.Add(rev);
                }
                r.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            reviceFlag = true;
            sequence = 0;
        }

        private void ����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveGame();
        }

        private void �̱�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            �̱�ToolStripMenuItem.Checked = true;
            ��Ʈ��ũToolStripMenuItem.Checked = false;
            gameMode = false;
            txtChat.Enabled = false;
            txtNick.Enabled = false;
            btnConn.Enabled = false;
            btnSend.Enabled = false;
            btnSerGame.Enabled = false;
            panel1.MouseDown += panel1_MouseDown;
        }

        private void ��Ʈ��ũToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
            ��Ʈ��ũToolStripMenuItem.Checked = true;
            �̱�ToolStripMenuItem.Checked = false;
            gameMode = true;
            txtChat.Enabled = true;
            txtNick.Enabled = true;
            btnConn.Enabled = true;
            btnSend.Enabled = true;
            btnSerGame.Enabled = false;
            btnClose.Enabled = true;
            panel1.MouseDown -= panel1_MouseDown;

        }

        private void txtChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                listener.Stop();
                _listener.Stop();
                client.Close();
                _client.Close();
                ns.Close();
                _ns.Close();
                listener.Dispose();
                _listener.Dispose();
                this.Close();
            }
            catch
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            plc1.SetDevice("M2", 1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            plc1.SetDevice("M2", 0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            plc1.SetDevice("M5", 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            plc1.SetDevice("M5", 0);
        }
    }
}
