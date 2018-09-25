using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruch
{
	public class Bruch
	{
		//Default Werte für Zähler und Nenner
		private int _zaehler, _nenner = 1; //wird mit 1 initialisiert, da man nichts durch 0 teilen sollte

		private string _etikett = "";    //Die Ref.typ-Init. auf null wird ersetzt

		public int Zaehler
		{
			//Zähler Eigenschaft
			get
			{
				return _zaehler;
			}
			set
			{
				_zaehler = value;
			}
		}

		public int Nenner
		{
			//Nenner Eigenschaft
			get
			{
				return _nenner;
			}
			set
			{
				if (value != 0)//Verhindert dass man den Nenner auf 0 setzen kann
					_nenner = value;
			}
		}

		public string Etikett
		{
			get
			{
				return _etikett;
			}
			set
			{
				if (value.Length <= 40)
					_etikett = value;
				else
					_etikett = value.Substring(0, 40);
			}
		}

		public void Kuerze()
		{
			//Methode um den Bruch zu kürzen
			//grössten gemeinsamen Teiler mit dem Euklidischen Algorithmus bestimmen (Modulo Variante)
			if (_zaehler != 0)
			{
				int rest;
				int ggt = Math.Abs(_zaehler);
				int divisor = Math.Abs(_nenner);
				do
				{
					rest = ggt % divisor;
					ggt = divisor;
					divisor = rest;
				} while (rest > 0);
				_zaehler /= ggt;
				_nenner /= ggt;
			}
			else
				_nenner = 1;
		}

		public void Addiere(Bruch b)
		{
			//Additionsfunktion
			_zaehler = _zaehler * b._nenner + b._zaehler * _nenner;
			_nenner = _nenner * b._nenner;
			Kuerze();
		}

		public bool AddiereZwei(int zpar, int npar, bool autokurz)
		{
			if (npar != 0)
			{
				_zaehler = _zaehler * npar + zpar * _nenner;
				_nenner = _nenner * npar;
				if (autokurz)
					Kuerze();
				return true;
			}
			else
				return false;
		}

		public bool Frage()
		{
			try
			{
				//Liest die Werte für den Bruch aus
				Console.Write("Z\u00E4hler: ");
				int z = Convert.ToInt32(Console.ReadLine());
				Console.Write("Nenner: ");
				int n = Convert.ToInt32(Console.ReadLine());
				Zaehler = z;
				Nenner = n;
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void Zeige()
		{
			string luecke = "";
			for (int i = 1; i <= _etikett.Length; i++)
				luecke = luecke + " ";
			//Gibt den Bruch mit der Bruchstrich Darstellung heraus
			Console.WriteLine(" {0} {1}\n {2} -----\n {0} {3}\n", luecke, _zaehler, _etikett, _nenner);
		}
	}
}
