using System.Data;

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
                Console.WriteLine("4) Fjerne venner");
                Console.WriteLine("5) Logg ut");
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
                            mySystem.CurrentUser.ShowFriendProfile();
                            break;
                        case 3:
                            Console.Clear();
                            mySystem.GetUsers();
                            GetFriendMenu();
                            break;
                        case 4:
                            RemoveFriendMenu();
                            break;
                        case 5:
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

            void RemoveFriendMenu()
            {
                Console.Clear();
                mySystem.CurrentUser.ShowFriends();
                if (mySystem.CurrentUser.Friends.Count > 0)
                {
                    Console.WriteLine("Skriv inn navnet til brukeren du har lyst til å fjerne som venn.");
                    Console.WriteLine("Eller skriv X for å gå tilbake."); 
                    var userInput = Console.ReadLine();
                    if (userInput is "x" or "X") return;
                    var oldFriend = mySystem.CurrentUser.ReturnFriendByName(userInput);
                    if(mySystem.CurrentUser.RemoveFriend(oldFriend))
                    {
                        Console.WriteLine($"{oldFriend.Name} har blitt slettet fra din venneliste.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine($"{userInput} finnes ikke i din venneliste, vennligst prøve noe annet.");
                        Thread.Sleep(1000);
                        RemoveFriendMenu();
                    }
                }
            }

            void GetFriendMenu()
            {
                Console.WriteLine("Skriv inn navnet til en bruker hvis du har lyst til å legge dem til som venn.");
                Console.WriteLine("Eller skriv X for å gå tilbake.");
                var CurrentUser = mySystem.CurrentUser;
                var userInput = Console.ReadLine();
                if (userInput is "x" or "X") return;
                var newFriend = mySystem.GetUserFromName(userInput);
                if (newFriend == null)
                {
                    Console.Clear();
                    mySystem.GetUsers();
                    GetFriendMenu();
                }
                else
                {
                    CurrentUser.AddFriend(newFriend);
                    Console.WriteLine($"La til {newFriend.Name}, til vennelista!");
                    Thread.Sleep(1000);
                }
            }
        }

        
    }
}
