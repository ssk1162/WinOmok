namespace WinOmok
{
    internal class Revive
    {
        public int x { get; set; }
        public int y { get; set; }
        public STONE Stone { get; set; }
        public int Seq { get; set; }

        public Revive(int x, int y, STONE s, int seq)
        {
            this.x = x;
            this.y = y;
            this.Stone = s;
            this.Seq = seq;
        }

    }
}
