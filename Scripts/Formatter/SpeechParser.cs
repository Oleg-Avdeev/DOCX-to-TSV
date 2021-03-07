using System;
using DocToTSV.Formatter.Data;

namespace DocToTSV.Formatter
{
	public class SpeechParser : AbstractParser
	{
		private static string firstSpeaker = null;
		private static string secondSpeaker = null;
		private string line;

		protected override Line ParseLine(string line)
		{
			this.line = line;
			
			SwitchSpeaker();
			var speaker = GetSpeakerName(CurrentSpeaker);

			var parsedLine = new Line();
			parsedLine.ChapterId = ChapterId;
			parsedLine.Character = Character.Get(speaker);
			parsedLine.Text = line.TrimStart('-').TrimStart();

			return parsedLine;
		}

		private string GetSpeakerName(Speaker speaker)
		{
			if (speaker == Speaker.First)
				return firstSpeaker ?? (firstSpeaker = ReadSpeakerName(speaker));
			return secondSpeaker ?? (secondSpeaker = ReadSpeakerName(speaker));
		}

		private void SwitchSpeaker()
		{
			if (CurrentSpeaker == Speaker.None)
				ResetSpeakers();

			CurrentSpeaker = (CurrentSpeaker == Speaker.First) ? Speaker.Second : Speaker.First;
		}

		private void ResetSpeakers()
		{
			firstSpeaker = null;
			secondSpeaker = null;
		}

		private string ReadSpeakerName(Speaker speaker)
		{
			Console.WriteLine();
			Console.WriteLine($"Who says \"{line}\"?");
			return Console.ReadLine();
		}
	}
}