using Xunit;
using PingPongApp;

namespace PingPongApp.Tests
{
    public class BallTests
    {
        [Fact]
        public void ReflectX_Inverts_VelocityX()
        {
            var ball = new Ball(10, 10, 5, 0);
            ball.ReflectX();
            Assert.Equal(-5, ball.VX);
        }

        [Fact]
        public void Update_Moves_Ball_By_Velocity()
        {
            var ball = new Ball(0, 0, 2, 3);
            ball.Update(0.5); // half second
            Assert.Equal(1.0, ball.X, 5);
            Assert.Equal(1.5, ball.Y, 5);
        }
    }
}
