using System;
using System.IO;

namespace CodeJam
{
	class Program
	{
		static void Main(string[] args)
		{
			FileStream fs = File.OpenRead("input.txt");
			FileStream fsOut = File.OpenWrite("out.txt");

			string hint = "ejp mysljylc kd kxveddknmc re jsicpdrysi rbcpc ypc rtcsra dkh wyfrepkym veddknkmkrkcd de kr kd eoya kw aej tysr re ujdr lkgc jvz";
			string output = "our language is impossible to understand there are twenty six factorial possibilities so it is okay if you want to just give upq";
			int aChar = (int)'a';
			char[] dictGooglerese = new char[26];
			char[] dictEnglish = new char[26];
			int bSumm = 0;

			//create dictinary
			for (int i = 0; i < hint.Length; ++i)
			{
				int hG = (int)hint[i] - aChar;
				int hE = (int)output[i] - aChar;
				if (hG >= 0 && hG < dictGooglerese.Length && dictEnglish[hG] == '\0')
				{
					dictEnglish[hG] = output[i];
					dictGooglerese[hE] = hint[i];
					bSumm += hG;
				}
			}

			//add one last letter;
			for (int i = 0; i < dictGooglerese.Length; ++i)
			{
				char c = (char)(aChar + i);
				if (dictGooglerese[i] == '\0') // find zero position;
				{
					dictGooglerese[i] = (char)(325 - bSumm + aChar);
					dictEnglish[325 - bSumm] = (char)(i + aChar);
				}
			}

			while(true)
			{	
				int inChar = fs.ReadByte();
				if (inChar < 0)
					break;
				if (inChar >= aChar && inChar - aChar < dictGooglerese.Length)
					fsOut.WriteByte((byte)dictEnglish[(int)inChar - aChar]);
				else
					fsOut.WriteByte((byte)inChar);
			}

			fs.Close();
			fsOut.Close();

			Console.Write("done");
		}
	}
}
