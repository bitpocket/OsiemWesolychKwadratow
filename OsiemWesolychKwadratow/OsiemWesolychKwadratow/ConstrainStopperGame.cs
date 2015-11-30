using System;

namespace OsiemWesolychKwadratow
{
	internal class ConstrainStopperGame : Game
	{
		public ConstrainStopperGame(int hourStartAt, int minuteStartAt, int hourStopAt, int minuteStopAt)
		{
			DateTime today = DateTime.Now;
			this.StartedAt = new DateTime(today.Year, today.Month, today.Day, hourStartAt, minuteStartAt, 0);
			this.StopAt = new DateTime(today.Year, today.Month, today.Day, hourStopAt, minuteStopAt, 0);

			TotalSecondsToReach = (StopAt - StartedAt).TotalSeconds;
		}

		DateTime StartedAt, StopAt;
		double TotalSecondsToReach;

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