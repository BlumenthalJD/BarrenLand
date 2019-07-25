using System.Collections.Generic;
using BarrenLand.Models;

namespace BarrenLand.Services
{
	public class DFSRunner
	{
		public static List<int> RunDFS(Farm farm)
		{
			//create areas variable for the area of each square
			List<int> areas = new List<int>();
			int area = 0;

			//go through each coordinate and if it's usable field,
			//do depth-first search to get the area of the usable field
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

			return areas;
		}

		//this is an iterative depth-first search (recursive was too slow)
		private static void DFS(Farm farm, int row, int col, ref int area)
		{
			Stack<List<int>> s = new Stack<List<int>>();

			//push the start row and column on the stack to start
			s.Push(new List<int> { row, col });

			while (s.Count > 0)
			{
				//pop it into coordinates
				var coord = s.Pop();
				row = coord[0];
				col = coord[1];

				//if outside of farm or not usable land, skip
				if ((row < 0)
 				 || (col < 0)
 				 || (row == farm.coordinates.Count)
 				 || (col == farm.coordinates[row].Count)
 				 || (farm.coordinates[row][col] != '-')) continue;

				//add 1 to area for each pop and set coord to be unusable
				area += 1;
				farm.coordinates[row][col] = '.';

				//push all neighbors onto stack
				s.Push(new List<int> { row + 1, col });
				s.Push(new List<int> { row, col + 1 });
				s.Push(new List<int> { row - 1, col });
				s.Push(new List<int> { row, col - 1 });
			}

			return;
		}
	}
}