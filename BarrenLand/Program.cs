using System;
using System.Collections.Generic;
using BarrenLand.Models;
using BarrenLand.Services;

namespace BarrenLand
{
	class Program
	{
		static void Main(string[] args)
		{
			//ask for input of the barren lands
			Console.WriteLine("Please input the range of barren land:");
			string input = Console.ReadLine();

			//parses input into accessible list of rectangles
			var barrenRectangles = InputParser.ParseInput(input);

			//instatiates farm with prefilled "-" for each coordinate
			var farm = new Farm();

			//set all barren coordinates to "." in the farm field
			farm.SetBarrenFarmland(barrenRectangles);

			//run dfs with now filled farmland
			List<int> areas = DFSRunner.RunDFS(farm);

			//sort with smallest first
			areas.Sort();

			//write each area to the screen
			foreach (var num in areas)
			{
				Console.Write($"{num} ");
			}
			Console.WriteLine();

			return;
		}
	}
}
