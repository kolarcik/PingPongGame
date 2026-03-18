namespace PingPongApp
{
    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double VX { get; set; }
        public double VY { get; set; }

        public Ball(double x, double y, double vx, double vy)
        {
            X = x;
            Y = y;
            VX = vx;
            VY = vy;
        }

        public void Update(double dt)
        {
            X += VX * dt;
            Y += VY * dt;
        }

        public void ReflectX()
        {
            VX = -VX;
        }

        public void ReflectY()
        {
            VY = -VY;
        }

        public void Reset(double x, double y, double vx, double vy)
        {
            X = x; Y = y; VX = vx; VY = vy;
        }
    }
}
