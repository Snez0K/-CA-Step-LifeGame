namespace LifeGame
{
    public class Style
    {
        internal char Cursor { get; set; } = 'X' ;
        internal char Dead { get; set; } = ' ';
        internal char Alive { get; set; } = 'O';
        internal char WillDie { get; set; } = 'o';
        internal char WillBorn { get; set; } = '*';
        internal char Border { get; set; } = '+';    
    }
}