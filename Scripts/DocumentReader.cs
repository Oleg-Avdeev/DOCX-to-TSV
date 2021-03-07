using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocToTSV
{
	public class DocumentReader
	{
		public static List<string> Open(string filepath)
		{
			using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filepath, false))
			{
			    var paragraphs = wordDocument.MainDocumentPart.RootElement.Descendants<Paragraph>();
				return paragraphs.Select(p => p.InnerText).ToList();
			}
        }
	}
}