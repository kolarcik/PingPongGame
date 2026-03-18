namespace PingPongApp
{
    public class Paddle
    {
        public int X { get; }
        public double Y { get; set; }
        public int Height { get; }
        public double Speed { get; }

        public Paddle(int x, double y, int height, double speed)
        {
            X = x; Y = y; Height = height; Speed = speed;
        }

        public void MoveUp(double dt)
        {
            Y -= Speed * dt;
        }

        public void MoveDown(double dt)
        {
            Y += Speed * dt;
        }

        public int Top => (int)System.Math.Round(Y - Height / 2.0);
        public int Bottom => Top + Height - 1;
    }
}
