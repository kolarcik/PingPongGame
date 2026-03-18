using System;
using System.Text;

namespace PingPongApp
{
    public class Renderer
    {
        private readonly GameSettings _settings;
        private readonly StringBuilder _sb = new StringBuilder();

        public Renderer(GameSettings settings)
        {
            _settings = settings;
        }

        public void Render(Paddle left, Paddle right, Ball ball, int scoreLeft, int scoreRight)
        {
            _sb.Clear();
            for (int y = 0; y < _settings.Height; y++)
            {
                for (int x = 0; x < _settings.Width; x++)
                {
                    char ch = ' ';

                    // borders
                    if (y == 0 || y == _settings.Height - 1)
                    {
                        ch = '-';
                    }
                    else if (x == 0 || x == _settings.Width - 1)
                    {
                        ch = '|';
                    }
                    else
                    {
                        // ball
                        if ((int)System.Math.Round(ball.X) == x && (int)System.Math.Round(ball.Y) == y)
                        {
                            ch = 'O';
                        }
                        else if (x == left.X && y >= left.Top && y <= left.Bottom)
                        {
                            ch = '|';
                        }
                        else if (x == right.X && y >= right.Top && y <= right.Bottom)
                        {
                            ch = '|';
                        }
                    }

                    _sb.Append(ch);
                }
                _sb.AppendLine();
            }

            // score line
            _sb.AppendLine($"Score: Player {scoreLeft}  -  PC {scoreRight}");
            Console.SetCursorPosition(0, 0);
            Console.Write(_sb.ToString());
        }
    }
}
