namespace BarrenLand
{
	public class Field
	{
		public Field()
		{
			for (int i = 0; i < coordinates.Rank; i++)
			{
				for (int j = 0; j < coordinates.GetLength(i); j++)
				{
					coordinates[i, j] = 0;
				}
			}
		}
		public int[,] coordinates = new int[399, 599];
	}
}