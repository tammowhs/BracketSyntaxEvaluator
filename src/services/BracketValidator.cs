using System.Collections.Generic;

namespace BracketSyntaxEvaluator
{
	public class BracketValidator
	{
		public static ValidationResult Validate(List<Bracket> brackets)
		{
			var stack = new Stack<Bracket>();

			foreach (var bracket in brackets)
			{
				if (bracket.Variety == BracketVariety.Open)
				{
					stack.Push(bracket);
					continue;
				}

				if (stack.Count == 0)
				{
					return new ValidationResult(ValidationResultType.Faulty, null, bracket);
				}

				var lastElement = stack.Peek();

				if (lastElement.Type != bracket.Type)
				{
					var expectedBracket = new Bracket(lastElement.Type, BracketVariety.Close);

					return new ValidationResult(ValidationResultType.Faulty, expectedBracket, bracket);
				}

				stack.Pop();
			}

			return stack.Count == 0 ? new ValidationResult(ValidationResultType.Valid) : new ValidationResult(ValidationResultType.Incomplete);
		}
	}
}
