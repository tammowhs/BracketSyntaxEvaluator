using System;
using System.Collections.Generic;

namespace BracketSyntaxEvaluator
{
	public class BracketParser
	{
		private static readonly Dictionary<char, Bracket> Brackets = new()
		{
			{ '(', new Bracket(BracketType.Round, BracketVariety.Open) },
			{ ')', new Bracket(BracketType.Round, BracketVariety.Close) },
			{ '[', new Bracket(BracketType.Square, BracketVariety.Open) },
			{ ']', new Bracket(BracketType.Square, BracketVariety.Close) },
			{ '{', new Bracket(BracketType.Curly, BracketVariety.Open) },
			{ '}', new Bracket(BracketType.Curly, BracketVariety.Close) },
			{ '<', new Bracket(BracketType.Angle, BracketVariety.Open) },
			{ '>', new Bracket(BracketType.Angle, BracketVariety.Close) }
		};

		public static List<Bracket> ParseExpression(string input)
		{
			var chars = input.ToCharArray();

			var brackets = new List<Bracket>();

			foreach (var c in chars)
			{
				var bracket = Brackets.GetValueOrDefault(c);

				if (bracket == null)
				{
					throw new ArgumentException($"Invalid character: {c}");
				}

				brackets.Add(bracket);
			}

			return brackets;
		}
	}
}
