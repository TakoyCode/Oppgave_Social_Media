namespace Oppgave_Social_Media
{
    internal class User
    {
        public string Name { get; }
        public int Age { get; }
        public string Sex { get; }
        private string _city;
        public string Country { get; }
        private string _description;
        public List<User> Friends { get; private set; }

        public User(string name, int age, string sex, string city, string country, string description)
        {
            Name = name;
            Age = age;
            Sex = sex;
            _city = city;
            Country = country;
            _description = description;
            Friends = new List<User>();
        }

        public void AddFriend(User user)
        {
            Friends.Add(user);
        }

        public bool RemoveFriend(User user)
        {
            return Friends.Remove(user);
        }

        public void ShowProfile()
        {
            Console.Clear();
            Console.WriteLine($"Navn: {Name}");
            Console.WriteLine($"Alder: {Age}");
            Console.WriteLine($"Kjønn: {Sex}");
            Console.WriteLine($"Fra: {_city}, {Country}");
            Console.WriteLine(_description);

            Console.Write("\nPress en knapp for å gå tilbake");
            Console.ReadKey(true);
        }

        public void ShowFriends()
        {
            Console.Clear();
            if (Friends.Count > 0)
            {
                foreach (var friend in Friends)
                {
                    Console.WriteLine($"Navn:{friend.Name} \tAlder:{friend.Age} \tKjønn: {friend.Sex} \tLand: {friend.Country}");
                }
            }
            else
            {
                Console.WriteLine("Du har ingen venner, kansje finne noen? :)");
                Console.Write("\nPress en knapp for å gå tilbake");
                Console.ReadKey(true);
            }
        }

        public void ShowFriendProfile()
        {
            if (Friends.Count > 0)
            { 
                Console.WriteLine("Skriv inn navnet til en venn for mer info eller skriv X for å gå tilbake");
                var userinput = Console.ReadLine();
                if(userinput == "x" || userinput == "X")return;

                var friendObj = ReturnFriendByName(userinput);
                friendObj?.ShowProfile();
                if (friendObj == null)
                {
                    Console.Clear();
                    ShowFriends();
                    ShowFriendProfile();
                };
            }
        }   

        public User ReturnFriendByName(string userName)
        {
            foreach (var friend in Friends)
            {
                if (friend.Name.ToLower() == userName.ToLower()) return friend;
            }

            return null;
        }

    }
}
