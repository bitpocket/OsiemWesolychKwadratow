using System;
using System.Windows.Forms;

namespace OsiemWesolychKwadratow
{
	internal abstract class Game :IGame
	{
		public Game()
		{
		}

		public Timer timer;
		private bool[,] State = new bool[4, 2];

		GameType IGame.GameType { get; set; }

		public bool[,] GetState()
		{
			return State;
		}

		public virtual void Start()
		{
			timer = new Timer();
			timer.Interval = 100;
			timer.Tick += timer_Tick;
			timer.Enabled = true;
		}

		public virtual void Stop()
		{
			timer.Enabled = false;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			CalculateModel();
			OnRepaint(EventArgs.Empty);
		}

		protected abstract void CalculateModel();

		protected virtual void OnRepaint(EventArgs e)
		{
			EventHandler handler = Repaint;

			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected void CalculateVievState(int val)
		{
			int x, y;

			for (int i = 0; i < 8; i++)
			{
				x = i % 4;
				y = i / 4;

				State[x, y] = (val & Convert.ToInt16(Math.Pow(2, i))) != 0;
			}
		}

		public event EventHandler Repaint;
	}
}