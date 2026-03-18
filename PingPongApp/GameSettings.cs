namespace PingPongApp
{
    public record GameSettings(int Width, int Height, int PaddleHeight, double PaddleSpeed, double BallSpeed, int TargetScore, double AISpeed, double AIReactionDelay, int FrameMs)
    {
        public static GameSettings Default() => new GameSettings(80, 24, 5, 25.0, 30.0, 11, 15.0, 0.08, 50);
    }
}
