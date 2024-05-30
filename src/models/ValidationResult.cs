using System;

namespace BracketSyntaxEvaluator
{
	public record ValidationResult
	{
		public ValidationResultType ValidationResultType { get; }

		public Bracket? ExpectedBracket { get; }

		public Bracket? ActualBracket { get; }


		public ValidationResult(ValidationResultType validationResultType, Bracket? expectedBracket, Bracket? actualBracket)
		{
			if (validationResultType == ValidationResultType.Faulty && (actualBracket == null))
			{
				throw new ArgumentException("ActualBracketType most not be null when EvaluationResultType is Faulty");
			}

			ValidationResultType = validationResultType;
			ExpectedBracket = expectedBracket;
			ActualBracket = actualBracket;
		}

		public ValidationResult(ValidationResultType evaluationResultType) : this(evaluationResultType, null, null)
		{
		}
	}
}
