using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MoreLinq;

namespace FunctionalStuff
{
	public static class Problem59
	{
		public static int Solve(string filename)
		{
			var bytesCrypted = File.ReadAllText(filename).TrimEnd('.').Split(',').Select(byte.Parse).ToArray();
			var resKey = GetKeys().First(
				key => (bytesCrypted.Batch(3).Select(bytes => Xor(key, bytes.ToArray()))
					.All(batch => IsCommonEnglish(batch.ToArray()))));

			var plainBytes = bytesCrypted.Batch(3).SelectMany(bytes => Xor(resKey, bytes.ToArray())).ToArray();
			File.WriteAllBytes("key_" + new string(Encoding.ASCII.GetChars(resKey)) + "_out.txt", plainBytes);

			return plainBytes.Sum(b => b);
		}

		static IEnumerable<byte[]> GetKeys()
		{
			const string alphabet = "abcdefghijklmnopqrstuvwxyz";
			return (from a in alphabet
					from b in alphabet
					from c in alphabet
					select new[] {a, b, c}).Select(r => r.Select(c => Encoding.ASCII.GetBytes(new[] {c})[0]).ToArray());
		}

		static byte[] Xor(byte[] key, byte[] crypted)
		{
			return Enumerable.Zip(crypted, key, (b, b1) => (byte)(b ^ b1)).ToArray();
		}

		private static bool IsCommonEnglish(byte[] plain)
		{
			return Encoding.ASCII.GetChars(plain).All(
				c => (Char.IsLetterOrDigit(c) 
					|| Char.IsPunctuation(c) 
					|| Char.IsWhiteSpace(c) 
					|| c == '\n' || c == '\r'));
		}
	}
}