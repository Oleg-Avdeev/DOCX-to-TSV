# Toska: .docx To .tsv Converter
Small dotnet core console app for converting script documents into Toska-TSV format.

`dotnet run path/file.docx`

## Input Document
  Document consists of Narrative, Speech and Choice lines.
  - Choice line format: `(choice1|choice2|choice3)`;
  - Speech line starts with `"- "`;
  - Otherwist line is parsed as a narrative line.

## Ouput TSV
Output tsv file is formatted into a Toska spreadsheet format:
|Chapter|Character|Text|Symbols Count|Action