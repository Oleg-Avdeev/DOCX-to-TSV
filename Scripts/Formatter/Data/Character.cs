using System.Collections.Generic;
using System.Linq;

namespace DocToTSV.Formatter.Data
{
	public class Character
	{
		private static readonly List<string> characters = new List<string>() {
			"Агата", "Елена", "Кристина", "Михаил", "Главный-Герой", "Дух Дождя"	
		};

		public static string Get(string name)
		{
			var fullName = characters.FirstOrDefault(c => c == name) 
						?? characters.FirstOrDefault(c => c.StartsWith(name));
			return fullName;
		}
	}
}