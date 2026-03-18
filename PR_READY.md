PR Ready Checklist and Instructions

Goal: make the PingPong-Squad/Developer branch PR-ready and open a PR into main. Follow every step and push when done.

1) Fix project files
- Ensure PingPongApp/PingPongApp.csproj is valid XML and targets net10.0. Minimal example:

  <Project Sdk="Microsoft.NET.Sdk">
    <PropertyGroup>
      <OutputType>Exe</OutputType>
      <TargetFramework>net10.0</TargetFramework>
      <ImplicitUsings>enable</ImplicitUsings>
      <Nullable>enable</Nullable>
    </PropertyGroup>
  </Project>

2) Add Program.cs (entrypoint)
- Minimal Program.cs (example):

  using PingPongApp;

  class Program
  {
      static void Main()
      {
          var settings = GameSettings.Default();
          var game = new Game(settings);
          game.Run();
      }
  }

3) Implement Renderer.cs
- Provide a simple ASCII renderer that clears only necessary screen area and draws borders, paddles and ball using Console.SetCursorPosition.
- Ensure renderer does not print extra newlines (use Console.SetCursorPosition) and is efficient.

4) Make movement/time consistent
- Do not use fixed constants for movement steps in HandleInput. Use the frame delta (dt) from the game loop.
- Suggested change: in Run() capture dt and pass it to HandleInput(dt). Then inside HandleInput call _left.MoveUp(dt * 1.0) or directly use MoveUp(dt).
- Example: replace _left.MoveUp(0.05) with _left.MoveUp(dt) or _left.MoveUp(_settings.PaddleSpeed * dt) if MoveUp expects dt only.

5) Harden collisions and scoring
- Avoid rounding fragility: compare ball.X to paddle X using tolerances or by checking a small interval instead of exact rounding.
- Ensure scoring thresholds match screen coordinates (e.g., if field X runs from 0..Width-1 then score if X <= -1 or X >= Width).
- After a paddle collision, nudge ball X away from paddle to avoid repeated collisions.

6) Tests and build
- Ensure tests reference correct project path and that BallTests compile.
- Run locally:
  dotnet build -f net10.0
  dotnet test -f net10.0
- Fix any compile/test failures before committing.

7) Clean repository (do not commit binaries)
- Remove tracked build artifacts if any slipped into commits:
  git rm -r --cached **/bin **/obj || true
- Add/update .gitignore to include:
  bin/
  obj/
  *.user
  *.suo
  .DS_Store
- Verify no compiled files remain tracked:
  git ls-files | grep -E "bin/|obj/" || true

8) Commit guidelines
- Make small, focused commits. Example final commit message for fixes:

  feat(game): add Program, Renderer, fix collisions and dt-based input

  - Complete PingPongApp.csproj
  - Add Program.cs and Renderer.cs
  - Use dt for input and movement
  - Harden collision and scoring logic

  Co-authored-by: Copilot <223556219+Copilot@users.noreply.github.com>

9) PR description template
- Title: "Feature: basic game loop, renderer, AI improvements"
- Body:
  Summary: what changed
  Files of interest: PingPongApp/Game.cs, PingPongApp/Renderer.cs, PingPongApp/Program.cs, PingPongApp/PingPongApp.csproj
  Checklist:
   - [ ] dotnet build -f net10.0 passes
   - [ ] dotnet test -f net10.0 passes
   - [ ] No bin/obj or other binaries committed
   - [ ] Renderer works in terminal (macOS tested)
   - [ ] QA: link to regression_test_cases.md and instruct QA to run TS-001..TS-010
  Testing instructions for reviewer: run dotnet run -f net10.0 and play briefly; run dotnet test -f net10.0

10) Post-push steps
- Push branch: git push origin HEAD
- Open PR on GitHub and paste the PR description above; assign to QA for regression tests.
- Add a short comment tagging me (the orchestrator) to re-run final review.

11) QA verification to mention in PR
- Ask QA to run these commands and report back:
  dotnet run -f net10.0
  dotnet test -f net10.0
- QA should confirm TS-001..TS-010 or attach bug reports in bug_reports.md.

If anything blocks you that you cannot fix locally, add a clear note to the PR describing the blocker and the exact error output. I will wait for your push and then re-run review and merge if green.

— End of PR-ready instructions —
