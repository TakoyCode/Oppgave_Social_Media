namespace Oppgave_Social_Media
{
    internal class MySystem
    {
        public List<User> AllUsers;
        public User CurrentUser;

        public MySystem()
        {
            AllUsers = new List<User>()
            {
                new("Audun", 22, "Male", "Drammen", "Norge", "Noen må kode denne tingen, og det ser ut som det ble meg."),
                new("Bob",44 , "Male", "London","United Kingdom", "Just a tradesman, that loves football"),
                new("Kari", 77, "Female", "Fredrikstad", "Norge", "Elsker planter og hunder. Driver en hunde rescue på siden."),
                new("Odin", 20, "Male", "Drammen", "Norge", "Elsker spill og elektronikk. Lever for en ryddigere verden."),
                new("Prince", 28, "Other", "Abuja", "Nigeria", "Add me if you want to get riches, from a real nigerian prince!"),
            };

            CurrentUser = AllUsers[0];
        }

        public void GetUsers()
        {
            Console.Clear();
            foreach (var user in AllUsers)
            {
                if(CurrentUser == user || CurrentUser.SearchFriendsByName(user.Name) == user) continue;
                Console.WriteLine($"Navn:{user.Name} \tAlder:{user.Age} \tKjønn: {user.Sex} \tLand: {user.Country}");
                Console.WriteLine();
            }

            Console.WriteLine("Skriv inn navnet til en bruker hvis du har lyst til å legge dem til som venn.");
            Console.WriteLine("Eller skriv X for å gå tilbake.");
            var userInput = Console.ReadLine();
            if(userInput is "x" or "X") return;
            var newFriend = GetUserFromName(userInput);
            if (newFriend != null)
            {
                CurrentUser.AddFriend(newFriend);
                Console.WriteLine($"La til {newFriend.Name}, til vennelista!");
                Thread.Sleep(1000);
            }
            else GetUsers();

        }

        public User GetUserFromName(string userName)
        {
            foreach (var user in AllUsers)
            {
                if (userName == user.Name) return user;
            }
            return null;
        }

    }
}
