using System;
using System.Windows.Forms;

namespace OsiemWesolychKwadratow
{
    internal class ClockGame : IGame
    {
        public ClockGame(double TotalSecondsToReach)
        {
            this.TotalSecondsToReach = TotalSecondsToReach;
        }

        public Timer timer;
        private bool[,] State = new bool[4, 2];

        DateTime StartedAt;
        double TotalSecondsToReach;

        GameType IGame.GameType { get; set; }

        public bool[,] GetState()
        {
            return State;
        }

        public void Start()
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            StartedAt = DateTime.Now;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            double secondsElapsed = (DateTime.Now - StartedAt).TotalSeconds;

            if (secondsElapsed >= TotalSecondsToReach)
            {
                secondsElapsed = TotalSecondsToReach;
                Stop();
            }

            int res = (int) Math.Round((255 * secondsElapsed) / TotalSecondsToReach);

            CalculateState(res);

            OnRepaint(EventArgs.Empty);
        }

        protected virtual void OnRepaint(EventArgs e)
        {
            EventHandler handler = Repaint;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void CalculateState(int val)
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