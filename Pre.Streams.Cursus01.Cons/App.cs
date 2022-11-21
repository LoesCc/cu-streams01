using System.Text;

namespace Pre.Streams.Cursus01.Cons;

public class App
{
    public void Run()
    {
        // pas eventueel hieronder pad en bestandsnaam aan
        string fileContent = ReadFile(@"c:\howest\bestand1.txt");
        Console.WriteLine($"Bestandsinhoud: {fileContent}");


        string content = Console.ReadLine();
        string fullFilePath = @"c:\howest\bestand2.txt";
        WriteFile(fullFilePath, content);
    }

    private bool WriteFile(string fullFilePath, string content)
    {
        bool isSuccessfullyWritten = false;
        try
        {
            using (StreamWriter streamWriter = new StreamWriter(fullFilePath))
            {
                streamWriter.Write(content);
            }

            isSuccessfullyWritten = true;
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"De map bestaat niet op deze computer");
        }
        catch (IOException)
        {
            Console.WriteLine($"Het bestand {fullFilePath} kan niet weggeschreven worden.\n" +
                              $"Probeer het geopende bestand op die locatie te sluiten.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Er is een fout opgetreden. {e.Message}");
        }

        return isSuccessfullyWritten;
    }


    private string ReadFile(string fullFilePath)
    {
        string fileContent = "";

        try
        {
            using (StreamReader streamReader = new StreamReader(fullFilePath, Encoding.Default, true))
            {
                fileContent = streamReader.ReadToEnd();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"Het bestand {fullFilePath} is niet gevonden.");
        }
        catch (IOException)
        {
            Console.WriteLine($"Het bestand {fullFilePath} kan niet geopend worden.\nProbeer het te sluiten.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Er is een fout opgetreden. {e.Message}");
        }

        return fileContent;
    }
}