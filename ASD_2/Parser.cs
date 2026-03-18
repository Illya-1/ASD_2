namespace ASD_2;

public static class Parser
{
    public static void ArrayToFile(string filename, (int user, int reverses)[] results)
    {
        string[] lines = new string[results.Length];
        lines[0] = $"{results[0].user}";
        for (int i = 1; i < results.Length; i++)
        {
            lines[i] = $"{results[i].user} {results[i].reverses}";
        }
        
        File.WriteAllLines(filename, lines);
    }

    public static int[,] FileToArray(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        string[] line0 = lines[0].Split(' ');
        int nUsers = int.Parse(line0[0]);
        int nFilms = int.Parse(line0[1]);

        foreach (var fl in lines)
        {
            Console.WriteLine(fl);
        }

        int[,] array = new int[nUsers + 1, nFilms + 1];

        for (int i = 1; i < array.GetLength(0); i++)
        {
            string[] line = lines[i].Split(' ');
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (i == 0 || j == 0)
                {
                    array[i, j] = 0;
                    continue;
                }
                
                array[i, j] = int.Parse(line[j]);
            }
        }
        return array;
    }
}