using System;

namespace OsiemWesolychKwadratow
{
	internal class LightsOffGame : IGame
	{
		private bool[,] State = new bool[4, 2];
		public GameType GameType { get; set; }

		public event EventHandler Repaint;

		public void ButtonPress(int x, int y)
		{
			DoMove(x, y);

			this.Repaint(this, EventArgs.Empty);
		}

		private void DoMove(int x, int y)
		{
			SwitchTile(x, y);
			SwitchTile(x - 1, y);
			SwitchTile(x + 1, y);
			SwitchTile(x, y - 1);
			SwitchTile(x, y + 1);
		}

		private void SwitchTile(int x, int y)
		{
			if (x >=0 && x < 4 && y >= 0 && y < 2)
			{
				State[x, y] = !State[x, y];
			}
		}

		public bool[,] GetState()
		{
			return State;
		}

		public void Start()
		{
			int x, y;

			for (int i = 0; i < 8; i++)
			{
				x = i % 4;
				y = i / 4;

				State[x, y] = false;
			}

			Random r = new Random((int)DateTime.Now.Ticks);

			for (int i = 0; i < 20; i++)
			{
				DoMove(r.Next(4), r.Next(2));
            }
		
			this.Repaint(this, EventArgs.Empty);
		}

		public void Stop()
		{
			
		}
	}
}