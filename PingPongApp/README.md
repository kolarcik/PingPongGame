PingPong (Console)

Build & Run:

- Requires .NET 10 SDK.
- From repository root run:

  dotnet run --project PingPongApp

Controls:
- Player (left paddle): W/S or Up/Down arrows
- P: Pause/Unpause
- R: Restart game
- Q: Quit

AI parameters (in GameSettings.Default):
- AISpeed: maximum movement speed of the PC paddle
- AIReactionDelay: minimal time between reactions (seconds)

Adjust values in PingPongApp/GameSettings.cs and rebuild.
