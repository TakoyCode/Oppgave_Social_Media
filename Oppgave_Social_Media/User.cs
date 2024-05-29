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
        private List<User> _friends; 

        public User(string name, int age, string sex, string city, string country, string description)
        {
            Name = name;
            Age = age;
            Sex = sex;
            _city = city;
            Country = country;
            _description = description;
            _friends = new List<User>();
        }

        public void AddFriend(User user)
        {
            _friends.Add(user);
        }

        public void RemoveFriend(User user)
        {
            foreach (User friend in _friends)
            {
                if (friend == user) _friends.Remove(friend);
            }
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
            if (_friends.Count > 0)
            {
                foreach (var friend in _friends)
                {
                    Console.WriteLine($"Navn:{friend.Name} \tAlder:{friend.Age} \tKjønn: {friend.Sex} \tLand: {friend.Country}");
                }
                Console.WriteLine("Skriv inn navnet til en venn for mer info eller skriv X for å gå tilbake");
                var userinput = Console.ReadLine();
                if(userinput == "x" || userinput == "X")return;

                var friendObj = SearchFriendsByName(userinput);
                if (friendObj != null){friendObj.ShowProfile();}
            }
            else
            {
                Console.WriteLine("Du har ingen venner, kansje finne noen? :)");
                Console.Write("\nPress en knapp for å gå tilbake");
                Console.ReadKey(true);
            }
            
        }

        public User SearchFriendsByName(string userName)
        {
            foreach (var friend in _friends)
            {
                if (friend.Name == userName) return friend;
            }

            return null;
        }

    }
}
