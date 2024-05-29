namespace Oppgave_Social_Media
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mySystem = new MySystem();

            while (true)
            {
                Menu();
            }
            

            void Menu()
            {
                Console.Clear();
                Console.WriteLine("1) Min profil");
                Console.WriteLine("2) Venneliste");
                Console.WriteLine("3) Legg til venner");
                Console.WriteLine("4) Logg ut");
                MenuLogic();
            }

            void MenuLogic()
            {
                var userInputStr = Console.ReadLine();
                if (Int32.TryParse(userInputStr, out int userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            mySystem.CurrentUser.ShowProfile();
                            break;
                        case 2:
                            mySystem.CurrentUser.ShowFriends();
                            break;
                        case 3:
                            mySystem.GetUsers();
                            break;
                        case 4:
                            Console.WriteLine("Trist å se deg dra :(");
                            Environment.Exit(69);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Skriv noe igjen");
                    Thread.Sleep(250);
                }
            }
        }
    }
}
