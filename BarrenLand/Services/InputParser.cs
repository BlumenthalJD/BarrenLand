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

			//split input into coordinate groups
			var barrenRectStrings = input.Split(',');

			//go through coordinate groups
			foreach (var barrenRectString in barrenRectStrings)
			{
				//split by spaces to get separate numbers
				var coords = barrenRectString.Split(' ');

				//trim all excess characters from each number
				for (int i = 0; i < coords.Length; i++)
				{
					coords[i] = coords[i].Trim(new Char[] { '{', '}', '"', '”', '“' });
				}

				//eliminate potential empty strings
				coords = coords.Where(x => x != "").ToArray();

				//create new barren rectangle
				var barrenRectangle = new BarrenRectangle
				{
					bottomLeftX = Convert.ToInt32(coords[0]),
					bottomLeftY = Convert.ToInt32(coords[1]),
					topRightX = Convert.ToInt32(coords[2]),
					topRightY = Convert.ToInt32(coords[3])
				};

				//check first coordinate for boundaries
				if (barrenRectangle.bottomLeftX < 0
				 || barrenRectangle.bottomLeftX > 399) throw new ArgumentOutOfRangeException("First parameter must be between 0 and 399");
				if (barrenRectangle.bottomLeftY < 0
				 || barrenRectangle.bottomLeftY > 599) throw new ArgumentOutOfRangeException("Second parameter must be between 0 and 599");

				//check second coordinate for boundaries
				if (barrenRectangle.topRightX < 0
				 || barrenRectangle.topRightX > 399) throw new ArgumentOutOfRangeException("Third parameter must be between 0 and 399");
				if (barrenRectangle.topRightY < 0
				 || barrenRectangle.topRightY > 599) throw new ArgumentOutOfRangeException("Fourth parameter must be between 0 and 599");

				//add rectangle to list of barren rectangles
				barrenRectangles.Add(barrenRectangle);
			}

			return barrenRectangles;
		}

	}
}