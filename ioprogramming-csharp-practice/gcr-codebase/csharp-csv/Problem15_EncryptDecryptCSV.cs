using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class Problem15_EncryptDecryptCSV
{
    static void Main()
    {
        string inputFile = "employees.csv";
        string encryptedFile = "employees_encrypted.csv";
        string decryptedFile = "employees_decrypted.csv";
        string key = "mysecretkey12345"; // 16 chars for AES

        // Encrypt
        var data = File.ReadAllText(inputFile);
        var encrypted = EncryptString(data, key);
        File.WriteAllText(encryptedFile, encrypted);
        Console.WriteLine("CSV encrypted: " + encryptedFile);

        // Decrypt
        var encryptedData = File.ReadAllText(encryptedFile);
        var decrypted = DecryptString(encryptedData, key);
        File.WriteAllText(decryptedFile, decrypted);
        Console.WriteLine("CSV decrypted: " + decryptedFile);
    }

    static string EncryptString(string plainText, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16];
            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] buffer = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(encryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }

    static string DecryptString(string cipherText, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16];
            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] buffer = Convert.FromBase64String(cipherText);
            return Encoding.UTF8.GetString(decryptor.TransformFinalBlock(buffer, 0, buffer.Length));
        }
    }
}