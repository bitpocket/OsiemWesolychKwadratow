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
                case GameType.HalfMinute:
                    game = new ClockGame(10);
                    break;
                case GameType.FifeMinutes:
                    game = new ClockGame(5 * 60);
                    break;
                case GameType.EightHours:
                    game = new ClockGame(8 * 60 * 60);
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
