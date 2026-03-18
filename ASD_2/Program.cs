namespace ASD_2;

static class Program
{
    static void Main(string[] args)
    {
        int user = 10;
        string inputFileName = "input_22_7.txt";

        string baseDir = "C:\\Users\\IlyaP\\My\\programming\\C#\\ASD_2\\ASD_2";
        
        string inputFile = $"{baseDir}\\task_02_data_examples\\{inputFileName}";
        string outputFIle = $"{baseDir}\\res\\res_user_{user}_{inputFileName}";
        
        int[,] array = Parser.FileToArray(inputFile);
        var res = InversionsCounter.GetReversesForUser(user, array);
        
        foreach (var el in res)
        {
            Console.WriteLine($"{el.reverses} {el.user}");
        }
        
        Parser.ArrayToFile(outputFIle, res);
    }
}