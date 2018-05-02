using System;
using sha_512;

namespace pepper {
	public class Pepper {
		public static string Generate ()
		{
			System.Random rnd = new System.Random();
			int first = rnd.Next(0, 61), second = rnd.Next(0, 61);
			char f = '0', s = '0';
			bool one = false, two = false;
			if (first > 9) {
				if (first > 35) {
					first += 61;
				} else {
					first += 55;
				}
				f = (char) first;
				one = true;
			}
			if (second > 9) {
				if (second > 35) {
					second += 61;
				} else {
					second += 55;
				}
				s = (char) second;
				two = true;
			}

			string pepper = (two ? s.ToString() : second.ToString()) + (one ? f.ToString() : first.ToString());
			return pepper;
		}

		public static bool Check (string password, string hashed, string salt)
		{
			for (int i = 0; i < 62; ++i)
			{
				for (int j = 0; j < 62; ++j) 
				{
					int first = i, second = j;
					char f = '0', s = '0';
					bool one = false, two = false;
					if (first > 9) {
						if (first > 35) {
							first += 61;
						} else {
							first += 55;
						}
						f = (char) first;
						one = true;
					}
					if (second > 9) {
						if (second > 35) {
							second += 61;
						} else {
							second += 55;
						}
						s = (char) second;
						two = true;
					}

					string pepper = (two ? s.ToString() : second.ToString()) + (one ? f.ToString() : first.ToString()); 

					string aux = password + pepper;
					aux = salt + SHA_512.GenerateSHA512String(aux);

					if (aux == hashed) return true;
				}
			}

			return false;
		}
	}
}