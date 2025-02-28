﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace J3000_23f
{
	internal class Program
	{
		class Tanulo
		{
			public int tanulokod;
			public string nev;
			public string matinfo;
			public string angol;
			public string nyelv2;
			public string nem;
			public int egyuttlakoszam;
			public int testverszam;

			public Tanulo(int tanulokod, string nev, string matinfo, string angol, string nyelv2, string nem, int egyuttlakoszam, int testverszam)
			{
				this.tanulokod = tanulokod;
				this.nev = nev;
				this.matinfo = matinfo;
				this.angol = angol;
				this.nyelv2 = nyelv2;
				this.nem = nem;
				this.egyuttlakoszam = egyuttlakoszam;
				this.testverszam = testverszam;
			}
		}

		static List<Tanulo> Beolvas(string fajlnev)
		{
			List<Tanulo> lista = new List<Tanulo>();

			string[] sorok = File.ReadAllLines(fajlnev);
			// a sorok változó tartalma most valami ilyesmi:
			/** /
			 [	"1;Avon Mór;alfa;4. Kis;német;F;4;1", 
				"2;Bakt Ernõ;alfa;4. Kis;spanyol;F;4;1", 
				"3;Bal Margó;alfa;4. Kis;spanyol;L;2;0", 
				... ]
			/**/

			foreach (string sor in sorok) // sor pl a következő: "1;Avon Mór;alfa;4. Kis;német;F;4;1"
			{
				string[] sortomb = sor.Split(';'); // sortomb = ["1", "Avon Mór", "alfa", "4. Kis", "német", "F", "4", "1"]
				Tanulo tanulo = new Tanulo(int.Parse(sortomb[0]), sortomb[1], sortomb[2], sortomb[3], sortomb[4], sortomb[5], int.Parse(sortomb[6]), int.Parse(sortomb[7]));
				lista.Add(tanulo);
			}
			return lista;
		}

		static int Adott_nemu_tanulok_szama(List<Tanulo> lista, string nem)
		{
			int result = 0;
			foreach (Tanulo tanulo in lista)
			{
				if (tanulo.nem == nem)
				{
					result++;
				}
			}
			return result;
		}

		static void Main(string[] args)
		{
			List<Tanulo> lista = Beolvas("input.txt");
            Console.WriteLine("1. Hány diák tanul az osztályban?");
            Console.WriteLine(lista.Count);
			Console.WriteLine("2. Hány fiú tanul az osztályban?");
            Console.WriteLine(Adott_nemu_tanulok_szama(lista, "F"));
            Console.WriteLine("3. Hány lány tanul az osztályban?");
			Console.WriteLine(Adott_nemu_tanulok_szama(lista, "L"));
		}
	}
}
