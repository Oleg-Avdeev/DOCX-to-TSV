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
		public static string ChapterId = null;
		
		protected enum Speaker { None, First, Second }
		protected static Speaker CurrentSpeaker = Speaker.None;

		public List<string> Parse(string line)
		{
			Console.WriteLine(line);
			if (ChapterId == null)
			{
				Console.WriteLine(); Console.WriteLine("Enter chapter ID".Blue());
				ChapterId = Console.ReadLine(); 
				Console.WriteLine();
			}

			var parsedLine = ParseLine(line);
			var lines = parsedLine.SelectMany(Split).ToList();
			return Render(lines);
		}

		protected List<string> Render(List<Line> lines)
		{
			return lines.Select(Render).ToList();
		}

		protected string Render(Line line)
		{
			return $"{line.ChapterId}\t{line.Character}\t{line.Text}\t{(line.Text.Length > 0 ? line.Text.Length.ToString() : "")}\t{line.Action}";
		}

		protected List<Line> Split(Line line)
		{
			if (line.IsTarget) return new List<Line> { line };
			if (line.Text.Length < 100) return new List<Line> { line };
			
			return line.Text.Split('.')
				.Where(t => t.Length > 1)
				.Select(t => new Line(line).SetText(t.TrimStart()))
				.ToList();
		}

		protected abstract List<Line> ParseLine(string line);
	}
}