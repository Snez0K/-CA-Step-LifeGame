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

        public char getCursor()
        {
            return cursor;
        }
        public char getDead()
        {
            return dead;
        }
        public char getAlive()
        {
            return alive;
        }
        public char getWillDie()
        {
            return willDie;
        }
        public char getWillBorn()
        {
            return willBorn;
        }
        public char getBorder()
        {
            return border;
        }
    }
}