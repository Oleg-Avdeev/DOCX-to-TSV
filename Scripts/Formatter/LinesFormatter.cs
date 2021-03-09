using System.Collections.Generic;
using System.Linq;

namespace DocToTSV.Formatter
{
	public class LinesFormatter
	{
		private static readonly IParser narratorParser = new NarratorParser();
		private static readonly IParser speechParser = new SpeechParser();
		private static readonly IParser choiceParser = new ChoiceParser();
		private static readonly IParser targetParser = new TargetParser();

		public static List<string> Format(List<string> lines)
		{
			return lines.Where(l => l.Length > 1).SelectMany(Format).ToList();
		}

		public static List<string> Format(string line)
		{
			line = line.TrimStart(' ');
			
			if (line.StartsWith("-"))
				return speechParser.Parse(line);
			
			if (line.StartsWith("("))
				return choiceParser.Parse(line);
			
			if (line.StartsWith("--") || line.StartsWith("—"))
				return targetParser.Parse(line);

			return narratorParser.Parse(line);
		}
	}
}