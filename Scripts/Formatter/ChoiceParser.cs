using System.Text.RegularExpressions;
using System.Collections.Generic;
using DocToTSV.Formatter.Data;
using System.Linq;

namespace DocToTSV.Formatter
{
	public class ChoiceParser : AbstractParser
	{
		public static readonly Dictionary<string, string> UnresolvedChoices = new Dictionary<string, string>();
		private static readonly string choiceCharacter = "Нарратор";
		private static readonly Regex choiceRE = new Regex(@"([^|()]+)");

		protected override List<Line> ParseLine(string line)
		{
			CurrentSpeaker = Speaker.None;
			return choiceRE.Matches(line).Select(m => m.Value).Select(CreateLine).ToList();	
		}

		private Line CreateLine(string choice)
		{
			var id = AddChoice(choice);

			return new Line() {
				ChapterId = ChapterId,
				Character = choiceCharacter,
				Text = choice,
				Action = $"[{id}]"
			};
		}

		private string AddChoice(string choice)
		{
			var newId = $"{ChapterId}-{UnresolvedChoices.Count}";
			UnresolvedChoices.Add(choice, newId);
			return newId;
		}
	}
}