using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CryptoService.Test
{
	/// <summary>
	/// https://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
	/// </summary>
	[TestClass]
	public class CryptoServiceTests
	{
		[TestMethod]
		public void CanEncryptAndDecryptSampleStringCorrectly()
		{
			// Arrange
			var plainText = "This is my sample plain text message";
			var passPhrase = "supersecretpassword";

			// Act
			var cipherText = StringCipher.Encrypt(plainText, passPhrase);
			var decryptedText = StringCipher.Decrypt(cipherText, passPhrase);

			// Assert
			Assert.AreEqual(plainText, decryptedText);
		}

		[TestMethod]
		public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherText()
		{
			// Arrange
			var plainText = "This is my sample plain text message";
			var passPhrase = "supersecretpassword";

			// Act
			var cipherText1 = StringCipher.Encrypt(plainText, passPhrase);
			var cipherText2 = StringCipher.Encrypt(plainText, passPhrase);

			// Assert
			Assert.AreNotEqual(cipherText1, cipherText2);
		}

		[TestMethod]
		public void EncryptingTheSamePlainTextWithTheSamePasswordMultipleTimesProducesDifferentCipherTextButBothCanBeDecryptedCorrectly()
		{
			// Arrange
			var plainText = "This is my sample plain text message";
			var passPhrase = "supersecretpassword";

			// Act
			var cipherText1 = StringCipher.Encrypt(plainText, passPhrase);
			var cipherText2 = StringCipher.Encrypt(plainText, passPhrase);
			var decryptedText1 = StringCipher.Decrypt(cipherText1, passPhrase);
			var decryptedText2 = StringCipher.Decrypt(cipherText2, passPhrase);

			// Assert
			Assert.AreEqual(decryptedText1, plainText);
			Assert.AreEqual(decryptedText1, decryptedText2);
		}
	}
}
