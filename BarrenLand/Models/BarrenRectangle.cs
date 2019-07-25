namespace BarrenLand.Models
{
	//just a class to store the barren land coordinates
	public class BarrenRectangle
	{
		public int bottomLeftX { get; set; }
		public int bottomLeftY { get; set; }
		public int topRightX { get; set; }
		public int topRightY { get; set; }
	}
}