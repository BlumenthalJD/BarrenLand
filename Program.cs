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
			Console.WriteLine("Please input the range of barren land:");
			string input = Console.ReadLine();
			Console.WriteLine("Your input was " + input);
			var barrenRectanlges = ParseInput(input);
			var field = new Field();


			return;
		}


		static List<BarrenRectangle> ParseInput(string input)
		{
			if (input[0] != '{') return new List<BarrenRectangle>();
			if (input[input.Length - 1] != '}') return new List<BarrenRectangle>();

			var barrenRectangles = new List<BarrenRectangle>();

			var barrenRectStrings = input.Split(',');

			foreach (var barrenRectString in barrenRectStrings)
			{
				var coords = barrenRectString.Split(' ');

				for (int i = 0; i < coords.Length; i++)
				{
					coords[i] = coords[i].Trim(new Char[] { '{', '}', '"', '”', '“' });
				}

				coords = coords.Where(x => x != "").ToArray();

				var barrenRectangle = new BarrenRectangle
				{
					bottomLeftX = Convert.ToInt32(coords[0]),
					bottomLeftY = Convert.ToInt32(coords[1]),
					topRightX = Convert.ToInt32(coords[2]),
					topRightY = Convert.ToInt32(coords[3])
				};
				barrenRectangles.Add(barrenRectangle);
			}

			return barrenRectangles;
		}
	}
}
