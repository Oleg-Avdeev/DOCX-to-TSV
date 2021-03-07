using System;
using System.IO;
using DocToTSV.Formatter;

namespace DocToTSV
{
    public class Program
    {
        private static int Main(string[] args)
        {
			if (args.Length == 0) return Error(0, "Provide filepath as the argument");

			var lines = DocumentReader.Open(args[0]);
			Info($"Successfuly read {lines.Count} lines");

			var formatted = LinesFormatter.Format(lines);
			Info($"Successfuly formatted {formatted.Count} lines");

			var tsvFilepath = args[0].Split(".")[0] + ".tsv";
			File.WriteAllLines(tsvFilepath, formatted);

			return 0;
        }

		private static int Error(int code, string message)
		{
			Console.WriteLine($"Error: {message}");
			return code;
		}

		private static void Info(string message)
		{
			Console.WriteLine($"{message}");
		}
    }
}
