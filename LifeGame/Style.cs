namespace LifeGame
{
    public class Style
    {
        private char cursor = 'X';
        private char dead = ' ';
        private char alive = 'O';
        private char willDie = 'o';
        private char willBorn = '*';
        private char border = '+';

        public char GetCursor()
        {
            return cursor;
        }
        public char GetDead()
        {
            return dead;
        }
        public char GetAlive()
        {
            return alive;
        }
        public char GetWillDie()
        {
            return willDie;
        }
        public char GetWillBorn()
        {
            return willBorn;
        }
        public char GetBorder()
        {
            return border;
        }
    }
}