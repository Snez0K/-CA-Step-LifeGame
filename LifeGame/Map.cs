namespace LifeGame
{
    class Map
    {
        internal const int Yline = 10;
        internal const int Xline = 40;
        internal char[,] Field { get; set; } = new char[Yline, Xline];
        internal bool Start = false;
    }
}