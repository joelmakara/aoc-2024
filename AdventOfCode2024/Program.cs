string filePath = @"C:\path\to\your\input\1\input.txt"; // Adjust to your file path

var lines = new List<string>(File.ReadAllLines(filePath));

foreach (string line in lines)
{
    Console.WriteLine(line);
}