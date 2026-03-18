Action items to fix before merge:

1) Complete PingPongApp.csproj - ensure valid XML and TargetFramework net10.0.
2) Add Program.cs with entrypoint: create GameSettings.Default(), instantiate Game and call Run().
3) Implement Renderer.cs to draw ASCII field and paddles/ball based on settings and positions.
4) Adjust input movement to use Paddle.Speed * dt rather than fixed 0.05 step.
5) Harden collision checks: avoid casting rounding surprises; use tolerances and ensure scoring boundaries correct.
6) Run and ensure: dotnet build -f net10.0 && dotnet test -f net10.0 pass.
7) Commit fixes with Co-authored-by trailer and push branch PingPong-Squad/Developer.

Please update the PR when done.
