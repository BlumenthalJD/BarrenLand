using System.Collections.Generic;

namespace BarrenLand.Models
{
	public class Farm
	{
		public Farm()
		{
			//initialize farm with "-" for each coordinate
			for (int i = 0; i < 400; i++)
			{
				coordinates.Add(new List<char>());
				for (int j = 0; j < 600; j++)
				{
					coordinates[i].Add('-');
				}
			}
		}
		public List<List<char>> coordinates = new List<List<char>>();

		public void SetBarrenFarmland(List<BarrenRectangle> barrenRectangles)
		{
			//set barren rectangle land to "."
			foreach (var rectangle in barrenRectangles)
			{
				for (int i = rectangle.bottomLeftX; i <= rectangle.topRightX; i++)
				{
					for (int j = rectangle.bottomLeftY; j <= rectangle.topRightY; j++)
					{
						coordinates[i][j] = '.';
					}
				}
			}
		}
	}
}