using System.Collections.Generic;
using System.Linq;
using DocToTSV.Formatter.Data;

namespace DocToTSV.Formatter
{
	public class LinesFormatter
	{
		private static readonly IParser narratorParser = new NarratorParser();
		private static readonly IParser speechParser = new SpeechParser();

		public static List<string> Format(List<string> lines)
		{
			return lines.Where(l => l.Length > 1).SelectMany(Format).ToList();
		}

		public static List<string> Format(string line)
		{
			if (line.TrimStart(' ').StartsWith("-"))
				return speechParser.Parse(line);
			
			return narratorParser.Parse(line);
		}
	}
}