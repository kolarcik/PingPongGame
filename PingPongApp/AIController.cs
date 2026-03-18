using System;

namespace PingPongApp
{
    public class AIController
    {
        private readonly Paddle _paddle;
        private readonly GameSettings _settings;
        private double _reactionTimer = 0.0;

        public AIController(Paddle paddle, GameSettings settings)
        {
            _paddle = paddle;
            _settings = settings;
        }

        public void Update(double dt, Ball ball)
        {
            _reactionTimer -= dt;
            if (_reactionTimer > 0) return; // simple reaction delay

            // Reset reaction timer
            _reactionTimer = _settings.AIReactionDelay;

            // Move toward ball Y with limited speed
            var targetY = ball.Y;
            var dy = targetY - _paddle.Y;
            var maxMove = _settings.AISpeed * dt;
            if (Math.Abs(dy) <= maxMove)
            {
                _paddle.Y = targetY;
            }
            else if (dy > 0)
            {
                _paddle.Y += maxMove;
            }
            else
            {
                _paddle.Y -= maxMove;
            }

            // Keep within bounds
            var half = _paddle.Height / 2.0;
            if (_paddle.Y - half < 1) _paddle.Y = 1 + half;
            if (_paddle.Y + half > _settings.Height - 2) _paddle.Y = _settings.Height - 2 - half;
        }
    }
}
