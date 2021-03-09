namespace DocToTSV.Formatter.Data
{
	public sealed class Line
	{
		public string ChapterId;
		public string Character;
		public string Text;
		public string Action;

		public bool IsTarget;

		public Line()
		{
		}

		public Line(Line line)
		{
			ChapterId = line.ChapterId;
			Character = line.Character;
			Text = line.Text;
			Action = line.Action;
		}

		public Line SetText(string text)
		{
			Text = text;
			return this;
		}
	}
}