using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using BarrenLand.Models;

namespace BarrenLand.Services
{
	public class InputParser
	{
		public static List<BarrenRectangle> ParseInput(string input)
		{
			//regex to check if the input pattern matches the desired pattern
			Regex r = new Regex(@"^\{([“""](\d*) (\d*) (\d*) (\d*)[”""](, )*)*\}$");
			if (!r.IsMatch(input)) throw new ArgumentException("Invalid input. Input must be in the form of {\"0 0 0 0\", \"0 0 0 0\"}");

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