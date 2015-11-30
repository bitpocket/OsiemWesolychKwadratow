using System;

namespace OsiemWesolychKwadratow
{
	interface IGame
	{
		GameType GameType { get; set; }
		void Start();
		void Stop();
		bool[,] GetState();
		event EventHandler Repaint;
	}
}
