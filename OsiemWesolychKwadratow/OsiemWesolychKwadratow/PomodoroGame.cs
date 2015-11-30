using System;

namespace OsiemWesolychKwadratow
{
	internal class PomodoroGame : Game
	{
		public PomodoroGame()
		{
		}

		DateTime StartedAt, StopAt;
		double WorkIntervalInSeconds = 25 * 60;
		double BreakIntervalInSeconds = 5 * 60;

		protected override void CalculateModel()
		{
			DateTime today = DateTime.Now;
			bool isWork = (today.Minute >= 0 && today.Minute < 25) || (today.Minute >= 30 && today.Minute < 55);

			int startesAtMinute = isWork ?
				(today.Minute < 25 ? 0 : 30) :
				(today.Minute < 30 ? 25 : 55);

			double TotalSecondsToReach = isWork ? WorkIntervalInSeconds : BreakIntervalInSeconds;

			DateTime StartedAt = new DateTime(today.Year, today.Month, today.Day, today.Hour, startesAtMinute, 0);

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