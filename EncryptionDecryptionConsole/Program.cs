// See https://aka.ms/new-console-template for more information
using EncryptionDecryptionConsole;

//Console.WriteLine("Hello, World!");
string stringTest = string.Empty;
stringTest = Console.ReadLine();

EncryptDecrypt service = new EncryptDecrypt();
string encryptedText = service.EncryptString(stringTest);
string decryptedText = service.DecryptString(encryptedText);

Console.WriteLine(encryptedText);
Console.WriteLine(decryptedText);

Console.ReadLine();
