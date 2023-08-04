namespace ImageSelector;

static class ImageSelector
{
    static void Main(string[] args)
    {
        Console.WriteLine(args[0]);
        Console.WriteLine(args[1]);
        if (Directory.Exists(args[0]) && Directory.Exists(args[1]) && File.Exists(args[2]))
        {
            TextReader reader = new StreamReader(args[2]);
            List<string> errors = new List<string>();
            var res = reader.ReadLine();
            while(res is not null)
            {
                try
                {
                    File.Copy($"{args[0]}/_DSC{res}.JPG", $"{args[1]}/_DSC{res}.JPG");
                    if (File.Exists($"{args[0]}/_DSC{res}.NEF"))
                    {
                        File.Copy($"{args[0]}/_DSC{res}.NEF", $"{args[1]}/_DSC{res}.NEF");
                        
                    }
                    
                }
                catch (Exception e)
                {
                    errors.Add(e.Message);
                }
                res = reader.ReadLine();
            }
            Console.WriteLine($"Finished with {errors.Count} errors");
            foreach (var error in errors)
            {
                Console.Error.WriteLine(error);
            }
        }
        else
        {
            Console.Error.WriteLine("Wrong arguments");
        }
    }
}