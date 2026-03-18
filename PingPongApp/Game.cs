using System;
using System.Diagnostics;
using System.Threading;

namespace PingPongApp
{
    public class Game
    {
        private readonly GameSettings _settings;
        private Paddle _left;
        private Paddle _right;
        private Ball _ball;
        private AIController _ai;
        private Renderer _renderer;
        private int _scoreLeft = 0;
        private int _scoreRight = 0;
        private bool _running = true;
        private bool _paused = false;

        public Game(GameSettings settings)
        {
            _settings = settings;
            Initialize();
        }

        private void Initialize()
        {
            _left = new Paddle(2, _settings.Height / 2.0, _settings.PaddleHeight, _settings.PaddleSpeed);
            _right = new Paddle(_settings.Width - 3, _settings.Height / 2.0, _settings.PaddleHeight, _settings.PaddleSpeed);
            _ball = new Ball(_settings.Width / 2.0, _settings.Height / 2.0, _settings.BallSpeed, 0);
            _ai = new AIController(_right, _settings);
            _renderer = new Renderer(_settings);
            _scoreLeft = 0; _scoreRight = 0;
        }

        private void ResetRound()
        {
            _left.Y = _settings.Height / 2.0;
            _right.Y = _settings.Height / 2.0;
            var dir = (_scoreLeft + _scoreRight) % 2 == 0 ? 1 : -1;
            _ball.Reset(_settings.Width / 2.0, _settings.Height / 2.0, dir * _settings.BallSpeed, 0);
        }

        public void Run()
        {
            ResetRound();
            var sw = Stopwatch.StartNew();
            double previous = sw.Elapsed.TotalSeconds;

            Console.Clear();
            while (_running)
            {
                var now = sw.Elapsed.TotalSeconds;
                var dt = now - previous;
                previous = now;

                HandleInput();

                if (!_paused)
                {
                    Update(dt);
                }

                _renderer.Render(_left, _right, _ball, _scoreLeft, _scoreRight);

                if (_scoreLeft >= _settings.TargetScore || _scoreRight >= _settings.TargetScore)
                {
                    Console.SetCursorPosition(0, _settings.Height + 2);
                    Console.WriteLine(_scoreLeft > _scoreRight ? "Player wins! (R)estart or (Q)uit" : "PC wins! (R)estart or (Q)uit");
                    _paused = true;
                }

                Thread.Sleep(_settings.FrameMs);
            }
        }

        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        _left.MoveUp(0.05);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        _left.MoveDown(0.05);
                        break;
                    case ConsoleKey.P:
                        _paused = !_paused;
                        break;
                    case ConsoleKey.R:
                        _scoreLeft = 0; _scoreRight = 0; _paused = false; ResetRound(); Console.Clear(); break;
                    case ConsoleKey.Q:
                        _running = false; break;
                }
            }
        }

        private void Update(double dt)
        {
            // player movement bounds
            var half = _left.Height / 2.0;
            if (_left.Y - half < 1) _left.Y = 1 + half;
            if (_left.Y + half > _settings.Height - 2) _left.Y = _settings.Height - 2 - half;

            _ai.Update(dt, _ball);

            _ball.Update(dt);

            // wall collisions
            if (_ball.Y <= 1)
            {
                _ball.Y = 1;
                _ball.ReflectY();
            }
            if (_ball.Y >= _settings.Height - 2)
            {
                _ball.Y = _settings.Height - 2;
                _ball.ReflectY();
            }

            // paddle collisions
            if ((int)System.Math.Round(_ball.X) <= _left.X + 0)
            {
                if ((int)System.Math.Round(_ball.Y) >= _left.Top && (int)System.Math.Round(_ball.Y) <= _left.Bottom)
                {
                    _ball.X = _left.X + 1;
                    _ball.ReflectX();
                }
            }

            if ((int)System.Math.Round(_ball.X) >= _right.X - 0)
            {
                if ((int)System.Math.Round(_ball.Y) >= _right.Top && (int)System.Math.Round(_ball.Y) <= _right.Bottom)
                {
                    _ball.X = _right.X - 1;
                    _ball.ReflectX();
                }
            }

            // scoring
            if (_ball.X < 0)
            {
                _scoreRight++;
                ResetRound();
            }
            else if (_ball.X > _settings.Width)
            {
                _scoreLeft++;
                ResetRound();
            }
        }
    }
}
