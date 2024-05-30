using System;

namespace BracketSyntaxEvaluator
{
	public class BracketEvaluator
	{
		public static int GetBracketValue(BracketType actualBracketType)
		{
			return actualBracketType switch
			{
				BracketType.Round => 3,
				BracketType.Square => 57,
				BracketType.Curly => 1197,
				BracketType.Angle => 25137,
				_ => throw new ArgumentException("Invalid BracketType"),
			};
		}
	}
}
