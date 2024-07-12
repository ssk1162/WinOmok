namespace WinOmok
{
    internal class CheckOm
    {
        public int cnt { get; set; } = 1;
        public int vcnt { get; set; } = 1;
        public int dcnt { get; set; } = 1;
        public int ddcnt { get; set; } = 1;

        public void check(STONE[,] 바둑판, int x, int y)
        {
            // 가로
            for (int i = x + 1; i <= 18; i++)
            {
                if (바둑판[i, y] == 바둑판[x, y])
                    cnt++;
                else break;
            }

            for (int i = x - 1; i >= 0; i--)
            {
                if (바둑판[i, y] == 바둑판[x, y])
                    cnt++;
                else break;
            }

            // 세로
            for (int i = y + 1; i <= 18; i++)
            {
                if (바둑판[x, i] == 바둑판[x, y])
                    vcnt++;
                else break;
            }

            for (int i = y - 1; i >= 0; i--)
            {
                if (바둑판[x, i] == 바둑판[x, y])
                    vcnt++;
                else break;
            }

            // 대각선
            int a = y - 1;
            for (int i = x + 1; i <= 18; i++)
            {
                if (a < 0 || a > 18) break;

                if (바둑판[i, a] == 바둑판[x, y]) dcnt++;
                else break;
                a--;
            }

            int b = y + 1;
            for (int i = x - 1; i >= 0; i--)
            {
                if (b < 0 || b > 18) break;

                if (바둑판[i, b] == 바둑판[x, y]) dcnt++;
                else break;
                b++;
            }

            // 역대각선
            int c = y + 1;
            for (int i = x + 1; i <= 18; i++)
            {
                if (c < 0 || c > 18) break;

                if (바둑판[i, c] == 바둑판[x, y]) ddcnt++;
                else break;
                c++;
            }

            int d = y - 1;
            for (int i = x - 1; i >= 0; i--)
            {
                if (d < 0 || d > 18) break;

                if (바둑판[i, d] == 바둑판[x, y]) ddcnt++;
                else break;
                d--;
            }
        }

    }
}
