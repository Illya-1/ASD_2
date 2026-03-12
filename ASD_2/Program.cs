namespace ASD_2;

static class Program
{
    static void Main(string[] args)
    {
        // int[,] array = new int[,]
        // {
        //     {3, 5, 0, 0, 0, 0},
        //     {1, 3, 1, 4, 2, 5},
        //     {2, 5, 2, 4, 3, 1},
        //     {3, 4, 1, 2, 3, 5}
        // };
        int user = 10;
        string inputFileName = "input_22_7.txt";
        string inputFile = $"C:\\Users\\IlyaP\\My\\programming\\C#\\ASD_2\\ASD_2\\task_02_data_examples\\{inputFileName}";
        string outputFIle = $"C:\\Users\\IlyaP\\My\\programming\\C#\\ASD_2\\ASD_2\\res\\res_user_{user}_{inputFileName}";
        
        int[,] array = Parser.FileToArray(inputFile);
        var res = InversionsCounter.GetReversesForUser(user, array);
        
        foreach (var el in res)
        {
            Console.WriteLine($"{el.reverses} {el.user}");
        }
        
        Parser.ArrayToFile(outputFIle, res);
    }
    
    
}