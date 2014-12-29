using System;
using System.Text;
using System.Security.Cryptography;

namespace GlobalFacade
{
	/// <summary>
	/// Helper class to encrypt and decrypt string info
	/// </summary>
	public class EncryptionManager 
	{
		public static string Decrypt(string inputString, Store store)
		{

			// If the variable is blank, return the input
			if(inputString.Equals(string.Empty))
			{
				return inputString;
			}

			// Create an instance of the encryption API
			DataProtector dp = new DataProtector(store);

			// Use the API to decrypt the input string
			// API works with bytes so we need to convert to and from byte arrays
			byte[] decryptedData = dp.Decrypt( Convert.FromBase64String( inputString ), null );
			
			// Return the decyrpted data to the string
			return Encoding.ASCII.GetString( decryptedData );
		}

		public static string Encrypt(string inputString, Store store)
		{

			// Create an instance of the encryption API
			DataProtector dp = new DataProtector(store);

			// Use the API to encrypt the input string
			// API works with bytes so we need to convert to and from byte arrays
			byte[] dataBytes = Encoding.ASCII.GetBytes( inputString );
			byte[] encryptedBytes = dp.Encrypt( dataBytes, null );

			// Return the encyrpted data to the string
			return Convert.ToBase64String( encryptedBytes );
		}

		public static string EncrytPassword(string inputedPassword)
		{
			HashAlgorithm algorithm = new SHA1CryptoServiceProvider();
			return Convert.ToBase64String(algorithm.ComputeHash(Encoding.Unicode.GetBytes(inputedPassword)));
		}




		public static bool VerifyPassword(string inputedPassword, string currentPassword)
		{
			string encryptedPassword = EncrytPassword(inputedPassword);
			return (encryptedPassword == currentPassword)?true:false;
		}
	}
}
