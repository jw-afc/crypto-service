using System;

namespace CryptoService
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				Console.WriteLine("Please select a mode:\n(E)ncrypt\n(D)ecrypt");
				var keyInfo = Console.ReadKey(true);

				if (keyInfo.Key == ConsoleKey.E) Encrypt();
				else if (keyInfo.Key == ConsoleKey.D) Decrypt();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"\nError: {ex.Message}\n\nPress any key to exit...");
			}
			Console.ReadLine();
		}

		static void Encrypt()
		{
			Console.WriteLine("\nPlease enter a string to encrypt:");
			string plaintext = Console.ReadLine();

			Console.WriteLine("\nPlease enter a password to use:");
			string password = Console.ReadLine();
			
			Console.WriteLine($"\nYour encrypted string is:\n{StringCipher.Encrypt(plaintext, password)}\n\nPress any key to exit...");
		}

		static void Decrypt()
		{
			Console.WriteLine("\nPlease enter the encrypted string:");
			string encryptedstring = Console.ReadLine();

			Console.WriteLine("\nPlease enter the password:");
			string password = Console.ReadLine();

			Console.WriteLine($"\nYour decrypted string is:\n{StringCipher.Decrypt(encryptedstring, password)}\n\nPress any key to exit...");
		}
	}
}
