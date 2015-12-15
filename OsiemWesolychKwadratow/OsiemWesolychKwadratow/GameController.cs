using System;

namespace OsiemWesolychKwadratow
{
	class GameController
	{
		private static GameController _Instance;
		public static GameController Instance()
		{
			if (_Instance == null)
			{
				_Instance = new GameController();
			}

			return _Instance;
		}

		public IGame currentGame;

		public void StartGame(GameType gt, EventHandler Repaint)
		{
			StopGame();
			currentGame = CreateGame(gt);
			if (currentGame != null)
			{
				currentGame.Repaint += Repaint;
				currentGame.Start();
			}
		}

		public void StopGame()
		{
			if (currentGame != null)
			{
				currentGame.Stop();
			}
		}

		IGame CreateGame(GameType gt)
		{
			IGame game = null;

			switch (gt)
			{
				case GameType.Off:
					break;
				case GameType.TenSeconds:
					game = new StoperGame(10);
					break;
				case GameType.FifeMinutes:
					game = new StoperGame(5 * 60);
					break;
				case GameType.FitheenMinutes:
					game = new StoperGame(15 * 60);
					break;
				case GameType.EightHours:
					game = new ConstrainStopperGame(8, 15, 16, 15);
					break;
				case GameType.Pomodoro:
					game = new PomodoroGame();
					break;
				case GameType.LightsOff:
					game = new LightsOffGame();
					break;
				default:
					break;
			}

			if (game!= null)
			{
				game.GameType = gt;
			}

			return game;
		}
	}
}
