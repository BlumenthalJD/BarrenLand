using System.Collections.Generic;

namespace BarrenLand
{
	public class Farm
	{
		public Farm()
		{
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
	}
}