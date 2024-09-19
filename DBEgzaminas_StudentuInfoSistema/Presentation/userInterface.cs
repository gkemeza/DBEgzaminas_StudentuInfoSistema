namespace DBEgzaminas_StudentuInfoSistema.Presentation
{
    public class UserInterface
    {
        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("***** Students Info System *****\n");
            Console.WriteLine("Choose category:");
            Console.WriteLine("1. Departments");
            Console.WriteLine("2. Students");
            Console.WriteLine("3. Lectures");
            Console.WriteLine("q. Exit");
        }
    }
}
