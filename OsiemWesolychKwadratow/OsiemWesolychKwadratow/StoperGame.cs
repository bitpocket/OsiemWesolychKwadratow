using System;

namespace OsiemWesolychKwadratow
{
	internal class StoperGame : Game
	{
		public StoperGame(double TotalSecondsToReach)
		{
			this.TotalSecondsToReach = TotalSecondsToReach;
		}

		DateTime StartedAt;
		double TotalSecondsToReach;

		public override void Start()
		{
			base.Start();
			StartedAt = DateTime.Now;
		}

		protected override void CalculateModel()
		{
			double secondsElapsed = (DateTime.Now - StartedAt).TotalSeconds;

			if (secondsElapsed >= TotalSecondsToReach)
			{
				secondsElapsed = TotalSecondsToReach;
				Stop();
			}

			int res = (int)Math.Round((255 * secondsElapsed) / TotalSecondsToReach);

			CalculateVievState(res);
		}
	}
}