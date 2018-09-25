//Namespaces die benutzt werden. Dank ihnen muss ich nicht z.B. System.Console.WriteLine schreiben ¦ global::Namensraum.Klasse.Methode(Parameter), (global:: wird nur bei Namenskollisionen benutzt)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruch
{
	internal class Bruchrechnung
	{
		private static void Main(string[] args)
		{
			Bruch b1 = new Bruch(), b2 = new Bruch();

			Console.WriteLine("1. Bruch");
			b1.Frage();
			b1.Kuerze();
			b1.Zeige();

			Console.WriteLine("\n2.Bruch");
			b2.Frage();
			b2.Kuerze();
			b2.Zeige();

			Console.WriteLine("\nSumme");
			b1.Addiere(b2);
			b1.Zeige();
			Console.ReadLine();

			//-----------------------------------------------------------------------------------------------------------------------------------------------

			Console.WriteLine("K\u00FCrzen von Br\u00FCchen\n------------------\n");
			Bruch b = new Bruch();
			b.Frage();
			b.Kuerze();
			b.Etikett = "Der gek\u00FCrzte Bruch:";
			b.Zeige();
			Console.ReadLine();
		}
	}
}
