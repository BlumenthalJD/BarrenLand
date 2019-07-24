using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BarrenLand
{
	class Program
	{
		static void Main(string[] args)
		{
			//{“48 192 351 207”, “48 392 351 407”, “120 52 135 547”, “260 52 275 547”}
			//{"10 20 30 40", "10 100 30 200"}
			//{“0 292 399 307”}
			Console.WriteLine("Please input the range of barren land:");
			string input = Console.ReadLine();
			Console.WriteLine("Your input was " + input);
			var barrenRectangles = Helpers.ParseInput(input);
			var farm = new Farm();

			foreach (var rectangle in barrenRectangles)
			{
				for (int i = rectangle.bottomLeftX; i <= rectangle.topRightX; i++)
				{
					for (int j = rectangle.bottomLeftY; j <= rectangle.topRightY; j++)
					{
						farm.coordinates[i][j] = '.';
					}
				}
			}

			foreach (var row in farm.coordinates)
			{
				foreach (var col in row)
				{
					Console.Write(col);
				}
				Console.WriteLine();
			}

			var count = 0;
			List<int> areas = new List<int>();
			for (int i = 0; i < farm.coordinates.Count; i++)
			{
				for (int j = 0; j < farm.coordinates[i].Count; j++)
				{
					if (farm.coordinates[i][j] == '-')
					{
						int area = 0;
						DFS(farm, i, j, area);
						areas.Add(area);
					}
				}
			}


			Console.WriteLine(count);
			return;
		}

		static void DFS(Farm farm, int startX, int startY, int area)
		{
			if (startX > farm.coordinates.Count - 1
				|| startX < 0
				|| startY > farm.coordinates[startX].Count - 1
				|| startY < 0
				|| farm.coordinates[startX][startY] == '.') return;

			farm.coordinates[startX][startY] = '_';

			if (startY - 1 >= 0 && farm.coordinates[startX][startY - 1] != '_')
			{
				DFS(farm, startX - 1, startY, area + 1);
			}
			if (startY + 1 < farm.coordinates[startX].Count - 1 && farm.coordinates[startX][startY + 1] != '_')
			{
				DFS(farm, startX + 1, startY, area + 1);
			}
			if (startX - 1 >= 0 && farm.coordinates[startX - 1][startY] != '_')
			{
				DFS(farm, startX, startY - 1, area + 1);
			}
			if (startX + 1 < farm.coordinates.Count - 1 && farm.coordinates[startX + 1][startY] != '_')
			{
				DFS(farm, startX, startY + 1, area + 1);
			}

			return;
		}
	}
}
