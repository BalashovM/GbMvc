namespace MyLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scanner = new Scanner();
            var converter = new ConvertLibrary();
            scanner.Attach(converter);

            var a = scanner.Scan();

            // вызовы метода для иммитации изменения состояния процессора и оперативной памяти
            for (int i = 0; i < 10; i++)
            {
                scanner.ChangeLoadState();
            }

            converter.SaveAsJpg(a);
            converter.SaveAsBmp(a);
        }
    }
}
