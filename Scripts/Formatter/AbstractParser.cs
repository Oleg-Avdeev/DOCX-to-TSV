using System;
using System.Collections.Generic;
using System.Linq;
using DocToTSV.Formatter.Data;

namespace DocToTSV.Formatter
{
	public interface IParser
	{
		List<string> Parse(string line);
	}

	public abstract class AbstractParser : IParser
	{
		protected enum Speaker { None, First, Second }
		protected static Speaker CurrentSpeaker = Speaker.None;

		protected static string ChapterId = null;

		public List<string> Parse(string line)
		{
			if (ChapterId == null)
			{
				Console.WriteLine(); Console.WriteLine("Enter chapter ID");
				ChapterId = Console.ReadLine();
			}

			var parsedLine = ParseLine(line);
			var lines = Split(parsedLine);
			return Render(lines);
		}

		protected List<string> Render(List<Line> lines)
		{
			return lines.Select(Render).ToList();
		}

		protected string Render(Line line)
		{
			return $"{line.ChapterId}\t{line.Character}\t{line.Text}\t{line.Text.Length}\t{line.Action}";
		}

		protected List<Line> Split(Line line)
		{
			return line.Text.Split('.')
				.Where(t => t.Length > 1)
				.Select(t => new Line(line).SetText(t.TrimStart()))
				.ToList();
		}

		protected abstract Line ParseLine(string line);
	}
}