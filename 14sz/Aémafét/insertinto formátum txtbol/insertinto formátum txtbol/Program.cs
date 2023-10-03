using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace insertinto_formátum_txtbol
{
    class Program
    {
        static void Main()
        {
            // A beolvasandó és módosítandó fájl elérési útja
            string inputFile = @"C:\Users\budai.bence\Desktop\OKJ\14sz\Aémafét\10.03 dolgozat\insertinto.txt";
            string outputFile = @"C:\Users\budai.bence\Desktop\OKJ\14sz\Aémafét\10.03 dolgozat\jóinsertinto.txt";

            try
            {
                // Ellenőrizzük, hogy a bemeneti fájl létezik-e
                if (File.Exists(inputFile))
                {
                    // Fájl beolvasása
                    string[] lines = File.ReadAllLines(inputFile);

                    // Módosított sorok létrehozása
                    string[] modifiedLines = new string[lines.Length];
                    for (int i = 0; i < lines.Length; i++)
                    {
                        modifiedLines[i] = "\"" + lines[i] + "\" +";
                    }

                    // Módosított sorok írása az output fájlba
                    File.WriteAllLines(outputFile, modifiedLines);

                    Console.WriteLine("Módosított fájl elkészült.");
                }
                else
                {
                    Console.WriteLine("A bemeneti fájl nem található.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }
    }
}
