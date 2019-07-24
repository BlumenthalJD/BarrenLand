using System;
using System.Collections.Generic;

namespace BarrenLand
{
	class Program
	{
		static void Main(string[] args)
		{
			//{“48 192 351 207”, “48 392 351 407”, “120 52 135 547”, “260 52 275 547”}
			//{"10 20 30 40", "10 100 30 200"}
			//{“20 0 20 99”}
			//{“0 292 399 307”}
			
			Console.WriteLine("Please input the range of barren land:");
			string input = Console.ReadLine();

			var barrenRectangles = Helpers.ParseInput(input);
			var farm = new Farm();

			SetBarrenLands(farm, barrenRectangles);
			//PrintFarm(farm);

			List<int> areas = new List<int>();
			int area = 0;

			for (int i = 0; i < farm.coordinates.Count; i++)
			{
				for (int j = 0; j < farm.coordinates[i].Count; j++)
				{
					if (farm.coordinates[i][j] == '-')
					{
						area = 0;
						DFS(farm, i, j, ref area);
						if (area > 0) areas.Add(area);
					}
				}
			}

			areas.Sort();

			foreach (var num in areas)
			{
				Console.Write($"{num} ");
			}
			Console.WriteLine();

			return;
		}

		static void DFS(Farm farm, int row, int col, ref int area)
		{
			Stack<List<int>> s = new Stack<List<int>>();
			s.Push(new List<int> { row, col });
			while (s.Count > 0)
			{
				var coord = s.Pop();
				row = coord[0];
				col = coord[1];

				if ((row < 0)
 				 || (col < 0)
 				 || (row == farm.coordinates.Count)
 				 || (col == farm.coordinates[row].Count)
 				 || (farm.coordinates[row][col] != '-')) continue;

				area += 1;
				farm.coordinates[row][col] = '.';
				s.Push(new List<int> { row + 1, col });
				s.Push(new List<int> { row, col + 1 });
				s.Push(new List<int> { row - 1, col });
				s.Push(new List<int> { row, col - 1 });
			}

			return;
		}

		static void SetBarrenLands(Farm farm, List<BarrenRectangle> barrenRectangles)
		{
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
		}

		static void PrintFarm(Farm farm)
		{
			foreach (var row in farm.coordinates)
			{
				foreach (var col in row)
				{
					Console.Write(col);
				}
				Console.WriteLine();
			}
			return;
		}
	}
}
