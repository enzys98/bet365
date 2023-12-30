using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CEBet365Placer.Constants;

public class Guard
{
	internal class Algorithms
	{
		public static string SaltString(string value)
		{
			value = value.Replace("a", "!");
			value = value.Replace("z", "?");
			value = value.Replace("b", "}");
			value = value.Replace("c", "{");
			value = value.Replace("d", "]");
			value = value.Replace("e", "[");
			return value;
		}

		public static string DesaltString(string value)
		{
			value = value.Replace("?", "z");
			value = value.Replace("!", "a");
			value = value.Replace("}", "b");
			value = value.Replace("{", "c");
			value = value.Replace("]", "d");
			value = value.Replace("[", "e");
			return value;
		}

		public static string DecryptData(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(DesaltString(Key)));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
			byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(DesaltString(Salt))));
			return DecryptString(value, key, bytes);
		}

		public static string EncryptData(string value)
		{
			string @string = Encoding.Default.GetString(Convert.FromBase64String(DesaltString(Key)));
			byte[] key = SHA256.Create().ComputeHash(Encoding.ASCII.GetBytes(@string));
			byte[] bytes = Encoding.ASCII.GetBytes(Encoding.Default.GetString(Convert.FromBase64String(DesaltString(Salt))));
			return EncryptString(value, key, bytes);
		}

		public static string EncryptString(string plainText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateEncryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			byte[] bytes = Encoding.ASCII.GetBytes(plainText);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(array, 0, array.Length);
		}

		public static string DecryptString(string cipherText, byte[] key, byte[] iv)
		{
			Aes aes = Aes.Create();
			aes.Mode = CipherMode.CBC;
			aes.Key = key;
			aes.IV = iv;
			MemoryStream memoryStream = new MemoryStream();
			ICryptoTransform transform = aes.CreateDecryptor();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			string empty = string.Empty;
			try
			{
				byte[] array = Convert.FromBase64String(cipherText);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.FlushFinalBlock();
				byte[] array2 = memoryStream.ToArray();
				return Encoding.ASCII.GetString(array2, 0, array2.Length);
			}
			finally
			{
				memoryStream.Close();
				cryptoStream.Close();
			}
		}

		public static string Encrypt(string clearText)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(clearText);
			using Aes aes = Aes.Create();
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("datexd", new byte[13]
			{
				73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
				100, 101, 118
			});
			aes.Key = rfc2898DeriveBytes.GetBytes(32);
			aes.IV = rfc2898DeriveBytes.GetBytes(16);
			aes.Padding = PaddingMode.PKCS7;
			using MemoryStream memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes, 0, bytes.Length);
				cryptoStream.Close();
			}
			clearText = Convert.ToBase64String(memoryStream.ToArray());
			return clearText;
		}

		public static string Decrypt(string cipherText)
		{
			cipherText = cipherText.Replace(" ", "+");
			byte[] array = Convert.FromBase64String(cipherText);
			using Aes aes = Aes.Create();
			Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes("datexd", new byte[13]
			{
				73, 118, 97, 110, 32, 77, 101, 100, 118, 101,
				100, 101, 118
			});
			aes.Key = rfc2898DeriveBytes.GetBytes(32);
			aes.IV = rfc2898DeriveBytes.GetBytes(16);
			aes.Padding = PaddingMode.PKCS7;
			using MemoryStream memoryStream = new MemoryStream();
			using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
			{
				cryptoStream.Write(array, 0, array.Length);
			}
			cipherText = Encoding.Unicode.GetString(memoryStream.ToArray());
			return cipherText;
		}

		public static string CalculateMD5(string filename)
		{
			using MD5 mD = MD5.Create();
			using FileStream inputStream = File.OpenRead(filename);
			return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
		}
	}

	public static string Key { get; set; }

	public static string Salt { get; set; }

	public static void Start_Session()
	{
		try
		{
			Key = Algorithms.SaltString(Convert.ToBase64String(Encoding.Default.GetBytes(Setting.instance.key)));
			Salt = Algorithms.SaltString(Convert.ToBase64String(Encoding.Default.GetBytes(Setting.instance.salt)));
		}
		catch
		{
			Key = Algorithms.SaltString(Convert.ToBase64String(Encoding.Default.GetBytes(Setting.instance.key)));
			Salt = Algorithms.SaltString(Convert.ToBase64String(Encoding.Default.GetBytes(Setting.instance.salt)));
		}
	}
}
