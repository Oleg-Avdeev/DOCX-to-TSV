using DocToTSV.Formatter.Data;

namespace DocToTSV.Formatter
{
	public class NarratorParser : AbstractParser
	{
		private static readonly string narrator = "Нарратор";

		protected override Line ParseLine(string line)
		{
			CurrentSpeaker = Speaker.None;

			var parsedLine = new Line();
			parsedLine.ChapterId = ChapterId;
			parsedLine.Character = narrator;
			parsedLine.Text = line;

			return parsedLine;
		}
	}
}