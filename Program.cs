using System;
using System.IO;

namespace BracketSyntaxEvaluator
{
	public class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Bitte gib den absoluten Pfad zur Datei ein: ");

			string? filePath;
			do
			{
				filePath = Console.ReadLine();
			} while (string.IsNullOrEmpty(filePath));

			var expressions = File.ReadLines(filePath);

			var sumFaultyExpressions = 0;

			foreach (var expression in expressions)
			{
				var parsedExpression = BracketParser.ParseExpression(expression);

				var validationResult = BracketValidator.Validate(parsedExpression);

				if (validationResult.ValidationResultType == ValidationResultType.Faulty)
				{
					var actualBracketValue = BracketEvaluator.GetBracketValue(validationResult.ActualBracket!.Type);

					sumFaultyExpressions += actualBracketValue;
				}
			}

			Console.WriteLine($"Die Gesamtzahl der Syntaxfehler für diese Datei beträgt {sumFaultyExpressions} Punkte!");
		}
	}
}
