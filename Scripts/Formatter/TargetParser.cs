using System.Collections.Generic;
using DocToTSV.Formatter.Data;

namespace DocToTSV.Formatter
{
	public class TargetParser : AbstractParser
	{
		protected override List<Line> ParseLine(string line)
		{
			CurrentSpeaker = Speaker.None;

			var parsedLine = new Line();
			parsedLine.ChapterId = line;
			parsedLine.IsTarget = true;
			parsedLine.Text = "";

			ResolveChoice(line.TrimStart('-').TrimStart('—').TrimEnd('-').TrimEnd('—'));

			return new List<Line> { parsedLine };
		}

		private void ResolveChoice(string target)
		{
			if (!ChoiceParser.UnresolvedChoices.ContainsKey(target))
			{
				System.Console.WriteLine($"Couldn't resolve target [{target}]!");
				return;
			}
			
			ChapterId = ChoiceParser.UnresolvedChoices[target];
		}
	}
}